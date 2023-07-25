using OnboardingWebsite.Models;

namespace OnboardingWebsite.Contracts
{
    public interface IAdminRepository
    {
       List<DasboardVM> GetEmployeeDetails();
    }
}
