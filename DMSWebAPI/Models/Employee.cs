using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMSWebAPI.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Required]

        public int EmployeeId { get; set; }
        [Required]
        
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        
        public string Address { get; set; }

        
        public string MobileNumber { get; set; }

        
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string Designation { get; set; }


        

    }
}
