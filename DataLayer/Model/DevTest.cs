namespace DataLayer.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DevTest")]
    public class DevTest
    {
        public int ID { get; set; }

        public int? Impressions { get; set; }

        [StringLength(255)]
        public string AffiliateName { get; set; }
    }
}
