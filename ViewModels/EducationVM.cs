using Microsoft.AspNetCore.Http;
namespace OnboardingWebsite.Models
{
    public class EducationVM
    {
        public string programme { get; set; }
        public string CollegeName { get; set; }
        public string Degree { get; set; }
        public string specialization { get; set; }
        public int Passoutyear { get; set; }
        public IFormFile Certificate { get; set; }
    }
}
