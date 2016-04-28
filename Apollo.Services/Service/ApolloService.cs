using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollo.Services.IService;
using Apollo.Data;
using Apollo.Data.DAO;
using Apollo.Services.Service;
using Apollo.Data.BEANS;
using Apollo.Services.BEANS;

using Apollo.Services.SheffieldHallamWebService;
using Apollo.Services.SheffieldUniWebService;

namespace Apollo.Services.Service
{
    public class ApolloService : IApolloService
    {
        private ApolloDAO _apolloDAO;

        private SheffieldHallamWebService.SHUWebService _sheffieldHallamWebProxy;
        private SheffieldUniWebService.SheffieldUniCourses _sheffieldUniWebProxy;

        public ApolloService()
        {
            _apolloDAO = new ApolloDAO();

            _sheffieldHallamWebProxy = new SheffieldHallamWebService.SHUWebService();
            _sheffieldUniWebProxy = new SheffieldUniWebService.SheffieldUniCourses();

        }

        public IList<Applicant_Profile> GetApplicantList()
        {
            return _apolloDAO.GetApplicantList();
        }

        public Applicant_Profile GetApplicantProfile(int Id)
        {
            return _apolloDAO.GetApplicantProfile(Id);
        }

        public Applicant_Profile GetUserProfile(string UserId)
        {
            return _apolloDAO.GetUserProfile(UserId);
        }

        public Application GetUniversityApplication(int applicationId)
        {
            return _apolloDAO.GetUniversityApplication(applicationId);
        }
        public IList<ApplicationBEAN> GetApplicantApplications(int Id)
        {
            return _apolloDAO.GetApplicationList(Id);
        }

        public void AddApplicant(Applicant_Profile applicant)
        {
            _apolloDAO.AddApplicant(applicant);
        }

        public ApplicationBEAN ApplicationDetails(int applicationId)
        {
            return _apolloDAO.ApplicationDetails(applicationId);
        }

        public void AddApplication(ApplicationBEAN application)
        {
            _apolloDAO.AddApplication(application);
        }



        public void DeleteApplication(Application application)
        {
            _apolloDAO.DeleteApplication(application);
        }
        public void EditApplication(ApplicationBEAN applicationBean)
        {
            _apolloDAO.EditApplication(applicationBean);
        }

        public void EditApplicant(Applicant_Profile applicant)
        {
            _apolloDAO.EditApplicant(applicant);
        }

        public IList<ApplicationBEAN> GetApplicationList(int Id)
        {
            return _apolloDAO.GetApplicationList(Id);
        }

        public IList<University> GetUniversityList()
        {
            return _apolloDAO.GetUniversityList();
        }

        public IList<University> GetUniversityListAuth()
        {
            return _apolloDAO.GetUniversityListAuth();
        }


// Third submission ----------------------------------

        public IList<ApplicationBEAN> GetUniversityApplications(int Id)
        {
            return _apolloDAO.GetUniversityApplications(Id);
        }

        public IList<ApplicationBEAN> GetStudentApplications(int UniversityId, int StudentId)
        {
            return _apolloDAO.GetStudentApplications(UniversityId, StudentId);
        }

        public IList<ApplicationBEAN> GetStudentApplication(int ApplicationId)
        {
            return _apolloDAO.GetStudentApplication(ApplicationId);
        }

        public void UpdateStudentApplication(int ApplicationId, string UniversityOffer)
        {
            _apolloDAO.UpdateStudentApplication(ApplicationId, UniversityOffer);
        }


        public University GetUniversity(int universityId)
        {
            return _apolloDAO.GetUniversity(universityId);
        }

        public IList<CourseBEAN> GetUniversityCourses(Int32 UniversityId)
        {
           if(UniversityId.Equals(1))
           {
               return GetSheffieldHallamCourses();
           } 
            else if(UniversityId.Equals(2))
           {
               return GetSheffieldUniversityCourses();
           }
           else
           {
               return null;
           }
            
        }

        // Authenticated Users
        public IList<CourseBEAN> GetUniversityCoursesAuth(Int32 UniversityId)
        {
            if (UniversityId.Equals(1))
            {
                return GetSheffieldHallamCourses();
            }
            else if (UniversityId.Equals(2))
            {
                return GetSheffieldUniversityCourses();
            }
            else
            {
                return null;
            }
        }

        public IList<CourseBEAN> GetSheffieldHallamCourses()
        {
            
            List<CourseBEAN> _CourseBean = new List<CourseBEAN>();
            IList<CourseList> _SheffieldHallamCourses = _sheffieldHallamWebProxy.GetAllCourses();

            foreach (CourseList _CourseItem in _SheffieldHallamCourses)
            {
                CourseBEAN courseBean = new CourseBEAN();
                courseBean.CourseBEANId = _CourseItem.CourseId;
                courseBean.CourseBEANName = _CourseItem.CourseName;
                courseBean.CourseBEANDescription = _CourseItem.CourseDescription;
                courseBean.CourseBEANEntryRequirements = _CourseItem.EntryCriteria;

                _CourseBean.Add(courseBean);
            }

            return _CourseBean;
        }

        public IList<CourseBEAN> GetSheffieldUniversityCourses()
        {
            List<CourseBEAN> _CourseBean = new List<CourseBEAN>();
            IList<Course> _SheffieldUniversityCourses = _sheffieldUniWebProxy.GetCoursesFullDetails();

            foreach (Course _CourseItem in _SheffieldUniversityCourses)
            {
                CourseBEAN courseBean = new CourseBEAN();
                courseBean.CourseBEANId = _CourseItem.Id;
                courseBean.CourseBEANName = _CourseItem.Name;
                courseBean.CourseBEANDescription = _CourseItem.Description;
                courseBean.CourseBEANEntryRequirements = _CourseItem.Tarif.ToString();

                _CourseBean.Add(courseBean);
            }

            return _CourseBean;
        }

// Staff Account

        public void AddUniversity(University university)
        {
            _apolloDAO.AddUniversity(university);
        }

        public IList<University> StaffUniversityList()
        {
            return _apolloDAO.StaffUniversityList();
        }

        public University StaffUniversityDetails(int universityId)
        {
            return _apolloDAO.StaffUniversityDetails(universityId);
        }

        public void EditUniversity(University university)
        {
            _apolloDAO.EditUniversity(university);
        }

        public void DeleteUniversity(University university)
        {
            _apolloDAO.DeleteUniversity(university);
        }

        public void DeleteApplicant(Applicant_Profile applicant)
        {
            _apolloDAO.DeleteApplicant(applicant);
        }

        public void EditStaff(Applicant_Profile applicant)
        {
            _apolloDAO.EditApplicant(applicant);
        }
    }
}
