using Acr.UserDialogs;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamf.Services;
using xamf.Services.RequestProvider;
using xamf.ViewModels;

namespace xamf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ExampleViewModel(Navigation, UserDialogs.Instance, PopupNavigation.Instance, new ApiService(new RequestProvider()));
        }
    }
}