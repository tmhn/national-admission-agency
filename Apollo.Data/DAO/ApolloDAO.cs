using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollo.Data.IDAO;
using Apollo.Data.BEANS;

namespace Apollo.Data.DAO
{
    public class ApolloDAO : IApolloDAO
    {
        private ApolloEntities _context;

        public ApolloDAO()
        {
            _context = new ApolloEntities();
        }

        public IList<Applicant_Profile> GetApplicantList()
        {
            IQueryable<Applicant_Profile> _profiles;
            _profiles = from profile
                        in _context.Applicant_Profile
                        select profile;
            return _profiles.ToList<Applicant_Profile>();
        }


        public Applicant_Profile GetApplicantProfile(int Id)
        {
            IQueryable<Applicant_Profile> _applicantProfile;
            _applicantProfile = from applicantProfile
                                in _context.Applicant_Profile
                                where applicantProfile.ApplicantId == Id
                                select applicantProfile;
            return _applicantProfile.ToList<Applicant_Profile>().First();
        }

        public Applicant_Profile GetUserProfile(string UserId)
        {
            IQueryable<Applicant_Profile> _applicantProfile;
            _applicantProfile = from applicantProfile
                                in _context.Applicant_Profile
                                where applicantProfile.UserId == UserId
                                select applicantProfile;
            return _applicantProfile.ToList<Applicant_Profile>().First();
        }

        /*public IList<ApplicationBEAN> GetApplicantApplications(int Id)
        //{
        //    IQueryable<Application> _applicantApplications;
        //    _applicantApplications = from applicantApplications
        //                             in _context.Application
        //                             where applicantApplications.ApplicantId == Id
        //                             select applicantApplications;
        //    return _applicantApplications.ToList<Application>().ToList();
        //}*/


        // View ApplicationDetails - When viewing list of Applications, shows specific item
        public ApplicationBEAN ApplicationDetails(int ApplicationId)
        {
            IQueryable<ApplicationBEAN> _ApplicationBEANs;
            _ApplicationBEANs = from application in _context.Application
                                from profile in _context.Applicant_Profile
                                from uni in _context.University
                                where application.ApplicantId == profile.ApplicantId
                                where application.ApplicationId == ApplicationId
                                where application.UniversityId == uni.UniversityId
                                select new ApplicationBEAN
                                {
                                    ApplicantId = profile.ApplicantId,
                                    ApplicantName = profile.ApplicantName,
                                    ApplicantAddress = profile.ApplicantAddress,
                                    Phone = profile.Phone,
                                    Email = profile.Email,
                                    UserId = profile.UserId,
                                    ApplicationId = application.ApplicationId,
                                    CourseName = application.CourseName,
                                    UniversityName = uni.UniversityName,
                                    UniversityId = application.UniversityId,
                                    PersonalStatement = application.PersonalStatement,
                                    TeacherReference = application.TeacherReference,
                                    TeacherContactDetails = application.TeacherContactDetails,
                                    UniversityOffer = application.UniversityOffer,
                                    Firm = application.Firm
                                };
            return _ApplicationBEANs.ToList<ApplicationBEAN>().First();
        }

        public IList<ApplicationBEAN> GetApplicationList(int Id)
        {
            IQueryable<ApplicationBEAN> _ApplicationBEANs;
            _ApplicationBEANs = from apps in _context.Application
                                from prof in _context.Applicant_Profile
                                from uni in _context.University
                                where apps.ApplicantId == Id
                                where prof.ApplicantId == Id
                                where apps.UniversityId == uni.UniversityId
                                select new ApplicationBEAN
                                {
                                    ApplicantId = prof.ApplicantId,
                                    ApplicantName = prof.ApplicantName,
                                    ApplicantAddress = prof.ApplicantAddress,
                                    Phone = prof.Phone,
                                    Email = prof.Email,
                                    UserId = prof.UserId,
                                    ApplicationId = apps.ApplicationId,
                                    CourseName = apps.CourseName,
                                    UniversityId = apps.UniversityId,
                                    UniversityName = uni.UniversityName,
                                    PersonalStatement = apps.PersonalStatement,
                                    TeacherReference = apps.TeacherReference,
                                    TeacherContactDetails = apps.TeacherContactDetails,
                                    UniversityOffer = apps.UniversityOffer,
                                    Firm = apps.Firm
                                };
            return _ApplicationBEANs.ToList<ApplicationBEAN>();
        }


