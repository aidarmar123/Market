using MarketMAUI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketMAUI.Models
{
    public partial class ImageProduct
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public ImageSource image
        {
            get
            {
                var imageBase64 = Convert.FromBase64String(Image);
                return ImageSource.FromStream(()=> new MemoryStream(imageBase64));
            }
        }
        [JsonIgnore]
        public Product Product
        {
            get
            {
                return DataManager.products.FirstOrDefault(p => p.Id == Id);
            }
        }
    }
}
