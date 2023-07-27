namespace OnboardingWebsite.Models
{
    public class PersonalInfoVM
    {
        public string Empid { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public string mailId { get; set; }
        public string MaritialStatus { get; set; }
        public DateTime? DOM { get; set; }
        public string Gender { get; set; }
        public double Contactno { get; set; }
        public string? ECP { get; set; }
        public string? ECR { get; set; }
        public double? ECN { get; set; }
        public AddressVM PermanentAddress { get; set; }
        public AddressVM TemporaryAddress { get; set; }

        public string CovidSts { get; set; }
        public string? CovidCerti { get; set; }
        public EducationDetailsVM UGDetails { get; set; }
        public EducationDetailsVM PGDetails { get; set; }
        public ExperienceVM[] experienceVMs { get; set; }
    }
}
