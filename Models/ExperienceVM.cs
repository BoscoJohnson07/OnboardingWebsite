namespace OnboardingWebsite.Models
{
    public class ExperienceVM
    {
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public string ReasonForLeaving { get; set; }
        public int TotalNoofMonths { get; set; }
        public string? ExperienceCerti { get; set; }
    }
}
