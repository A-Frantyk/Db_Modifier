using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class DevTestModel
    {
        public int ID { get; set; }

        public int? Impressions { get; set; }

        public string AffiliateName { get; set; }

        public string CompaignName { get; set; }

        public DateTime Date { get; set; }

        public int Clicks { get; set; }

        public int Conversions { get; set; }
    }
}
