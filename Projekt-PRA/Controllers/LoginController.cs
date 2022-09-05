using praLib.Managers;
using praLib.Models;
using praLib.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt_PRA.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["kupac"] != null)
            {
                Session["kupac"] = null;
                Session.Clear();
                Session.RemoveAll();
            }

            if (Session["djelatnik"] != null)
            {
                Session["djelatnik"] = null;
                Session.Clear();
                Session.RemoveAll();
            }

            return View();
        }



        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Djelatnik djelatnik;
            Kupac kupac;

            KupacManager kupacManager = new KupacManager();
            DjelatnikManager djelatnikManager = new DjelatnikManager();

            string email = model.email;
            string[] details = email.Split('@');

            if (details[1] == "knjizara.hr")
            {
                djelatnik = djelatnikManager.AuthDjelatnik(model.email, Cryptography.HashPassword(model.password));
                if (djelatnik == null)
                {
                    return View();
                }
                Session["djelatnik"] = djelatnik;
                return RedirectToAction("Index", "AdminProfile");
            }
            else
            {
                kupac = kupacManager.AuthKupac(model.email, Cryptography.HashPassword(model.password));
                if (kupac == null)
                {
                    return View();
                }
                Session["kupac"] = kupac;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}