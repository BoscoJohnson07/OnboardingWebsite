using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnboardingWebsite.Contracts;
using OnboardingWebsite.Data;
using OnboardingWebsite.Models;

namespace OnboardingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminRepository _adminRepository;
        public AdminController(ApplicationDbContext context,IAdminRepository adminRepository)
        {
            _context = context;
            _adminRepository = adminRepository;
        }

        [HttpGet("api/AdminDashboard")]
        public async Task <List<DashboardVM>> getEmployee() 
        {
            return await _adminRepository.GetEmployeeDetails();
        }

        [HttpPost("api/AdminDeleteById")]
        public async Task deleteEmployee(string[] employeeid)
        {
            await _adminRepository.DeleteEmployee(employeeid);
        }

        [HttpPost("api/GetEmployeeDetails")]
        public async Task <List<PersonalInfoVM>> GetPersonalInfo(string employee)
        {
            return await _adminRepository.GetPersonalInfo(employee);
        }
    }
}
