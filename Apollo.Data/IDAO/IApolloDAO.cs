using Apollo.Data.BEANS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.Data.IDAO
{
    interface IApolloDAO
    {
        IList<Applicant_Profile> GetApplicantList();

        void AddApplicant(Applicant_Profile applicant);

        void AddApplication(ApplicationBEAN applicationBEAN);

        
        ApplicationBEAN ApplicationDetails(int applicationId);

        Applicant_Profile GetApplicantProfile(int Id);

        Applicant_Profile GetUserProfile(string UserId);

        void EditApplicant(Applicant_Profile applicant);


        IList<University> GetUniversityList();

        IList<University> GetUniversityListAuth();

// Third submission methods

        IList<ApplicationBEAN> GetApplicationList(int Id);

        Application GetUniversityApplication(int applicationId);

        IList<ApplicationBEAN> GetUniversityApplications(int Id);

        IList<ApplicationBEAN> GetStudentApplications(int UniversityId, int StudentId);

        IList<ApplicationBEAN> GetStudentApplication(int ApplicationId);

        void UpdateStudentApplication(int ApplicationId, string UniversityOffer);


// Staff account
        void AddUniversity(University university);

        IList<University> StaffUniversityList();

        University StaffUniversityDetails(int universityId);

        University GetUniversity(int universityId);

        void EditUniversity(University university);

        void DeleteUniversity(University university);

        void DeleteApplicant(Applicant_Profile applicant);

        //void EditStaff(Applicant_Profile applicant);


        void DeleteApplication(Application application);

    }
}
