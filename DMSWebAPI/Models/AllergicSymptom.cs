using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSWebAPI.Models
{
    public class AllergicSymptom
    {
       [Key]
        [Required]
        [Column (Order = 1) ]
        public int AllergicSymptomId { get; set; }

        //[Key]
        [Required]
        //[Column(Order = 1)]
        public string AllergyName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
