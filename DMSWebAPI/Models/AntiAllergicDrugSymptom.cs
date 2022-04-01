using System.ComponentModel.DataAnnotations;

namespace DMSWebAPI.Models
{
    public class AntiAllergicDrugSymptom
    {
        [Key]
        [Required]
        public int AntiAllergicDrugSymptomId { get; set; }

        [Required]
        [Display(Name = "AntiAllergicDrugName")]
        public string ShortName { get; set; }
        public AntiAllergicDrug AntiAllergicDrug { get; set; }

        [Required]
        public int AllergyName { get; set; }
        public AllergicSymptom AllergicSymptom { get; set; }
        [Required]

        public string SpecialDescription { get; set; }
    }
}
