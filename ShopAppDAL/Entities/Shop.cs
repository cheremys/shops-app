using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppDAL.Entities
{
    public class Shop
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public virtual ICollection<SalesConsultant> SalesConsultants { get; set; }

        public Shop()
        {
            SalesConsultants = new List<SalesConsultant>();
        }
    }
}
