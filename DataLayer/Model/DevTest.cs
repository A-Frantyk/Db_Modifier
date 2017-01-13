using System;

namespace DataLayer.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DevTest")]
    public class DevTest
    {
        public int ID { get; set; }

        public string CompaignName { get; set; }

        public DateTime Date { get; set; }

        public int Clicks { get; set; }

        public int Conversions { get; set; }

        public int? Impressions { get; set; }

        [StringLength(255)]
        public string AffiliateName { get; set; }
    }
}
