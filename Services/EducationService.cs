using OnboardingWebsite.Data;
using OnboardingWebsite.Models;

namespace OnboardingUser.Data.Services
{
    public class EducationService
    {
        private ApplicationDbContext _context;
        public EducationService(ApplicationDbContext context)
        {
            _context = context;   
        }

        public void AddEducationUG(EducationVM education)
        {
            var _education = new EmployeeEducationDetails()
            {
                programme = "UG",
                CollegeName = education.CollegeName,
                Degree = education.Degree,
                specialization = education.specialization,
                Passoutyear = education.Passoutyear,

            };
            _context.EmployeeEducationDetails.Add(_education);
            _context.SaveChanges();
        }

        /*     public void AddEducationPG(EducationVM education)
             {
                 var _education = new EmployeeEducationDetails()
                 {
                     programme = "PG",
                     CollegeName = education.CollegeName,
                     Degree = education.Degree,
                     specialization = education.specialization,
                     Passoutyear = education.Passoutyear
                 };
                 _context.EmployeeEducationDetails.Add(_education);
                 _context.SaveChanges();
             }
        */

        public void AddEducationPG(EducationVM education)
        {
            if (education.Certificate == null || education.Certificate.Length == 0)
            {
                throw new ArgumentException("Certificate file is missing.");
            }

            // Validate file size
            const int maxSizeKB = 100;
            const int minSizeKB = 50;
            if (education.Certificate.Length > maxSizeKB * 1024 || education.Certificate.Length < minSizeKB * 1024)
            {
                throw new ArgumentException($"Certificate file size should be between {minSizeKB} KB and {maxSizeKB} KB.");
            }

            // Validate file type (MIME type)
            if (education.Certificate.ContentType != "application/pdf")
            {
                throw new ArgumentException("Only PDF files are allowed.");
            }

            var _education = new EmployeeEducationDetails()
            {
                programme = "PG",
                CollegeName = education.CollegeName,
                Degree = education.Degree,
                specialization = education.specialization,
                Passoutyear = education.Passoutyear,
                Certificate = SaveCertificateFile(education.Certificate) // Save the certificate file and get its file path
            };

            _context.EmployeeEducationDetails.Add(_education);
            _context.SaveChanges();
        }

        private string SaveCertificateFile(IFormFile certificateFile)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Certificates", "PG_education.pdf");

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                certificateFile.CopyTo(fileStream);
            }

            return filePath; // Return the file path
        }


        public EducationVM GetEducationUG(int educationId)
        {
            var _education = _context.EmployeeEducationDetails.Where(n => n.Id == educationId).Select(education => new EducationVM()
            {
                programme = "UG",
                CollegeName = education.CollegeName,
                Degree = education.Degree,
                specialization = education.specialization,
                Passoutyear = education.Passoutyear
            }).FirstOrDefault();

            return _education;
        }

        public EducationVM GetEducationPG(int educationId)
        {
            var _education = _context.EmployeeEducationDetails.Where(n => n.Id == educationId).Select(education => new EducationVM()
            {
                programme = "PG",
                CollegeName = education.CollegeName,
                Degree = education.Degree,
                specialization = education.specialization,
                Passoutyear = education.Passoutyear
            }).FirstOrDefault();

            return _education;
        }

    }
}
