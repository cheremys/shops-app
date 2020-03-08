namespace ShopAppBll.DataTransferObjects
{
    public class SalesConsultantDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int? ShopId { get; set; }

        public ShopDTO Shop { get; set; }
    }
}
