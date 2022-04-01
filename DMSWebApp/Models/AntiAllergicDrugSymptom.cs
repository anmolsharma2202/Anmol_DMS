using System.ComponentModel.DataAnnotations;

namespace DMSWebApp.Models
{
    public class AntiAllergicDrugSymptom
    {
        [Key]
        [Required]
        public int AntiAllergicDrugSymptomId { get; set; }
        [Required]
        public string AntiAllergicDrugName { get; set; }
        [Required]
        public string AllergyName { get; set; }
        [Required]
        public string SpecialDescription { get; set; }
    }
}
