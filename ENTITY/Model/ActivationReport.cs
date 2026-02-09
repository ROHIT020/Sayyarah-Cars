using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class ActivationReport
    {
        public int Id { get; set; }
        public string ActivatedBy { get; set; }
        public string AuctionDate { get; set; }
        public string AuctionName { get; set; }
        public string Urgent { get; set; }
        public string ChassisNo { get; set; }
    }
}
