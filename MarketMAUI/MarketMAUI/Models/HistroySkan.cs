using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Models
{
    public partial class HistorySkan
    {
        public int Id { get; set; }
        public System.DateTime DateTime { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}
