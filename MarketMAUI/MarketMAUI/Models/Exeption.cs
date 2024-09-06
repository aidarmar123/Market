using MarketMAUI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Models
{
    public partial class Exeption
    {
        public Exeption(string message) 
        {
            ErrorMessage = message;
            App.Current.MainPage.Navigation.PushModalAsync(new ErrorPage(ErrorMessage));
        }
        public string ErrorMessage { get; set; } 
    }
}
