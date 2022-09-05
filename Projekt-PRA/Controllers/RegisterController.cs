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
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            if (Session["kupac"] != null || Session["djelatnik"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModel m)
        {
            if (!ModelState.IsValid)
            {
                return View(m);
            }
            if (m.Email.Split('@')[1] == "knjizara.hr")
            {
                return View(m);
            }
            ViewBag.Success = true;

            KupacManager kupacManager = new KupacManager();
            Kupac kupac = new Kupac();

            kupac.Ime = m.FName;
            kupac.Prezime = m.LName;
            kupac.DatumRodenja = m.BirthDate.ToShortDateString();
            kupac.PostanskaAdresa = m.Address;
            try
            {
                kupac.PostanskiBroj = int.Parse(m.PostNumber);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
            kupac.Grad = m.City;
            string password = m.Password;
            kupac.Email = m.Email;

            kupacManager.NewKupac(kupac, password);


            return View();
        }


    }
}