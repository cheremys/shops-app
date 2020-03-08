using System.Collections.Generic;

namespace ShopAppWEB.Models
{
    public class ShopModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<SalesConsultantModel> SalesConsultants { get; set; }

        public ShopModel()
        {
            SalesConsultants = new List<SalesConsultantModel>();

        }
    }
}