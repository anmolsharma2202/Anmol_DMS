using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSWebApp.Models
{
    
    public class UsageCondition
    {
        [Key]
        [Required]
        public int ConditionId { get; set; }
        [Required]
        public string Description { get; set; }
        public string OtherDetails { get; set; }

        public string DrugName{ get; set; }
        


    }
}
