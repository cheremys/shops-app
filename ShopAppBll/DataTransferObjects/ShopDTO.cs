using System.Collections.Generic;

namespace ShopAppBll.DataTransferObjects
{
    public class ShopDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<SalesConsultantDTO> SalesConsultants { get; set; }

        public ShopDTO()
        {
            SalesConsultants = new List<SalesConsultantDTO>();

        }
    }
}