        public Application GetUniversityApplication(int applicationId)
        {
            IQueryable<Application> _application;
            _application = from Application
                           in _context.Application
                           where applicationId == Application.ApplicationId
                           select Application;
            return _application.ToList<Application>().First();
        }


        public void AddApplicant(Applicant_Profile applicant)
        {
            _context.Applicant_Profile.Add(applicant);
            _context.SaveChanges();
        }

        public void AddApplication(ApplicationBEAN applicationBEAN)
        {
            //Take in a BEAN and then assign to the correct table

            Application application = new Application();

            //application.ApplicationId = applicationBEAN.ApplicationId;
            application.ApplicantId = applicationBEAN.ApplicantId;
            application.CourseName = applicationBEAN.CourseName;
            application.UniversityId = applicationBEAN.UniversityId;
            application.PersonalStatement = applicationBEAN.PersonalStatement;
            application.TeacherReference = applicationBEAN.TeacherReference;
            application.TeacherContactDetails = applicationBEAN.TeacherContactDetails;
            //application.UniversityOffer = applicationBEAN.UniversityOffer;
            application.Firm = applicationBEAN.Firm;

            _context.Application.Add(application);
            _context.SaveChanges();
        }

        public void EditApplication(ApplicationBEAN applicationBean)
        {
            Application application = (from app
                                       in _context.Application
                                       where app.ApplicationId == applicationBean.ApplicationId
                                       select app).ToList<Application>().First();
            
            application.PersonalStatement = applicationBean.PersonalStatement;
            application.TeacherReference = applicationBean.TeacherReference;
            application.TeacherContactDetails = applicationBean.TeacherContactDetails;
            application.Firm = applicationBean.Firm;
            _context.SaveChanges();
        }

        public void DeleteApplication(Application application)
        {
            Application _application = (from app
                                        in _context.Application
                                        where app.ApplicationId == application.ApplicationId
                                        select app).ToList<Application>().First();
            _context.Application.Remove(_application);
            _context.SaveChanges();
        }

        public void EditApplicant(Applicant_Profile applicant)
        {
            Applicant_Profile _applicant = (from app
                                            in _context.Applicant_Profile
                                            where app.ApplicantId == applicant.ApplicantId
                                            select app).ToList<Applicant_Profile>().First();
            _applicant.ApplicantName = applicant.ApplicantName;
            _applicant.ApplicantAddress = applicant.ApplicantAddress;
            _applicant.Phone = applicant.Phone;
            _applicant.Email = applicant.Email;
            _context.SaveChanges();
        }

        public IList<University> GetUniversityList()
        {
            IQueryable<University> _universities;
            _universities = from university
                            in _context.University
                            select university;
            return _universities.ToList<University>();
        }

        public IList<University> GetUniversityListAuth()
        {
            IQueryable<University> _universities;
            _universities = from university
                            in _context.University
                            select university;
            return _universities.ToList<University>();
        }

// Third submission Methods

        public IList<ApplicationBEAN> GetUniversityApplications(int Id)
        {
            IQueryable<ApplicationBEAN> _ApplicationBEANs;
            _ApplicationBEANs = from application in _context.Application
                                from profile in _context.Applicant_Profile
                                where application.UniversityId == Id
                                where application.ApplicantId == profile.ApplicantId
                                select new ApplicationBEAN
                                {
                                    ApplicantId = profile.ApplicantId,
                                    ApplicantName = profile.ApplicantName,
                                    ApplicantAddress = profile.ApplicantAddress,
                                    Phone = profile.Phone,
                                    Email = profile.Email,
                                    UserId = profile.UserId,
                                    ApplicationId = application.ApplicationId,
                                    CourseName = application.CourseName,
                                    UniversityId = application.UniversityId,
                                    PersonalStatement = application.PersonalStatement,
                                    TeacherReference = application.TeacherReference,
                                    TeacherContactDetails = application.TeacherContactDetails,
                                    UniversityOffer = application.UniversityOffer,
                                    Firm = application.Firm
                                };
            return _ApplicationBEANs.ToList<ApplicationBEAN>();
        }

