using System.ComponentModel.DataAnnotations;

namespace DMSWebApp.Models
{
    public class ReactionAgent
    {
        [Key]
        [Required]
        public int ReactionAgentId { get; set; }
        [Required]
        public string ShortName { get; set; }
        [Required]
        public string LongName { get; set; }
        [Required]
        public string Description { get; set; } 
    }
}
