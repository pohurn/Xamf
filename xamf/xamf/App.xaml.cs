using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamf.Views;

namespace xamf
{
    public partial class App : Application
    {
        public static NavigationPage np;
        private static HttpClient httpClient;

        public App()
        {
            InitializeComponent();
            np = new NavigationPage(new HomePage());

            MainPage = np;
        }

        public static HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    ServicePointManager.DefaultConnectionLimit = 10;
                    httpClient = new HttpClient
                    {
                        MaxResponseContentBufferSize = 1000000,
                        Timeout = TimeSpan.FromSeconds(30)
                    };
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return httpClient;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
