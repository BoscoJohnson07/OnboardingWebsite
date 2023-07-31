using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingWebsite.Data
{
    public class EmployeeGeneralDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Empid")]
        public string Empid { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DOB {  get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string MaritalName { get; set; }
        public DateTime? DateOfMarriage { get; set; }
        public string BloodGrp { get; set; }   
        public DateTime Date_Created { get; set; } 
        public DateTime? Date_Modified { get; set; }
        public string Created_by { get; set; }
        public string Modified_by { get; set; }
        public string Status { get; set; }

    }
}
