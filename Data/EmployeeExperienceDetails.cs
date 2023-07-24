using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingWebsite.Data
{
    public class EmployeeExperienceDetails:BaseEntity
    {
        [ForeignKey("Empid")]
        public string Empid { get; set; }
        public string Company_name { get; set; }
        public string Designation { get; set; }
        public int Totalmonths { get; set; }
        public string Reason { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Exp_Certificate { get; set; } 
    }
}
