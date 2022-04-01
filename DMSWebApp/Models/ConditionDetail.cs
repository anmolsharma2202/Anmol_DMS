using System.ComponentModel.DataAnnotations;

namespace DMSWebApp.Models
{
    public class ConditionDetail
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int AllergicSymptomId { get; set; }
        public AllergicSymptom AllergicSymptom { get; set; }
    }
}
