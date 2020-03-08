namespace ShopAppWEB.Models
{
    public class SalesConsultantModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int? ShopId { get; set; }

        public ShopModel Shop { get; set; }
    }
}