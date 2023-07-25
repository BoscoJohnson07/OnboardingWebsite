using OnboardingWebsite.Contracts;
using OnboardingWebsite.Data;
using OnboardingWebsite.Models;
using System.Linq;

namespace OnboardingWebsite.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<DasboardVM> GetEmployeeDetails()
        {
            var employeedetails = (from e in _context.EmployeeGeneralDetails
                                   join l in _context.Logins on e.EmployeeName equals l.Name
                                   join ec in _context.EmployeeContactDetails on e.EmpID equals ec.Empid
                                   join ee in _context.EmployeeEducationDetails on e.EmpID equals ee.Empid
                                   select new DasboardVM()
                                   {
                                       Empid = e.EmpID,
                                       Empname = e.EmployeeName,
                                       designation = l.Designation,
                                       Contact = ec.Contact_no,
                                       Email = l.Emailid,
                                       education =ee.Degree
                                   }).ToList();
            return employeedetails;
        }
    }
}
