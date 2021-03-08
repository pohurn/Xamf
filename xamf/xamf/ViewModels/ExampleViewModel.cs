using Acr.UserDialogs;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using xamf.Services;

namespace xamf.ViewModels
{
    public class ExampleViewModel : BaseViewModel
    {
        IApiService _apiService;

        private string name = "Navin";
        private string country = "Mauritius";
        private string countryDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Duis at tellus at urna condimentum mattis. Proin sed libero enim sed faucibus turpis in. Elit duis tristique sollicitudin nibh. Egestas tellus rutrum tellus pellentesque. Dolor sed viverra ipsum nunc aliquet bibendum enim facilisis. Nisl rhoncus mattis rhoncus urna neque viverra. Pellentesque diam volutpat commodo sed egestas egestas fringilla. Quis enim lobortis scelerisque fermentum dui faucibus. Leo duis ut diam quam nulla porttitor massa id neque. Massa id neque aliquam vestibulum morbi blandit cursus risus. Massa sed elementum tempus egestas sed. Vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet. Leo duis ut diam quam nulla porttitor massa id.";

        public ExampleViewModel(INavigation navigation, IUserDialogs dialogs, IPopupNavigation popupNavigation, IApiService apiService)
        {
            _apiService = apiService;
            Navigation = navigation;
            Dialogs = dialogs;
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public string Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged(); }
        }

        public string CountryDescription
        {
            get { return countryDescription; }
            set { countryDescription = value; OnPropertyChanged(); }
        }
    }
}
