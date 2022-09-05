using praLib.Managers;
using praLib.Models;
using praLib.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projekt_PRA.Controllers
{
    public class LoanController : Controller
    {
        Knjiga knjiga = new Knjiga();
        // GET: Loan
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
                ViewBag.Knjiga = knjiga;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


            return View();
        }


        [HttpPost]
        public ActionResult Index(LoanModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model.payment == "Gotovina")
            {
                ViewBag.Success = true;
                Kupac kupac = Session["kupac"] as Kupac;

                int knjigaID = (int)Session["knjiga"];

                PosudbaManager posudbaManager = new PosudbaManager();
                Posudba posudba = new Posudba();
                posudba.KupacID = kupac.IDKupac;
                posudba.KnjigaID = knjigaID;
                posudba.DatumPosudbe = model.orderDate;
                posudba.DatumVracanja = model.returnDate;
                posudba.VrstaPlacanja = model.payment;
                posudbaManager.Create(posudba);
                posudbaManager.UsedBook(knjigaID);

                string senderEmail = "praprojekt@gmail.com";
                string senderPassword = "aaokecjcnxsyqxnx";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 100000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                // Kupac email
                MailMessage mailMessage = new MailMessage(senderEmail, "praprojekt@gmail.com", "Posudba knjige", "Poštovani, Vaša posudba je zaprimljena te je možete pokupiti u najbližoj poslovnici.");
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                smtpClient.Send(mailMessage);
            }




            return View();
        }

    }
}