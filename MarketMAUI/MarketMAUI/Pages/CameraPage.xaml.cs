
using Camera.MAUI;
using MarketMAUI.Service;
using MarketMAUI.Models;
using Camera.MAUI.ZXing;

namespace MarketMAUI.Pages;

public partial class CameraPage : ContentPage
{
    Product contextProduct;
    public CameraPage()
    {
        InitializeComponent();
        cameraView.CamerasLoaded += CameraView_CamerasLoaded; ;
        cameraView.BarcodeDetected += Camera_BarcodeDetected;
        cameraView.BarCodeDecoder = new ZXingBarcodeDecoder();
    }

    private void CameraView_CamerasLoaded(object? sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StartCameraAsync();
        });
    }

    

    private void Camera_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        var findProduct = DataManager.products.FirstOrDefault(x => x.Id == Convert.ToInt32(args.Result[0].Text));
        if (findProduct != null)
        {
            contextProduct = findProduct;
            SLProduct.BindingContext = contextProduct;

            var histrorySkan = new HistorySkan
            {
                DateTime = DateTime.Now,
                ProductId = contextProduct.Id,
                UserId = DataManager.ContextUser.Id
            };
        }


    }
}