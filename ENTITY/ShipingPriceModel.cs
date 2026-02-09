namespace ENTITY
{
    public class ShipingPriceModel
    {
        public int Id { get; set; }

        public string ShipingCompany { get; set; }

        public string ProductType { get; set; }
        public string CountryName { get; set; }
        public string PortName { get; set; }
        public string FreightPrice { get; set; }
    }
}
