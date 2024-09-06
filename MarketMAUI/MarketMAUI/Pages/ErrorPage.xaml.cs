namespace MarketMAUI.Pages;

public partial class ErrorPage : ContentPage
{
	public ErrorPage(string errorMsg)
	{
		InitializeComponent();
		ErrorMessageLabel.Text = errorMsg;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage.Navigation.PopModalAsync();
    }
}