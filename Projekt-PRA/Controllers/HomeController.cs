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
    public class HomeController : Controller
    {        
        IList<Knjiga> knjige;
        IList<Autor> autori;
        KnjigaManager knjigaManager;
        AutorManager autorManager;
        PosudbaManager posudbaManager;
        NarudzbaManager narudzbaManager;

        // GET: Home
        [HttpGet]
        public ActionResult Index(string search, string ddlNumber, string sort)
        {
            knjigaManager = new KnjigaManager();
            autorManager = new AutorManager();

            knjige = new List<Knjiga>();
            knjige = knjigaManager.GetAll();


            autori = new List<Autor>();
            autori = autorManager.GetAll();

            ViewBag.Knjige = knjige;
            ViewBag.Autori = autori;

            

            if (!String.IsNullOrEmpty(ddlNumber))
            {
                IList<Knjiga> knjige2 = new List<Knjiga>();

                switch (ddlNumber)
                {
                    case "0":
                        for (int i = 0; i < 10; i++)
                        {
                            knjige2.Add(knjige[i]);
                        }
                        knjige = knjige2;
                        ViewBag.Knjige = knjige2;
                        break;
                    case "1":
                        for (int i = 0; i < 15; i++)
                        {
                            knjige2.Add(knjige[i]);
                        }
                        knjige = knjige2;
                        ViewBag.Knjige = knjige2;
                        break;
                    case "2":
                        for (int i = 0; i < 20; i++)
                        {
                            knjige2.Add(knjige[i]);
                        }
                        knjige = knjige2;
                        ViewBag.Knjige = knjige2;
                        break;
                };
            }

            if (!String.IsNullOrEmpty(search))
            {
                ViewBag.Knjige = knjige.Where(x => x.Naslov.Contains(search)).ToList();
            }

            if (!String.IsNullOrEmpty(sort))
            {
                ViewBag.Knjige = Sortiraj(knjige, sort);
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            Knjiga knjiga = new Knjiga();
            knjigaManager = new KnjigaManager();
            knjiga = knjigaManager.Get(id);
            ViewBag.Knjiga = knjiga;


            return View(knjiga);
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Contact(MailModel e)
        {
            if (!ModelState.IsValid)
            {
                return View(e);
            }

            string senderEmail = "praprojekt@gmail.com";
            string senderPassword = "aaokecjcnxsyqxnx";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 100000;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            MailMessage mailMessage = new MailMessage(e.Email, senderEmail, e.Subject, e.Message);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            smtpClient.Send(mailMessage);
            return RedirectToAction("Index", "Home");
        }


        private IList<Knjiga> Sortiraj(IList<Knjiga> knjige, string pickedSort)
        {
            switch (pickedSort)
            {
                case "Abecedno":
                    knjige = knjige.OrderBy(k => k.Naslov).ToList();
                    break;                    
                case "Najčitanije":
                    knjige = SortirajPoCitanosti(knjige);
                    break;                
                default:
                    break;
            }

            return knjige;
        }

        private IList<Knjiga> SortirajPoNovitetima(IList<Knjiga> knjige)
        {
            throw new NotImplementedException();
        }

        private IList<Knjiga> SortirajPoCitanosti(IList<Knjiga> knjige)
        {
            posudbaManager = new PosudbaManager();
            narudzbaManager = new NarudzbaManager();
            IList<Narudzba> sveNarudzbe = new List<Narudzba>();
            sveNarudzbe = narudzbaManager.GetAll();
            IList<Posudba> svePosudbe = posudbaManager.GetAll();

            Dictionary<Knjiga, int> citanostKnjige = new Dictionary<Knjiga, int>();            

            foreach (Knjiga knjiga in knjige)
            {
                int brojPosudbiINarudzbi = 0;
                foreach (Narudzba narudzba in sveNarudzbe)
                {
                    if (knjiga.IDKnjiga == narudzba.KnjigaID)
                    {
                        brojPosudbiINarudzbi++;                        
                    }
                }
                foreach (Posudba posudba in svePosudbe)
                {
                    if (knjiga.IDKnjiga == posudba.KnjigaID)
                    {
                        brojPosudbiINarudzbi++;
                    }
                }

                citanostKnjige.Add(knjiga, brojPosudbiINarudzbi);               
            }

            var sortedDict = from entry in citanostKnjige orderby entry.Value descending select entry;

            IList<Knjiga> knjigePoCitanosti = new List<Knjiga>();
            foreach (var knjiga in sortedDict)
            {
                knjigePoCitanosti.Add(knjiga.Key);
            }

            return knjigePoCitanosti;
        }
    }
}