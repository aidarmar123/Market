using MarketMAUI.Service;
using MarketMAUI.Pages;
using System.ComponentModel.DataAnnotations;
using MarketMAUI.Models.MetaUser;
using MarketMAUI.Models;
using System.ComponentModel;
using System.Diagnostics;


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
            MainPage = new AppShell();


            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; 

            //if (DataManager.contextUser == null)
            //{
            //    MainPage = new NavigationPage(new LoginPage());
            //}
            //else
            //{
            //    MainPage = new AppShell();
            //}



        }

        private void CurrentDomain_FirstChanceException(object? sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Debug.WriteLine($"***** Handling Unhandled Exception *****: {e.Exception.Message}");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException();

        }
        private void HandleException()
        {
            // Логирование ошибки
            Console.WriteLine($"Unhandled exception: ");

            // Отображение сообщения пользователю
            MainPage.DisplayAlert("Error", "An unexpected error occurred.", "OK");
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
