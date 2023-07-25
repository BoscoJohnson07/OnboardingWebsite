using OnboardingWebsite.Models;

namespace OnboardingWebsite.Contracts
{
    public interface IAdminRepository
    {
      Task <List<DashboardVM>> GetEmployeeDetails();
    }
}
