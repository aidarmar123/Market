using MarketMAUI.Service;
using MarketMAUI.Pages;
using System.ComponentModel.DataAnnotations;
using MarketMAUI.Models.MetaUser;
using MarketMAUI.Models;
using System.ComponentModel;

namespace MarketMAUI
{
    public partial class App : Application
    {
        
        public App()
        {
            if (Device.RuntimePlatform == Device.WinUI)
            {
                NetManager.URL = "http://localhost:55419/";
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                NetManager.URL = "http://127.0.0.1:55419/";
            }
            RegistrationAllDescriptor();
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());

            
        }

        private void RegistrationAllDescriptor()
        {
            RegistarationDescriptor<User, MetaUser>();
        }

        private void RegistarationDescriptor<T1, T2>()
        {
            var provider = new AssociatedMetadataTypeTypeDescriptionProvider(typeof(T1), typeof(T2));
            TypeDescriptor.AddProviderTransparent(provider, typeof(T1));
        }
    }
}
