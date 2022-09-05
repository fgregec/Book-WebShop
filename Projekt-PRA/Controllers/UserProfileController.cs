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
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            if (Session["kupac"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Kupac kupac = new Kupac();
            kupac = Session["kupac"] as Kupac;
            UserProfileEditModel model = new UserProfileEditModel();
            model.fName = kupac.Ime;
            model.lName = kupac.Prezime;
            model.oldBirthDate = kupac.DatumRodenja;
            model.address = kupac.PostanskaAdresa;
            model.city = kupac.Grad;
            model.cityPostNumber = kupac.PostanskiBroj;

            NarudzbaManager narudzbaManager = new NarudzbaManager();
            KnjigaManager knjigaManager = new KnjigaManager();
            PosudbaManager posudbaManager = new PosudbaManager();
            IList<Narudzba> narudzbe = narudzbaManager.GetAllUserOrders(kupac.IDKupac);
            List<Knjiga> knjige = new List<Knjiga>();
            IList<Posudba> posudbe = posudbaManager.GetAllUserLoans(kupac.IDKupac);
            List<PosudbaView> posudbaView = new List<PosudbaView>();

            foreach (Narudzba narudzba in narudzbe)
            {
                knjige.Add(knjigaManager.Get(narudzba.KnjigaID));
            }

            foreach (Posudba posudba in posudbe)
            {
                PosudbaView temp = new PosudbaView(knjigaManager.Get(posudba.KnjigaID), posudba);
                posudbaView.Add(temp);
            }


            model.orderList = knjige;
            model.loanList = posudbaView;

            return View(model);
        }

        [HttpPost]
        public ActionResult PasswordReset(string password)
        {
            if (!String.IsNullOrEmpty(password))
            {
                KupacManager kupacManager = new KupacManager();
                Kupac kupac = new Kupac();
                kupac = Session["kupac"] as Kupac;
                kupacManager.KupacPasswordReset(password, kupac.IDKupac);
                return Json(true);
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditData(UserProfileEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            KupacManager kupacManager = new KupacManager();
            Kupac stari = new Kupac();
            stari = Session["kupac"] as Kupac;

            Kupac kupac = new Kupac();
            kupac.IDKupac = stari.IDKupac;
            kupac.Ime = model.fName;
            kupac.Prezime = model.lName;
            kupac.DatumRodenja = model.newBirthDate;
            kupac.PostanskaAdresa = model.address;
            kupac.Grad = model.city;
            kupac.PostanskiBroj = model.cityPostNumber;
            kupac.Email = stari.Email;

            kupacManager.Update(kupac);
            Session["kupac"] = kupac;

            return RedirectToAction("Index");
        }
    }
}