using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Models
{
    public partial class Product
    {
        public Product()
        {
            this.HistorySkan = new HashSet<HistorySkan>();
            this.ImageProduct = new HashSet<ImageProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        
        public virtual ICollection<HistorySkan> HistorySkan { get; set; }
        
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
    }
}
