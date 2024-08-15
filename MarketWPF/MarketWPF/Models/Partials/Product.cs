using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketWPF.Models
{
    public partial class Product
    {
        public string BarCodeText
        {
            get
            {
                return $"{Id}{Name}";
            }
        }
    }
}
