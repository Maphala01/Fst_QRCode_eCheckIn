
using Fst_QRCode_eCheckIn.Models;
using Fst_QRCode_eCheckIn.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fst_QRCode_eCheckIn.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly DatabaseAccess _dbAccess;

        public RegistrationController()
        {
            _dbAccess = new DatabaseAccess();
        }

        // GET: Registration
        public ActionResult Index()
        {
            ViewBag.Departments = _dbAccess.GetDepartments();
            ViewBag.Employees = _dbAccess.GetEmployees();
            return View();
        }

        [HttpGet]
        public JsonResult GetDepartments(string term)
        {
            var departments = _dbAccess.GetDepartmentsByTerm(term);
            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmployees(string term)
        {
            var employees = _dbAccess.GetEmployeesByTerm(term);
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubmitRegistration(RegistrationMdl model)
        {
            if (ModelState.IsValid)
            {
                _dbAccess.SaveRegistration(model);
                ViewBag.Message = "Registration successful!";
                return View("Index", model);
            }
            return View("Index", model);
        }
    }
}
