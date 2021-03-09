using Acr.UserDialogs;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamf.Models;
using xamf.Services;
using xamf.Services.RequestProvider;
using xamf.ViewModels;

namespace xamf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        bool canOpenRecipe = false;
        bool canShareRecipe = false;

        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new RecipeViewModel(Navigation, UserDialogs.Instance, PopupNavigation.Instance, new ApiService(new RequestProvider()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((RecipeViewModel)BindingContext).FetchRecipesCommand.Execute(null);
        }

        private async void OnSelectingRecipe(object sender, SelectionChangedEventArgs e)
        {
            if (canOpenRecipe) return;
            canOpenRecipe = true;
            var item = e.CurrentSelection;
            if (item.Count == 1)
            {
                var data = item.FirstOrDefault();
                if (data != null)
                {
                    Debug.WriteLine("yes");
                    var datamodel = (menus)data;

                    openUrl(datamodel.href);

                }
            }
            canOpenRecipe = false;
            ((CollectionView)sender).SelectedItem = null;
        }

        public async void openUrl(string url)
        {
            await Browser.OpenAsync(url, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
        }

        private void OnShareIconTapped(object sender, EventArgs e)
        {
            var tappedItem = (TappedEventArgs)e;
            var ItemSelected = (menus)tappedItem.Parameter;
            if (canShareRecipe) return;
            canShareRecipe = true;
            ShareUri(ItemSelected.href, ItemSelected.title);
            canShareRecipe = false;
        }

        public async Task ShareUri(string uri, string recipeTitle)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = uri,
                Title = recipeTitle
            });
        }
    }
}