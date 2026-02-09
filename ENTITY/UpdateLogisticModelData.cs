using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class UpdateLogisticModelData
    {
        public int Id { get; set; }
        public string ProductInDate { get; set; }
        public string WishPlanDate { get; set; }
        public string WishPInDate { get; set; }
        public string WishShipDate { get; set; }
        public string WishArrivalDate { get; set; }
        public string ShipName { get; set; }
        public string Surrender { get; set; }
        public string Loading { get; set; }
    }
}
