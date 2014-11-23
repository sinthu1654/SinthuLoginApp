using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SinthuLoginApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                //if (model.Username == "Sinthu" && model.Password == "1234")
                if (DataAccess.DAL.IsValidUser(model.Username, model.Password ))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false); 
                    //change to true, so browser remembers the user login session
                    return RedirectToAction("index", "home");
                }
                {
                    ModelState.AddModelError("", "Invalid Username / Password");
                }
            }
            return View();
        }
    }
}
