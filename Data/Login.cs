using System.ComponentModel.DataAnnotations;

namespace OnboardingWebsite.Data
{
    public class Login 
    {
        [Key]
        public string Empid { get; set; }
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public DateTime Date_Created { get; set; }
        public DateTime? Date_Modified { get; set; }
        public string Created_by { get; set; }
        public string Modified_by { get; set; }
        public string Status { get; set; }
    }
}
