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
    public class AdminProfileController : Controller
    {
        // GET: AdminProfile
        public ActionResult Index()
        {
            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            DjelatnikManager djelatnikManager = new DjelatnikManager();
            Djelatnik djelatnik = (Djelatnik)Session["djelatnik"];

            return View();
        }

        [HttpGet]
        public ActionResult NewAdmin()
        {
            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult NewBook()
        {
            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Loans()
        {
            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            PosudbaManager posudbaManager = new PosudbaManager();
            IList<Posudba> posudbe = posudbaManager.GetAll();

            return View(posudbe);
        }

        [HttpGet]
        public ActionResult BookReturned(int orderID)
        {
            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            PosudbaManager posudbaManager = new PosudbaManager();
            posudbaManager.ReturnBook(orderID);

            return RedirectToAction("Loans");

        }

        [HttpGet]
        public ActionResult DeleteLoan(int orderID)
        {
            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            PosudbaManager posudbaManager=new PosudbaManager();
            Posudba posudba = new Posudba();
            posudba.IDPosudbe = orderID;
            posudbaManager.Delete(posudba);

            return RedirectToAction("Loans");
        }

        [HttpGet]
        public ActionResult List()
        {
            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            KnjigaManager knjigaManager = new KnjigaManager();
            IList<Knjiga> knjige = knjigaManager.GetAll();
            return View(knjige);
        }

        [HttpGet]
        public ActionResult Edit(int bookID)
        {

            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            KnjigaManager knjigaManager = new KnjigaManager();
            AutorManager autorManager = new AutorManager();
            Knjiga knjiga = knjigaManager.Get(bookID);
            NewKnjiga editKnjiga = new NewKnjiga();
            Autor autor = autorManager.Get(knjiga.AutorID);
            editKnjiga.Naslov = knjiga.Naslov;
            editKnjiga.ISBN = knjiga.ISBN;
            editKnjiga.Autor = autor.Ime + " " + autor.Prezime;
            editKnjiga.CijenaKupnja = knjiga.CijenaKupnja;
            editKnjiga.CijenaPosudba = knjiga.CijenaPosudba;
            editKnjiga.Opis = knjiga.Opis;
            editKnjiga.PutanjaSlika = knjiga.PutanjaSlika;
            editKnjiga.Kolicina = knjiga.Kolicina;
            editKnjiga.IDKnjiga = knjiga.IDKnjiga;

            return View(editKnjiga);
        }

        [HttpGet]
        public ActionResult Delete(int bookID)
        {

            if (Session["djelatnik"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            KnjigaManager knjigaManager = new KnjigaManager();
            Knjiga knjiga = new Knjiga();
            knjiga.IDKnjiga = bookID;

            knjigaManager.Delete(knjiga);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(NewKnjiga novaKnjiga)
        {
            if (!ModelState.IsValid)
            {
                return View(novaKnjiga);
            }

            AutorManager autorManager = new AutorManager();
            KnjigaManager knjigaManager = new KnjigaManager();
            Autor autor = new Autor();
            autor.Ime = novaKnjiga.Autor.Split()[0];
            autor.Prezime = novaKnjiga.Autor.Split()[1];
            autor.OAutoru = "0";

            Knjiga knjiga = new Knjiga();
            knjiga.Naslov = novaKnjiga.Naslov;
            knjiga.ISBN = novaKnjiga.ISBN;
            knjiga.CijenaKupnja = novaKnjiga.CijenaKupnja;
            knjiga.CijenaPosudba = novaKnjiga.CijenaPosudba;
            knjiga.PutanjaSlika = novaKnjiga.PutanjaSlika;
            knjiga.Kolicina = novaKnjiga.Kolicina;

            knjiga.AutorID = autorManager.GetAutorID(novaKnjiga.Autor.Split()[0], novaKnjiga.Autor.Split()[1]);
            if (knjiga.AutorID == 0)
            {
                autorManager.Create(autor);
                knjiga.AutorID = autorManager.GetAutorID(novaKnjiga.Autor.Split()[0], novaKnjiga.Autor.Split()[1]);
            }

            knjiga.IDKnjiga = novaKnjiga.IDKnjiga;

            knjigaManager.Update(knjiga);

            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult NewBook(NewKnjiga model)
        {
            if (ModelState.IsValid)
            {
                AutorManager autorManager = new AutorManager();
                KnjigaManager knjigaManager = new KnjigaManager();
                Autor autor;
                string v = model.ToString();
                string a = model.Autor;
                int idautor;
                string[] splitted = a.Split(' ');
                try
                {
                    autor = new Autor { Ime = splitted[0], Prezime = splitted[1], OAutoru = "0" };
                    autorManager.Create(autor);
                    idautor = autorManager.GetAutorID(autor.Ime, autor.Prezime);


                }
                catch (Exception)
                {
                    return View();
                }
                Knjiga newKnjiga = new Knjiga
                {
                    CijenaKupnja = model.CijenaKupnja,
                    Naslov = model.Naslov,
                    Kolicina = model.Kolicina,
                    Opis = model.Opis,
                    ISBN = model.ISBN,
                    PutanjaSlika = model.PutanjaSlika,
                    CijenaPosudba = model.CijenaPosudba,
                    AutorID = idautor
                };


                knjigaManager.Create(newKnjiga);
                return RedirectToAction("Index", "AdminProfile");

            }
            return View();
        }


        [HttpPost]
        public ActionResult NewAdmin(NewDjelatnik model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Email.Split('@')[1].ToString() != "knjizara.hr")
            {
                ViewBag.Email = 1;
                return View(model);
            }
            else 
            {
                ViewBag.Email = 0;
            }

            DjelatnikManager djelatnikManager = new DjelatnikManager();
            Djelatnik djelatnik = new Djelatnik();
            djelatnik.Ime = model.Ime;
            djelatnik.Prezime = model.Prezime;
            djelatnik.OIB = model.OIB;
            djelatnik.Email = model.Email;
            djelatnik.RadnoMjesto = model.RadnoMjesto;
            djelatnik.Pozicija = model.Pozicija;


            djelatnikManager.Create(djelatnik, model.Password);
            ViewBag.Success = 1;

            return View();
        }

        [HttpPost]
        public ActionResult PasswordReset(string password)
        {
            if (!String.IsNullOrEmpty(password))
            {
                DjelatnikManager djelatnikManager= new DjelatnikManager();
                Djelatnik djelatnik = (Djelatnik)Session["djelatnik"];
                djelatnikManager.DjelatnikPasswordReset(password, djelatnik.IDDjelatnik);
                return Json(true);
            }

            return View();
        }


    }
}