        public IList<ApplicationBEAN> GetStudentApplications(int UniversityId, int StudentId)
        {
            IQueryable<ApplicationBEAN> _ApplicationBEANs;
            _ApplicationBEANs = from application in _context.Application
                                from profile in _context.Applicant_Profile
                                where application.UniversityId == UniversityId
                                where application.ApplicantId == profile.ApplicantId
                                where profile.ApplicantId == StudentId


                //from application in _context.Application
                //                from profile in _context.Applicant_Profile

                //                where application.UniversityId == UniversityId
                //                where application.ApplicantId == profile.ApplicantId
                //                where application.ApplicantId == StudentId
                //                where profile.ApplicantId == StudentId

                                select new ApplicationBEAN
                                {
                                    ApplicantId = profile.ApplicantId,
                                    ApplicantName = profile.ApplicantName,
                                    ApplicantAddress = profile.ApplicantAddress,
                                    Phone = profile.Phone,
                                    Email = profile.Email,
                                    UserId = profile.UserId,
                                    ApplicationId = application.ApplicationId,
                                    CourseName = application.CourseName,
                                    UniversityId = application.UniversityId,
                                    PersonalStatement = application.PersonalStatement,
                                    TeacherReference = application.TeacherReference,
                                    TeacherContactDetails = application.TeacherContactDetails,
                                    UniversityOffer = application.UniversityOffer,
                                    Firm = application.Firm
                                };
            return _ApplicationBEANs.ToList<ApplicationBEAN>();
        }

        public IList<ApplicationBEAN> GetStudentApplication(int ApplicationId)
        {
            IQueryable<ApplicationBEAN> _ApplicationBEANs;
            _ApplicationBEANs = from application in _context.Application
                                from profile in _context.Applicant_Profile
                                where application.ApplicantId == profile.ApplicantId
                                where application.ApplicationId == ApplicationId
                                select new ApplicationBEAN
                                {
                                    ApplicantId = profile.ApplicantId,
                                    ApplicantName = profile.ApplicantName,
                                    ApplicantAddress = profile.ApplicantAddress,
                                    Phone = profile.Phone,
                                    Email = profile.Email,
                                    UserId = profile.UserId,
                                    ApplicationId = application.ApplicationId,
                                    CourseName = application.CourseName,
                                    UniversityId = application.UniversityId,
                                    PersonalStatement = application.PersonalStatement,
                                    TeacherReference = application.TeacherReference,
                                    TeacherContactDetails = application.TeacherContactDetails,
                                    UniversityOffer = application.UniversityOffer,
                                    Firm = application.Firm
                                };
            return _ApplicationBEANs.ToList<ApplicationBEAN>();
        }

        public void UpdateStudentApplication(int ApplicationId, string UniversityOffer)
        {
            Application _application = (from app
                                        in _context.Application
                                        where app.ApplicationId == ApplicationId
                                        select app).ToList<Application>().First();
            _application.UniversityOffer = UniversityOffer;
            _context.SaveChanges();

        }


// Staff Account

        public void AddUniversity(University university)
        {
            _context.University.Add(university);
            _context.SaveChanges();
        }

        public IList<University> StaffUniversityList()
        {
            IQueryable<University> _universities;
            _universities = from university
                            in _context.University
                            select university;
            return _universities.ToList<University>();
        }

        public University StaffUniversityDetails(int universityId)
        {
            IQueryable<University> _university;
            _university = from university
                          in _context.University
                          where universityId == university.UniversityId
                          select university;
            return _university.ToList<University>().First();
        }

        public University GetUniversity(int universityId)
        {
            IQueryable<University> _university;
            _university = from university
                          in _context.University
                          where universityId == university.UniversityId
                          select university;
            return _university.ToList<University>().First();
        }

        public void EditUniversity(University university)
        {
            University _university = (from uni
                                      in _context.University
                                      where uni.UniversityId == university.UniversityId
                                      select uni).ToList<University>().First();
            _university.UniversityName = university.UniversityName;
            _context.SaveChanges();
        }

        public void DeleteUniversity(University university)
        {
            University _university = (from uni
                                     in _context.University
                                     where uni.UniversityId == university.UniversityId
                                     select uni).ToList<University>().First();
            _context.University.Remove(_university);
            _context.SaveChanges();
        }

        public void DeleteApplicant(Applicant_Profile applicant)
        {
            Applicant_Profile _applicant = (from appl
                                            in _context.Applicant_Profile
                                            where appl.ApplicantId == applicant.ApplicantId
                                            select appl).ToList<Applicant_Profile>().First();
            _context.Applicant_Profile.Remove(_applicant);
            _context.SaveChanges();
        }
    }
}