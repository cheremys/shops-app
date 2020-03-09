using System.ComponentModel.DataAnnotations;

namespace ShopAppWEB.Models
{
    public class SalesConsultantModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int? ShopId { get; set; }

        public ShopModel Shop { get; set; }
    }
}