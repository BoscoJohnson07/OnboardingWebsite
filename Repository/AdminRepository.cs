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
        public async Task< List<DashboardVM>> GetEmployeeDetails()
        {

            var deg = (from e in _context.EmployeeGeneralDetails where e.Status=="A" join ee in _context.EmployeeEducationDetails on e.EmpID equals ee.Empid where ee.Status=="A" select ee.Passoutyear).Max();
            var employeedetails = (from e in _context.EmployeeGeneralDetails where e.Status=="A"
                                   join a in _context.Approvals on e.EmpID equals a.Empid where a.Status=="A" && a.Approved==null && a.Cancelled==null
                                   join l in _context.Logins on e.EmployeeName equals l.Name where l.Status=="A"
                                   join ec in _context.EmployeeContactDetails on e.EmpID equals ec.Empid where ec.Status=="A"
                                   join ee in _context.EmployeeEducationDetails on e.EmpID equals ee.Empid where ee.Passoutyear == deg && ee.Status=="A"
                                   select new DashboardVM()
                                   {
                                       Empid = e.EmpID,
                                       Empname = e.EmployeeName,
                                       designation = l.Designation,
                                       Contact = ec.Contact_no,
                                       Email = l.Emailid,
                                       education = ee.Degree
                                   }).ToList();
            return employeedetails;
        }
    }
}
