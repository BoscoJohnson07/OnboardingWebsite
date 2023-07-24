namespace OnboardingWebsite.Data
{
    public class Login : BaseEntity
    {
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
    }
}
