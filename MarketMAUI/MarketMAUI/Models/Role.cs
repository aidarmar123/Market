using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Models
{
    public partial class Role
    {
       
        public Role()
        {
            this.User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        
        public virtual ICollection<User> User { get; set; }
    }
}
