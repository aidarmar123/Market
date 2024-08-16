using MarketMAUI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketMAUI.Models
{
    public partial class Product
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        
        public virtual ICollection<HistorySkan> HistorySkan { get; set; }

        [JsonIgnore]
        public List<ImageProduct> ImageProduct
        {
            get
            {
                return DataManager.imageProducts.Where(x=>x.ProductId == Id).ToList();
            }
        }
      
    }
}
