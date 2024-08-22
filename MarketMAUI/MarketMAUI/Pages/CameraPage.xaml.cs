
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
        
        cameraView.BarcodeDetected += Camera_BarcodeDetected;
        cameraView.BarCodeDecoder = new ZXingBarcodeDecoder();
        cameraView.BarCodeOptions = new BarcodeDecodeOptions
        {
            AutoRotate = true,
            PossibleFormats = { BarcodeFormat.CODE_128 },
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = true
        };
        cameraView.BarCodeDetectionEnabled = true;
    }
    private void Camera_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        contextProduct = DataManager.products.FirstOrDefault(x => x.Id == Convert.ToInt32(args.Result[0].Text));
        
    }

    private async void CreateCart()
    {
        await Navigation.PushAsync(new CurrentProductPage(contextProduct));
    }

    private async void AddHistory()
    {
        var histrorySkan = new HistorySkan
        {
            DateTime = DateTime.Now,
            ProductId = contextProduct.Id,
            UserId = DataManager.ContextUser.Id
        };
        await NetManager.Post("api/HistorySkans", histrorySkan);
    }

    private void BStartCamera_Clicked(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StartCameraAsync();
        });
        
    }

    private void BFindProduct_Clicked(object sender, EventArgs e)
    {
        if (contextProduct != null)
        {
            CreateCart();
            AddHistory();
            contextProduct = null;
            
        }
    }
}