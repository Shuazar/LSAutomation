using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSAutomation.Models.ClickBank
{
    public class Promote
    {
        public string Category { get; set; }
        [Key]
        public string Title { get; set; }
        public string Description { get; set; }
        public string AffiliatePage { get; set; }
        public string CommissionAverageDollarsPerSale { get; set; }
        public string HopLink { get; set; }
    }
}
