
using MarketMAUI.Models;
using MarketMAUI.Service;

namespace MarketMAUI.Pages;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();
		Refresh();
	}

    private async void Refresh()
    {
		try
		{
            await DataManager.Init();
            LVProduct.ItemsSource = DataManager.products;
        }catch(Exception ex)
		{
			await Navigation.PushModalAsync(new ErrorPage(ex.ToString()));
		}
		
    }

    private async void LVProduct_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if(LVProduct.SelectedItem is Product product)
		{
			await Navigation.PushAsync(new CurrentProductPage(product));
		}
    }

    
}