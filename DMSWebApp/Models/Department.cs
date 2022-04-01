using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSWebApp.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Required]
        //[Column(Order = 1)]
        public int DepartmentId { get; set; }
        [Required]
        //[Column(Order = 2)]
        
        public string DepartmentName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
