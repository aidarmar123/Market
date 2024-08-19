using MarketMAUI.Models;
using MarketMAUI.Service;

namespace MarketMAUI.Pages;

public partial class RegistrPage : ContentPage
{
	User contextUser;
	public RegistrPage(Models.User user)
	{
		InitializeComponent();
		contextUser = user;
		Content.BindingContext = contextUser;
	}

    private async void BSignUp_Clicked(object sender, EventArgs e)
    {
		await DataManager.Init();
		var error = ValidationLine.Validation(contextUser);
		if (error.Length == 0)
		{
			if (contextUser.Login.Contains("@"))
			{
                if (DataManager.users.FirstOrDefault(x => x.Login == contextUser.Login) == null)
                {
                    contextUser.Password = HashToMD5.GetMD5(contextUser.Password);
                    var response = await NetManager.Post("api/Users", contextUser);
                    await Navigation.PushAsync(new AppShell());
                }
                else
                {
                    LError.IsVisible = true;
                    LError.Text = "You are already registred";
                }
			}
			else
			{
                LError.IsVisible = true;
                LError.Text = "Incorrect login";
            }
									
		}
		else
		{
			LError.IsVisible = true;
			LError.Text = error.ToString();
		}
    }
}