using MarketMAUI.Service;

namespace MarketMAUI
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            CV.ItemsSource = DataManager.products.First().ImageProduct;
        }

       
    }

}
