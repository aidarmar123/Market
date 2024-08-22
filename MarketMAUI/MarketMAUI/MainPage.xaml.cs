using MarketMAUI.Models;
using MarketMAUI.Service;

namespace MarketMAUI
{
    public partial class MainPage : ContentPage
    {
        Product product;
        public MainPage()
        {
            InitializeComponent();
           
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            product = DataManager.products.First();
            SLProduct.BindingContext = product;
        }
    }

}
