using System.ComponentModel.DataAnnotations;

namespace DMSWebApp.Models
{

    public class Patient
    {
        [Key]
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        
        
            [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }


    }
}
