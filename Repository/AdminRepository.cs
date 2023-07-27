using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnboardingWebsite.Contracts;
using OnboardingWebsite.Data;
using OnboardingWebsite.Models;
using System.Data.Entity.Core.Objects;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OnboardingWebsite.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteEmployee(string employeeId)
        {
            if(employeeId != null) 
            {
               /* (from e in _context.EmployeeGeneralDetails where e.Status == "A"
                 join a in _context.Approvals on e.EmpID equals a.Empid where a.Status == "A"
                 join l in _context.Logins on e.EmployeeName equals l.Name where l.Status == "A"
                 join ec in _context.EmployeeContactDetails on e.EmpID equals ec.Empid where ec.Status == "A"
                 join ee in _context.EmployeeEducationDetails on e.EmpID equals ee.Empid where ee.Status == "A"
                 join ead in _context.EmployeeAddressDetails on e.EmpID equals ead.Empid where ead.Status == "A"
                 join eed in _context.EmployeeExperienceDetails on e.EmpID equals eed.Empid where eed.Status=="A"
                 join ea in _context.EmployeeAdditionalInfo on e.EmpID equals ea.Empid where ea.Status=="A"
                 ).ToList().ForEach() ;*/
            }
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
            return  employeedetails;
        }

        public async Task<List<PersonalInfoVM>>? GetPersonalInfo(string employeeid)
        {
            var address = (from e in _context.EmployeeGeneralDetails where e.EmpID == employeeid join ea in _context.EmployeeAddressDetails on e.EmpID equals ea.Empid select ea).ToArray();
            var degree = (from e in _context.EmployeeGeneralDetails where e.EmpID == employeeid join ee in _context.EmployeeEducationDetails on e.EmpID equals ee.Empid select ee).ToArray();
            var experiencecount = (from e in _context.EmployeeExperienceDetails where e.Empid == employeeid join eed in _context.EmployeeExperienceDetails on e.Empid equals eed.Empid select eed).ToArray();
            var employeepersonal = (from e in _context.EmployeeGeneralDetails
                                    where e.EmpID == employeeid
                                    // join ea in _context.EmployeeAddressDetails on e.EmpID equals ea.Empid
                                    join ec in _context.EmployeeContactDetails on e.EmpID equals ec.Empid
                                    join ead in _context.EmployeeAdditionalInfo on e.EmpID equals ead.Empid
                                    select new PersonalInfoVM()
                                    {
                                        Empid = e.EmpID,
                                        EmpName = e.EmployeeName,
                                        FatherName = e.FatherName,
                                        DOB = e.DOB,
                                        mailId = ec.Personal_Emailid,
                                        MaritialStatus = e.MaritalName,
                                        DOM = e.DateOfMarriage,
                                        Contactno = ec.Contact_no,
                                        Gender = e.Gender,
                                        ECP = ec.Emgy_Contactperson,
                                        ECR = ec.Emgy_Contactrelation,
                                        ECN = ec.Emgy_Contactno,
                                        PermanentAddress = new AddressVM()
                                        {
                                            Address = address[0].Address,
                                            Country = address[0].Country,
                                            City = address[0].City,
                                            State = address[0].State,
                                            Pincode = address[0].Pincode
                                        },
                                        TemporaryAddress = new AddressVM()
                                        {
                                            Address = address[1].Address,
                                            Country = address[1].Country,
                                            City = address[1].City,
                                            State = address[1].State,
                                            Pincode = address[1].Pincode
                                        },
                                        CovidSts = ead.Covid_VaccSts,
                                        CovidCerti = ead.Vacc_Certificate,
                                        UGDetails = new EducationDetailsVM()
                                        {
                                            CollegeName = degree[0].CollegeName,
                                            Degree = degree[0].Degree,
                                            Major = degree[0].specialization,
                                            PassedoutYear = degree[0].Passoutyear,
                                            Certificate = degree[0].Certificate
                                        },
                                        PGDetails = new EducationDetailsVM()
                                        {
                                            CollegeName = degree[1].CollegeName,
                                            Degree = degree[1].Degree,
                                            Major = degree[1].specialization,
                                            PassedoutYear = degree[1].Passoutyear,
                                            Certificate = degree[1].Certificate
                                        },
                                        experienceVMs=Experrience(employeeid)
                                    }).ToList();
           
            return employeepersonal;
        }
        public List<ExperienceVM> Experrience(string employeeid)
        {
            List<ExperienceVM> exVM = new List<ExperienceVM>();
            var experiencecount = (from e in _context.EmployeeGeneralDetails where e.EmpID == employeeid join eed in _context.EmployeeExperienceDetails on e.EmpID equals eed.Empid select eed);
            foreach (var experience in experiencecount)
            {
                exVM.Add(new ExperienceVM()
                {
                    CompanyName = experience.Company_name,
                    StartDate = (DateTime)experience.StartDate,
                    EndDate = (DateTime)experience.EndDate,
                    Designation = experience.Designation,
                    TotalNoofMonths = experience.Totalmonths,
                    ReasonForLeaving=experience.Reason,
                    ExperienceCerti=experience.Exp_Certificate
                });
            }
            return exVM;
        }
    }
}
