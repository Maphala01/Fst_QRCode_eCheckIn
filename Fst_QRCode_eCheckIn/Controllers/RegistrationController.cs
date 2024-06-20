using Fst_QRCode_eCheckIn.Models;
using Fst_QRCode_eCheckIn.Data;
using System.Web.Mvc;

namespace Fst_QRCode_eCheckIn.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View(new RegistrationMdl());
        }

        [HttpPost]
        public ActionResult SubmitRegistration(RegistrationMdl model)
        {
            if (ModelState.IsValid)
            {
                // Save model data to the database using DatabaseAccess class
                var dbAccess = new DatabaseAccess();
                dbAccess.SaveRegistration(model);

                // For demonstration purposes, let's return the model to the view
                ViewBag.Message = "Registration successful!";
                return View("Index", model);
            }

            // If we got this far, something failed, redisplay form
            return View("Index", model);
        }
    }
}