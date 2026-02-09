using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class DailyReport
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string AuctionDate { get; set; }
        public string MDate { get; set; }
        public string AuctionName { get; set; }
        public string Urgent { get; set; }
        public string TransportName { get; set; }
        public string CarStatus { get; set; }
        public string RDateFrom { get; set; }
        public string RDateTo { get; set; }
    }
}
