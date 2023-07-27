using OnboardingWebsite.Data;
using OnboardingWebsite.Models;

namespace OnboardingWebsite.Contracts
{
    public interface IAdminRepository
    {
      Task <List<DashboardVM>> GetEmployeeDetails();
      Task DeleteEmployee(string employeeId);   
        
        Task <List<PersonalInfoVM>>? GetPersonalInfo(string employeeid);
    }
}
