using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class ProductChecking
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string AuctionDate { get; set; }
        public string AuctionName { get; set; }
        public string Urgent { get; set; }
        public string ChassisNo { get; set; }
    }
}
