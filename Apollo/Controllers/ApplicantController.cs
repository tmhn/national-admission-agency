using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apollo.Data;
using Apollo.Services;
using Apollo.Services.Service;
using Apollo.Data.BEANS;

namespace Apollo.Controllers
{
    
    [RequireHttps]
    public class ApplicantController : Controller
    {

        private ApolloService _applicantService;

        public ApplicantController()
        {
            _applicantService = new ApolloService();
        }

        public ActionResult GetUserProfile(string UserId)
        {

            return View(_applicantService.GetUserProfile(UserId));
        }

        // Shows list of Applicants
        public ActionResult ApplicantList()
        {
            return View(_applicantService.GetApplicantList());
        }


        // Shows applicant's profile
        public ActionResult ApplicantProfile(int Id)
        {
            return View(_applicantService.GetApplicantProfile(Id));
        }

        // Add Applicant

        public ActionResult AddApplicant(string Email, string UserId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddApplicant(Applicant_Profile applicant)
        {
            try
            {
                _applicantService.AddApplicant(applicant);
                return RedirectToAction("ApplicantList", new { id = applicant.ApplicantId });
            }
            catch
            {
                return View();
            }
        }

        // Edit Applicant

        [HttpGet]
        public ActionResult EditApplicant(int Id, string userId, string applicantName)
        {
            ViewBag.ApplicantName = applicantName;
            ViewBag.UserId = userId;
            Applicant_Profile applicant = _applicantService.GetApplicantProfile(Id);
            return View(applicant);
        }

        [HttpPost]
        public ActionResult EditApplicant(Applicant_Profile applicant)
        {
            if(String.IsNullOrEmpty(applicant.ApplicantName))
            {
                ModelState.AddModelError("ApplicantName", "Please enter a name");
            }
            if (String.IsNullOrEmpty(applicant.ApplicantAddress))
            {
                ModelState.AddModelError("ApplicantAddress", "Please enter an address");
            }
            if (String.IsNullOrEmpty(applicant.Phone))
            {
                ModelState.AddModelError("Phone", "Please enter a phone number");
            }
            if (String.IsNullOrEmpty(applicant.Email))
            {
                ModelState.AddModelError("Email", "Please enter an email address");
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _applicantService.EditApplicant(applicant);
                    return RedirectToAction("GetUserProfile", new { UserId = applicant.UserId, Controller = "Applicant" });
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult ApplicationList(string applicantName, int applicantId)
        {
            ViewBag.ApplicantId = applicantId;
            ViewBag.ApplicantName = applicantName;
            return View(_applicantService.GetApplicationList(applicantId));
        }

        public ActionResult ApplicationDetails(int applicationId)
        {
            return View(_applicantService.ApplicationDetails(applicationId));
        }

        [HttpGet]
        public ActionResult DeleteApplication(int applicationId, int applicantId, string applicantName)
        {
            ViewBag.ApplicantId = applicantId;
            ViewBag.ApplicantName = applicantName;
            //ApplicationBEAN applicationBean = _applicantService.ApplicationDetails(applicationId);
            Application application = _applicantService.GetUniversityApplication(applicationId);
            return View(application);
        }
        [HttpPost]
        public ActionResult DeleteApplication(Application application)
        {
            try
            {
                _applicantService.DeleteApplication(application);
                return RedirectToAction("ApplicationList", new { applicantId = application.ApplicantId, applicantName = ViewBag.ApplicantName });
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult EditApplication(int applicationId, string courseName, string universityName, string universityOffer)
        {
            ViewBag.UniversityOffer = universityOffer;
            ViewBag.CourseName = courseName;
            ViewBag.UniversityName = universityName;
            ApplicationBEAN applicationBean = _applicantService.ApplicationDetails(applicationId);
            return View(applicationBean);
        }


        [HttpPost]
        public ActionResult EditApplication(ApplicationBEAN applicationBean)
        {
            if (String.IsNullOrEmpty(applicationBean.PersonalStatement))
            {
                ModelState.AddModelError("PersonalStatement", "Personal Statement Needs Some Text");
            }
            if (String.IsNullOrEmpty(applicationBean.TeacherReference))
            {
                ModelState.AddModelError("TeacherReference", "Please enter a teacher reference");
            }
            if (String.IsNullOrEmpty(applicationBean.TeacherContactDetails))
            {
                ModelState.AddModelError("TeacherContactDetails", "Please enter teacher contact details");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _applicantService.EditApplication(applicationBean);
                    return RedirectToAction("ApplicationList", new { applicantId = applicationBean.ApplicantId, applicantName = applicationBean.ApplicantName });
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        
        public ActionResult GetStudentApplication(int applicationId)
        {
            return View(_applicantService.GetStudentApplication(applicationId));
        }

        public ActionResult CreateApplication(int UniversityId, string CourseName, string UniversityName, int ApplicantId)
        {
            ViewBag.ApplicantId = ApplicantId;
            ViewBag.UniversityId = UniversityId;
            ViewBag.UniversityName = UniversityName;
            ViewBag.CourseName = CourseName;
            return View();
        }


        [HttpPost]
        public ActionResult CreateApplication(ApplicationBEAN application)
        {
            if(String.IsNullOrEmpty(application.PersonalStatement))
            {
                ModelState.AddModelError("PersonalStatement", "Personal Statement Needs Some Text");
            }
            if (String.IsNullOrEmpty(application.TeacherReference))
            {
                ModelState.AddModelError("TeacherReference", "Please enter a teacher reference");
            }
            if (String.IsNullOrEmpty(application.TeacherContactDetails))
            {
                ModelState.AddModelError("TeacherContactDetails", "Please enter teacher contact details");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _applicantService.AddApplication(application);
                    return RedirectToAction("ApplicationList", new { applicantId = application.ApplicantId });
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    
        //------------Auto gen----------------------------

        // GET: Applicant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Applicant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applicant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Applicant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Applicant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Applicant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applicant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
