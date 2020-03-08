using System.ComponentModel.DataAnnotations;

namespace ShopAppDAL.Entities
{
    public class SalesConsultant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public int? ShopId { get; set; }

        public Shop Shop { get; set; }
    }
}
