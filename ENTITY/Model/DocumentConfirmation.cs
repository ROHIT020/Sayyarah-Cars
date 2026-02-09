using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class DocumentConfirmation
    {
        public string ShippingId { get; set; }
        public string ShipNameId { get; set; }
        public string PortId { get; set; }
        public string Loading { get; set; }
        public string Urgent { get; set; }
        public string CustomerId { get; set; }
        public string ProductIndate { get; set; }
        public string PInStatus { get; set; }
        public string ProductType { get; set; }
        public string RikujiDate { get; set; }
        public string SoldCountry { get; set; }
        public string DocStatus { get; set; }
        public string FDate { get; set; }
        public string TDate { get; set; }
        public string TransportId { get; set; }
        public string CarStatus { get; set; }
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
    }
}
