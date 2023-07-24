using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingWebsite.Data
{
    public class EmployeeAdditionalInfo:BaseEntity
    {
        [ForeignKey("Empid")]
        public string Empid { get; set; }  
        public bool? Disability { get; set; }
        public string? Disablility_type { get; set; }
        public string Covid_VaccSts { get; set; }
        public string? Vacc_Certificate { get; set; }
    }
}
