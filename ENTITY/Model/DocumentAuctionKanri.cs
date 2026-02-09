using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class DocumentAuctionKanri
    {
        public int Id { get; set; }
        public string AuctionName { get; set; }
        public string AuctionDate { get; set; }
        public string PortName { get; set; }
        public string ChassisNo { get; set; }
        public string InvoiceType { get; set; }
        public string Reauction { get; set; }
        public string Country { get; set; }
        public string NoPlate { get; set; }
        public string Urgent { get; set; }
        public string CarStatus { get; set; }
        public int UID { get; set; }
    }
}
