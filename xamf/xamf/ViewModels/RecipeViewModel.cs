using Acr.UserDialogs;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using xamf.Exceptions;
using xamf.Models;
using xamf.Services;

namespace xamf.ViewModels
{
    public class RecipeViewModel : BaseViewModel
    {
        IApiService _apiService;
        private ObservableCollection<menus> allrecipes = new ObservableCollection<menus>();
        private int pagesize = 1;
        private int items;

        public RecipeViewModel(INavigation navigation, IUserDialogs dialogs, IPopupNavigation popupNavigation, IApiService apiService)
        {
            _apiService = apiService;
            Navigation = navigation;
            Dialogs = dialogs;
            bool canFetchRecipes = false;

            FetchRecipesCommand = new Command(async () =>
            {
                CanInitiateNewFetchRecipes(false);
                try
                {
                    Dialogs?.ShowLoading("Fetching recipes for you...");
                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {
                        try
                        {
                            if(PageSize == 100) //max page size reached
                            {
                                Dialogs?.HideLoading();
                                await Dialogs?.AlertAsync("The end of the list has been reached :(", "Notice", "OK");
                                return;
                            }
                            var RecipesRetrieved = await _apiService.GetAllRecipes(PageSize);
                            if (RecipesRetrieved != null)
                            {
                                if(RecipesRetrieved.results.Count > 0)
                                {
                                    foreach(var data in RecipesRetrieved.results)
                                    {
                                        AllRecipes.Add(data);
                                    }
                                }
                                PageSize++;
                                Items = (AllRecipes.Count) - 1;
                                Dialogs?.HideLoading();
                            }
                            else
                            {
                                Dialogs?.HideLoading();
                                await Dialogs?.AlertAsync("No data found!. Please try again later.", "Error", "OK");
                            }
                        }
                        catch (ApiException ex)
                        {
                            Dialogs?.HideLoading();
                            popupNavigation?.PopAsync();
                            await Dialogs?.AlertAsync(ex.Content, ex.Name, "OK");
                        }
                        catch (Exception ex)
                        {
                            Dialogs?.HideLoading();
                            await Dialogs?.AlertAsync("An unexpected error has occurred. Please try again.", "Error", "OK");
                            Debug.WriteLine(ex);
                        }
                    }
                    else
                    {
                        Dialogs?.HideLoading();
                        popupNavigation?.PopAsync();
                        await Dialogs?.AlertAsync("You seem to be offline. Please connect to the Wi-Fi and try again.", "Error", "OK");
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    Dialogs?.HideLoading();
                }
                CanInitiateNewFetchRecipes(true);
            }, () => canFetchRecipes);


            void CanInitiateNewFetchRecipes(bool value) { canFetchRecipes = value; ((Command)FetchRecipesCommand).ChangeCanExecute(); }

        }

        public ICommand FetchRecipesCommand { get; }

        public ObservableCollection<menus> AllRecipes
        {
            get { return allrecipes; }
            set { allrecipes = value; OnPropertyChanged(); }
        }

        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value; OnPropertyChanged(); }
        }

        public int Items
        {
            get { return items; }
            set { items = value; OnPropertyChanged(); }
        }
    }
}
