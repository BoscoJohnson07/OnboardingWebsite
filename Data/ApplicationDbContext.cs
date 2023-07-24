using Microsoft.EntityFrameworkCore;

namespace OnboardingWebsite.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }



        public DbSet<Login> Logins { get; set; }
        public DbSet<EmployeeGeneralDetails> EmployeeGeneralDetails { get; set; }   
        public DbSet<EmployeeContactDetails> EmployeeContactDetails { get; set; }
        public DbSet<EmployeeAddressDetails> EmployeeAddressDetails { get; set; }
        public DbSet<EmployeeAdditionalInfo> EmployeeAdditionalInfo { get; set; }
        public DbSet<EmployeeEducationDetails> EmployeeEducationDetails { get; set; }
        public DbSet<EmployeeExperienceDetails> EmployeeExperienceDetails { get; set; }
        public DbSet<ApprovalStatus> Approvals { get; set; }
        //public DbSet<Roles> Roles { get; set; }
        //public DbSet<UserRoles> UserRoles { get; set; }
    }
}
