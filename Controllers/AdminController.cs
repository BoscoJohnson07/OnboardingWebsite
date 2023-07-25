using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardingWebsite.Contracts;
using OnboardingWebsite.Data;
using OnboardingWebsite.Models;

namespace OnboardingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminRepository _adminRepository;
        public AdminDashboardController(ApplicationDbContext context,IAdminRepository adminRepository)
        {
            _context = context;
            _adminRepository = adminRepository;
        }

        [HttpGet("api/AdminDashboard")]
        public ActionResult<List<DasboardVM>> getEMployee() 
        {
            return _adminRepository.GetEmployeeDetails().ToList();
        }


    }
}
