using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class ShippedCars
    {
        
        public int Id { get; set; }
        public string Shipping { get; set; }
        public string Country { get; set; }
        public string ClientName { get; set; }
        public string Port { get; set; }
        public string ShipName { get; set; }
        public string ChassisNo { get; set; }
        public string Surrender { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int UID { get; set; }
    }
}
