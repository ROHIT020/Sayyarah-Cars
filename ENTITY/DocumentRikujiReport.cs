using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DocumentRikujiReport
    {
        public int Id { get; set; }
        public string RikujiDate { get; set; }
        public string SoldCountry { get; set; }
        public string ChassisNo { get; set; }
        public string PortName { get; set; }
        public string Urgent { get; set; }
        public string InvoiceType { get; set; }
        public string ReAuction { get; set; }
        public string UID { get; set; }
    }
}
