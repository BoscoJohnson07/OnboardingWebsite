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
        public async Task <List<DashboardVM>> getEMployee() 
        {
            return await _adminRepository.GetEmployeeDetails();
        }


    }
}
