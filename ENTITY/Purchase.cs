
namespace ENTITY
{
    public class entPurchase
    {
        public string id { get; set; }
        public string categoryid { get; set; }
        public string productid { get; set; }
        public string variantid { get; set; }
        public string ChassisNo { get; set; }
        public string MDate { get; set; }
        public string RDate { get; set; }
        public string Mileage { get; set; }
        public string Color { get; set; }
        public string OwnerType { get; set; }
        public string OwnerTypeId { get; set; }
        public string AID { get; set; }
        public string Year { get; set; }
        public string SAID { get; set; }
        public string ADate { get; set; }
        public string LotNo { get; set; }
        public string Grade { get; set; }
        public string Urgent { get; set; }
        public string uid { get; set; }

    }
    public class entPurchase_Media
    {
        public string id { get; set; }
        public string PID { get; set; }
        public string Data { get; set; }
        public string uid { get; set; }
        public string mtype { get; set; }
    }
    public class entPurchaseSearch
    {
        public string categoryid { get; set; }
        public string productid { get; set; }
        public string variantid { get; set; }
        public string makerid { get; set; }

        public string bodytypeid { get; set; }
        public string ChassisNo { get; set; }
        public string fdate { get; set; }
        public string tdate { get; set; }
        public string KmsF { get; set; }
        public string KmsT { get; set; }
        public string PriceF { get; set; }
        public string PriceT { get; set; }
        public string Mileage { get; set; }
        public string Color { get; set; }
        public string PageIndex { get; set; }
        public string PageSize { get; set; }

    }
    public class entPushPrice
    {
        public string uid { get; set; }
        public string PID { get; set; }
        public string CurrencyType { get; set; }
        public string PPType { get; set; }
        public string PushPrice { get; set; }
        public string PushPriceTax { get; set; }
        public string ABFType { get; set; }
        public string AuctionFeed { get; set; }
        public string AuctionFeedTax { get; set; }
        public string NoPlate { get; set; }
        public string NoPlateTax { get; set; }
        public string NoPlateNTax { get; set; }
        public string Security { get; set; }
        public string SecurityTax { get; set; }
        public string SecurityNTax { get; set; }
        public string Transport { get; set; }
        public string TransportTax { get; set; }
        public string Cancellation { get; set; }
        public string CancellationTax { get; set; }
        public string CarPanalty { get; set; }
        public string RecycleFee { get; set; }
        public string OtherType { get; set; }
        public string OtherTypeAmt { get; set; }
        public string OtherTypeTax { get; set; }
        public string OtherNType { get; set; }
        public string OtherNTypeAmt { get; set; }
        public string Total { get; set; }
        public string Remarks { get; set; }
        public string DOE { get; set; }
    }
    public class entSearchPushPrice
    {
        public string GID { get; set; }
        public string AID { get; set; }
        public string Adate { get; set; }
        public string SAID { get; set; }
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
        public string RecordCount { get; set; }
      
    }
}
