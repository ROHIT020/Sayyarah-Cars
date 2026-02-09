using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class ShipConfirmationReport
    {
        public int Id { get; set; }
        public string ShippingCompany { get; set; }
        public string PortName { get; set; }
        public string ShipName { get; set; }
        public string Loading { get; set; }
        public string Urgent { get; set; }
        public string CustomerName { get; set; }
        public string ProductInDate { get; set; }
        public string ProductInStatus { get; set; }
        public string Orderby { get; set; }
        public string RikujiDate { get; set; }
        public string SoldCountry { get; set; }
        public string InvoiceType { get; set; }
        public string ChassisNo { get; set; }
        public string AllChassisNo { get; set; }
        public string DocumentsStatus { get; set; }
        public string Datefrom { get; set; }
        public string DateTo { get; set; }
        public string Transport { get; set; }
        public string CarStatus { get; set; }
    }
}
