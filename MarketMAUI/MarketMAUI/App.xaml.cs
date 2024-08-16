using MarketMAUI.Service;

namespace MarketMAUI
{
    public partial class App : Application
    {
        public App()
        {
            DataManager.Init();
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
