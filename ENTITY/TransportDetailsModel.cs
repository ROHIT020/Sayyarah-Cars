using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class TransportDetailsModel
    {
        public int Id { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string AuctionHouse { get; set; }
        public string Transport { get; set; }
        public string NoPlate { get; set; }
        public string Urgent { get; set; }
        public string ShortBy { get; set; }
    }
}
