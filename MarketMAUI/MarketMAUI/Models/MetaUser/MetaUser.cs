using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMAUI.Models.MetaUser
{
    public partial class MetaUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fename is empty")]
        public string Fename { get; set; }
        [Required(ErrorMessage = "Ordname is empty")]
        public string Ordname { get; set; }
        [Required(ErrorMessage = "Login is empty")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
        public int RoleId { get; set; }


        public virtual ICollection<HistorySkan> HistorySkan { get; set; }
        public virtual Role Role { get; set; }
    }
}
