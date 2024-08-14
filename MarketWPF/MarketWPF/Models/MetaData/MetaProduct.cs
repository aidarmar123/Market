using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketWPF.Models.MetaData
{
    public partial class MetaProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MetaProduct()
        {
            this.HistorySkan = new HashSet<HistorySkan>();
            this.ImageProduct = new HashSet<ImageProduct>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="Name is empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is empty")]
        public int Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorySkan> HistorySkan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
    }
}
