using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DMSWebAPI.Models
{
    
    public class NewDrugTrial
    {
        [Key]
        [Required]
        public int TrialId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public string PurposeOfTrial { get; set; }
        [Required]

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DrugId { get; set; }
        public Drug Drug { get; set; }

        [Required]
        public string TrialResults { get; set; }
        [Required]
        public string TrialStatus { get; set; }
    }
}
