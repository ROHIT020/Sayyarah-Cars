using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class GetTransportBill
    {
        public string CategoryID { get; set; }

        public string ProductID { get; set; }

        public string AuctionID { get; set; }

        public string TransportID { get; set; }

        public string TransportDate { get; set; }

        public string Pageindex { get; set; }

        public string Pagesize { get; set; }

       


    }

    public class TransportBill
    {
        public string PID { get; set; }

        public string TID { get; set; }

        public string Tcharges { get; set; }

        public string Extracharges { get; set; }

        public string Tamount { get; set; }

        public string Extraamt { get; set; }

        public string Remark { get; set; }

        public string UID { get; set; }

        public string DOE { get; set; }

    }
}
