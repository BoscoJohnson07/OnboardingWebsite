using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingWebsite.Data
{
    public class EmployeeContactDetails:BaseEntity
    {
        [ForeignKey("Empid")]
        public string Empid { get; set; }  
        public string Personal_Emailid { get; set; }
        public double Contact_no { get; set; }
        public string? Emgy_Contactperson { get; set; }
        public string? Emgy_Contactrelation { get; set; }
        public double? Emgy_Contactno { get; set; }
    }
}
