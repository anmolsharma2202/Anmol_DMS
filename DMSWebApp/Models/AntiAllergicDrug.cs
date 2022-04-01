using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSWebApp.Models
{
    public class AntiAllergicDrug
    {
        [Key]
        [Required]
        //[Column(Order = 1)]
        public int AntiAllergicDrugId { get; set; }

        //[Key]
        [Required]
        //[Column(Order = 2)]
        [Display (Name = "AntiAllergicDrugName") ]
        public string ShortName { get; set; }
        [Required]
        public string LongName { get; set; }
        [Required]
        public string SpecialDescription { get; set; }

    }
}

