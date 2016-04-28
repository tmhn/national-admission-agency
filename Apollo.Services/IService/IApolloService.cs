using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollo.Data;
using Apollo.Data.BEANS;
using Apollo.Services.BEANS;

namespace Apollo.Services.IService
{
    interface IApolloService
    {
        IList<Applicant_Profile> GetApplicantList();

        void AddApplicant(Applicant_Profile applicant);

        void AddApplication(ApplicationBEAN applicationBEAN);

        
        void EditApplication(ApplicationBEAN applicationBean);

        void DeleteApplication(Application application);
        ApplicationBEAN ApplicationDetails(int applicationId);
        Applicant_Profile GetApplicantProfile(int Id);

        Applicant_Profile GetUserProfile(string UserId);

        Application GetUniversityApplication(int applicationId);

        void EditApplicant(Applicant_Profile applicant);

        IList<ApplicationBEAN> GetApplicationList(int Id);

        IList<University> GetUniversityList();

        IList<University> GetUniversityListAuth();

// Third submission methods
        IList<ApplicationBEAN> GetUniversityApplications(int Id);

        IList<ApplicationBEAN> GetStudentApplications(int UniversityId, int StudentId);

        IList<ApplicationBEAN> GetStudentApplication(int ApplicationId);

        void UpdateStudentApplication(int ApplicationId, string UniversityOffer);

        IList<CourseBEAN> GetUniversityCourses(Int32 UniversityId);

        IList<CourseBEAN> GetUniversityCoursesAuth(Int32 UniversityId);

// Staff Account
        void AddUniversity(University university);

        IList<University> StaffUniversityList();

        University StaffUniversityDetails(int universityId); 
        
        University GetUniversity(int universityId);

        void EditUniversity(University university);

        void DeleteUniversity(University university);

        void DeleteApplicant(Applicant_Profile applicant);

        void EditStaff(Applicant_Profile applicant);
    }
}
