using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class DownloadShipping
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string ShippingCmpny { get; set; }
        public string Client { get; set; }
        public string PortName { get; set; }
        public string ShipName { get; set; }
        public string Chassis { get; set; }
        public string Surrender { get; set; }
        public string Broker { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string CarStatus { get; set; }
        public string ProductIn { get; set; }
        public int UID { get; set; }
    }
}
