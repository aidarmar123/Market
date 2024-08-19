using MarketMAUI.Models;
using MarketMAUI.Service;
using System.Security.Cryptography;
using System.Text;

namespace MarketMAUI.Pages;

public partial class LoginPage : ContentPage
{
    public string Login { get; set; }
    public string Password { get; set; }
	public LoginPage()
	{
		InitializeComponent();
        Content.BindingContext = this;
		
	}

   

    private async void BLogin_Clicked(object sender, EventArgs e)
    {
        await DataManager.Init();
        if(Login != null && Password !=null)
        {
            var user= DataManager.users.FirstOrDefault(x=>x.Login == Login && x.Password==HashToMD5.GetMD5(Password));
            if(user != null)
            {
                await Navigation.PushModalAsync(new AppShell());
            }
            else
            {
                LError.IsVisible= true;
                LError.Text = "Incorrect login or password.";
            }
        }
    }

    

    private async void BSignUp_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrPage(new User { RoleId=2})); // Role 2 - User
    }
}