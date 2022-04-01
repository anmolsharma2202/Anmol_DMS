using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSWebAPI.Models
{
    
    public class UsageCondition
    {
        [Key]
        [Required]
        public int ConditionId { get; set; }
        [Required]
        public string Description { get; set; }
        public string OtherDetails { get; set; }

        public string DrugId { get; set; }
        public Drug Drug { get; set; }

       
    }
}
