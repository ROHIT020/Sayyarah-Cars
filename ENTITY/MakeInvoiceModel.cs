using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class MakeInvoiceModel
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string UID { get; set; }
        public string ProductType { get; set; }
        public string Customer { get; set; }
        public string ProductName { get; set; }
        public string ChassisNo { get; set; }
        public string AuctionName { get; set; }
        public string ShippingCompany { get; set; }
        public string InvoiceType { get; set; }
        public string PortName { get; set; }
        public string CurrencyType { get; set; }
        public string PushPrice { get; set; }
        public string FOBPrice { get; set; }
        public string FreightCharge { get; set; }
        public string RecycleAmount { get; set; }
        public string OtherServices { get; set; }
        public string Insurance { get; set; }
        public string InsuranceText { get; set; }
        public string Radiation { get; set; }
        public string InspectionPrice { get; set; }
        public string PortPrice { get; set; }
        public string CustomClearance { get; set; }
        public string CarSelection { get; set; }
        public string Transport { get; set; }
        public string FinalSoldPrice { get; set; }
        public string OrderType { get; set; }
        public string Discount { get; set; }
        public string Rate { get; set; }
        public string InvoiceUsed { get; set; }
    }
}
