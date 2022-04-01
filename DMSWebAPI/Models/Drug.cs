using System.ComponentModel.DataAnnotations;

namespace DMSWebAPI.Models
{
    public class Drug
    {
        [Key]
        [Required]
        public int DrugId { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string LongName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ChemicalAnalysis { get; set; }
    }
}
