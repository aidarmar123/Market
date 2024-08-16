using MarketMAUI.Service;

namespace MarketMAUI.Pages;

public partial class CameraPage : ContentPage
{
	public CameraPage()
	{
		InitializeComponent();
        Refresh();
	}
    private async void Refresh()
    {
        await DataManager.Init();
        LV.ItemsSource = DataManager.imageProducts;
    }
}