
using Camera.MAUI;
using MarketMAUI.Service;

namespace MarketMAUI.Pages;

public partial class CameraPage : ContentPage
{
	public CameraPage()
	{
		InitializeComponent();
        
	}

    private void Camera_CamerasLoaded(object sender, EventArgs e)
    {
       
    }

    private void Camera_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {

    }
}