using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Model
{
    public class FullReport
    {
        public int Id { get; set; }
        public string ActionDate { get; set; }
        public string ActionName { get; set; }
        public string PortFrom { get; set; }
        public string SoldCountry { get; set; }
        public string RikujiDate { get; set; }
        public string Transport { get; set; }
        public string Shipping { get; set; }
        public string ChassisNo { get; set; }
        public string Urgent { get; set; }
        public int UID { get; set; }
    }
}
