using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class UpdateBrokerNew
    {
        public string CategoryID { get; set; }

        public string ProductID { get; set; }

        public string ClientID { get; set; }

        public string ShipID { get; set; }

        public string AuctionID { get; set; }

        public string AuctionDate { get; set; }

        public string PageIndex { get; set; }

        public string PageSize { get; set; }

    }

    public class UpdateBrokerNewDetails
    {
        public string Productid { get; set; }

        public string BrokerID { get; set; }

        public string UPBY { get; set; }

        public string UID { get; set; }
    }
}
