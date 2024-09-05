namespace MarketMAUI.Pages;

public partial class ErrorPage : ContentPage
{
	public ErrorPage(string errorMsg)
	{
		InitializeComponent();
		ErrorMessageLabel.Text = errorMsg;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}