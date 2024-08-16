
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
		await DataManager.Init();
		
		
		LVProduct.ItemsSource = DataManager.products;
    }

    private void LVProduct_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}