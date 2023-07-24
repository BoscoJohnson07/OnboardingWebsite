using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingWebsite.Data
{
    public class EmployeeEducationDetails:BaseEntity
    {
        [ForeignKey("Empid")]
        public string Empid { get; set; }
        public string programme { get; set; }  
        public string CollegeName { get; set; }
        public string Degree { get; set; } 
        public string specialization { get; set; }
        public int Passoutyear { get; set; }
        public string Certificate { get; set; }
    }
}
