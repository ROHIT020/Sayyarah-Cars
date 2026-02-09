using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class ShipDeparture
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
        public string PortName { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public int UID { get; set; }
    }
}
