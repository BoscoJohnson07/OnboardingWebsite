using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
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

        public async Task DeleteEmployee(string[] employeeId)
        {
            for(int i = 0;i<employeeId.Count();i++)
            {
                if (employeeId != null)
                {
                    var login=_context.Logins.FirstOrDefault(l=>l.Empid== employeeId[i]);
                    var general = _context.EmployeeGeneralDetails.FirstOrDefault(g => g.Empid == employeeId[i]);
                    var contact = _context.EmployeeContactDetails.FirstOrDefault(c => c.Empid == employeeId[i]);
                    var address = _context.EmployeeAddressDetails.FirstOrDefault(a => a.Empid == employeeId[i]);
                    var addtional = _context.EmployeeAdditionalInfo.FirstOrDefault(ad => ad.Empid == employeeId[i]);
                    var education = _context.EmployeeEducationDetails.FirstOrDefault(ed => ed.Empid == employeeId[i]);
                    var experience = _context.EmployeeExperienceDetails.FirstOrDefault(ex => ex.Empid == employeeId[i]);
                    var approval = _context.Approvals.FirstOrDefault(app => app.Empid == employeeId[i]);
                    if (login!=null && general != null && contact != null && address != null && addtional != null && education != null & education != null && experience != null && approval != null)
                    {
                        login.Status = "D";
                        login.Date_Modified = DateTime.UtcNow;
                        login.Modified_by = "Admin";
                        general.Status = "D";
                        general.Date_Modified= DateTime.UtcNow;
                        general.Modified_by = "Admin";
                        contact.Status = "D";
                        contact.Date_Modified = DateTime.UtcNow;
                        contact.Modified_by = "Admin";
                        address.Status = "D";
                        address.Date_Modified = DateTime.UtcNow;
                        address.Modified_by = "Admin";
                        addtional.Status = "D";
                        addtional.Date_Modified = DateTime.UtcNow;
                        addtional.Modified_by = "Admin";
                        education.Status = "D";
                        education.Date_Modified = DateTime.UtcNow;
                        education.Modified_by = "Admin";
                        experience.Status = "D";
                        experience.Date_Modified = DateTime.UtcNow;
                        experience.Modified_by = "Admin";
                        approval.Status = "D";
                        approval.Date_Modified = DateTime.UtcNow;
                        approval.Modified_by = "Admin";
                        _context.SaveChanges();
                    }
                }
            }
        }
        public async Task< List<DashboardVM>> GetEmployeeDetails()
        {

            var deg = (from e in _context.EmployeeGeneralDetails where e.Status=="A" 
                       join ee in _context.EmployeeEducationDetails on e.Empid equals ee.Empid where ee.Status=="A" select ee.Passoutyear).Max();
            var employeedetails = (from e in _context.EmployeeGeneralDetails where e.Status=="A"
                                   join a in _context.Approvals on e.Empid equals a.Empid where a.Status=="A" && a.Approved==null && a.Cancelled==null
                                   join l in _context.Logins on e.Empid equals l.Empid where l.Status=="A"
                                   join ec in _context.EmployeeContactDetails on e.Empid equals ec.Empid where ec.Status=="A"
                                   join ee in _context.EmployeeEducationDetails on e.Empid equals ee.Empid where ee.Passoutyear == deg && ee.Status=="A"
                                   select new DashboardVM()
                                   {
                                       Empid = e.Empid,
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
            var address = (from e in _context.EmployeeGeneralDetails where e.Empid == employeeid join ea in _context.EmployeeAddressDetails on e.Empid equals ea.Empid select ea).ToArray();
            var degree = (from e in _context.EmployeeGeneralDetails where e.Empid == employeeid join ee in _context.EmployeeEducationDetails on e.Empid equals ee.Empid select ee).ToArray();
            var experiencecount = (from e in _context.EmployeeGeneralDetails where e.Empid == employeeid join eed in _context.EmployeeExperienceDetails on e.Empid equals eed.Empid select eed).ToArray();
            var employeepersonal = (from e in _context.EmployeeGeneralDetails
                                    where e.Empid == employeeid
                                    join ea in _context.EmployeeAddressDetails on e.Empid equals ea.Empid
                                    join ec in _context.EmployeeContactDetails on e.Empid equals ec.Empid
                                    join ead in _context.EmployeeAdditionalInfo on e.Empid equals ead.Empid
                                    select new PersonalInfoVM()
                                    {
                                        Empid = e.Empid,
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
                                            Certificate =GetFile( degree[0].Certificate)
                                        },
                                        PGDetails = new EducationDetailsVM()
                                        {
                                            CollegeName = degree[1].CollegeName,
                                            Degree = degree[1].Degree,
                                            Major = degree[1].specialization,
                                            PassedoutYear = degree[1].Passoutyear,
                                            Certificate = GetFile(degree[1].Certificate)
                                        },
                                        experienceVMs=Experrience(employeeid)
                                    }).ToList();
           
            return employeepersonal;
        }
        public List<ExperienceVM> Experrience(string employeeid)
        {
            List<ExperienceVM> exVM = new List<ExperienceVM>();
            var experiencecount = (from e in _context.EmployeeGeneralDetails where e.Empid == employeeid join eed in _context.EmployeeExperienceDetails on e.Empid   equals eed.Empid select eed);
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
                    ExperienceCerti=GetFile(experience.Exp_Certificate)
                });
            }
            return exVM;
        }

        public byte[] GetFile(string filepath)
        {
            if (System.IO.File.Exists(filepath))
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(filepath);
                byte[] file = new byte[fs.Length];
                int br = fs.Read(file, 0, file.Length);
                if (br != fs.Length)
                {
                    throw new IOException("Invalid path");
                }
                return file;
            }
            return null;   
        }
    }
}
