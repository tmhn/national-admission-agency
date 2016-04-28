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
    public class StaffController : Controller
    {
        private ApolloService _apolloService;

        public StaffController()
        {
            _apolloService = new ApolloService();
        }

        public ActionResult Index(string userId)
        {
            return View(_apolloService.GetUserProfile(userId));
        }

        public ActionResult AddUniversity( string userId)
        {
            ViewBag.UserId = userId;
            //ViewBag.ApplicantId = applicantId;
            return View();
        }

        [HttpPost]
        public ActionResult AddUniversity(University university)
        {
            try
            {
                string userId = ViewBag.UserId;
                _apolloService.AddUniversity(university);
                return RedirectToAction("StaffUniversityList", new { userId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult StaffUniversityList(string userId)
        {
            ViewBag.UserId = userId;
            //ViewBag.ApplicantId = applicantId;
            return View(_apolloService.StaffUniversityList());
        }

        public ActionResult Details(Int32 universityId, string userId)
        {
            ViewBag.UserId = userId;
            return View(_apolloService.StaffUniversityDetails(universityId));
        }

        public ActionResult EditStaff(int applicantId, string userId, string applicantName)
        {
            ViewBag.ApplicantId = applicantId;
            ViewBag.UserId = userId;
            ViewBag.ApplicantName = applicantName;
            Applicant_Profile applicant = _apolloService.GetApplicantProfile(applicantId);
            return View(applicant);
        }

        [HttpPost]
        public ActionResult EditStaff(Applicant_Profile applicant)
        {
            try
            {
                _apolloService.EditStaff(applicant);
                return RedirectToAction("Index", new { UserId = applicant.UserId});
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Edit(int universityId, string userId)
        {
            ViewBag.UserId = userId;
            ViewBag.UniversityId = universityId;
            University university = _apolloService.GetUniversity(universityId);
            return View(university);
        }

        [HttpPost]
        public ActionResult Edit(University university)
        {
            try
            {
                // TODO: Add update logic here
                _apolloService.EditUniversity(university);
                return RedirectToAction("StaffUniversityList", new { ViewBag.ApplicantId, ViewBag.UserId });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

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



        public ActionResult Delete(int universityId, string userId)
        {
            ViewBag.UserId = userId;
            ViewBag.UniversityId = universityId;
            University university = _apolloService.GetUniversity(universityId);
            return View(university);
        }

        [HttpPost]
        public ActionResult Delete(University university)
        {
            try
            {
                _apolloService.DeleteUniversity(university);
                return RedirectToAction("StaffUniversityList", new { ViewBag.ApplicantId, ViewBag.UserId });
            }
            catch
            {
                return View();
            }
        }
    }
}
