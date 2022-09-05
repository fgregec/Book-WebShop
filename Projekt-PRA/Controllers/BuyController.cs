using praLib.Managers;
using praLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projekt_PRA.Controllers
{
    public class BuyController : Controller
    {
        // GET: Buy
        Knjiga knjiga = new Knjiga();


        public ActionResult Index(int id)
        {
            
            if (Session["kupac"] != null)
            {
                KnjigaManager knjigaManager = new KnjigaManager();
                knjiga = knjigaManager.Get(id);
                Session["knjiga"] = knjiga.IDKnjiga;
                Kupac kupac = Session["kupac"] as Kupac;
                ViewBag.Ime = kupac.Ime;
                ViewBag.Prezime = kupac.Prezime;
                ViewBag.Adresa = kupac.PostanskaAdresa;
                ViewBag.City = kupac.Grad;
                ViewBag.Knjiga = knjiga;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(BuyModel model)
        {

            if (model.payment == "Gotovina")
            {
                ViewBag.Success = true;
                Kupac kupac = Session["kupac"] as Kupac;
                NarudzbaManager narudzbaManager = new NarudzbaManager();
                KnjigaManager knjigaManager = new KnjigaManager();
                Narudzba narudzba = new Narudzba();
                int knjigaID = (int)Session["knjiga"];
                narudzba.KupacID = kupac.IDKupac;
                narudzba.KnjigaID = knjigaID;
                narudzba.DatumKupnje = DateTime.Now;
                narudzba.VrstaPlacanja = "Gotovina";
                narudzbaManager.Create(narudzba);
                knjigaManager.RemoveOneBook(knjigaID);


                string senderEmail = "praprojekt@gmail.com";
                string senderPassword = "aaokecjcnxsyqxnx";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 100000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                // Kupac email
                MailMessage mailMessage = new MailMessage(senderEmail, "praprojekt@gmail.com", "Narudžba knjige", "Poštovani, Vaša narudžba je zaprimljena te je možete pokupiti u najbližoj poslovnici.");
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                smtpClient.Send(mailMessage);
            }




            return View();
        }
    }
}