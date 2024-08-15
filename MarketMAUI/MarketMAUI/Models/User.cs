using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Models
{
    public partial class User
    {
        
        public User()
        {
            this.HistorySkan = new HashSet<HistorySkan>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Fename { get; set; }
        public string Ordname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        
        public virtual ICollection<HistorySkan> HistorySkan { get; set; }
        public virtual Role Role { get; set; }
    }
}
