using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using OnboardingUser.Data.Services;
using OnboardingWebsite.Models;

namespace OnboardingUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public EducationService _educationService;
        public UserController(EducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost("add-UG-education")]
        public IActionResult AddEducationUG([FromBody] EducationVM education)
        {
            _educationService.AddEducationUG(education);

            return Ok();
        }

        [HttpPost("add-PG-education")]
        public IActionResult AddEducationPG([FromForm] EducationVM education)
        {
            _educationService.AddEducationPG(education);   
            return Ok();
        }


        [HttpGet("get-UG-education/{id}")]
        public IActionResult GetEducationUG(int id)
        {
            var education = _educationService.GetEducationUG(id);
            return Ok(education);
        }

        [HttpGet("get-PG-education/{id}")]
        public IActionResult GetEducationPG(int id)
        {
            var education = _educationService.GetEducationPG(id);
            return Ok(education);
        }
    }
}
