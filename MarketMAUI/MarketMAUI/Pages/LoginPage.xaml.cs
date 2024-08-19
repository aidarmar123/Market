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
            var user= DataManager.users.FirstOrDefault(x=>x.Login == Login && x.Password==GetMD5(Password));
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

    private string GetMD5(string password)
    {
        using(MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach(var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString("X2"));
            }
            return sb.ToString();
        }
    }

    private async void BSignUp_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrPage(new User()));
    }
}