using praLib.Managers;
using praLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Dal
{
    public static class RepoFactory
    {
        public static IRepo<Knjiga> GetBookManager() => new KnjigaManager();
        public static IRepo<Autor> GetAutorManager() => new AutorManager();
        public static IRepo<Djelatnik> GetDjelatnikManager() => new DjelatnikManager();
        public static IRepo<Kupac> GetKupacManager() => new KupacManager();
        public static IRepo<Narudzba> GetNarudzbaManager() => new NarudzbaManager();
        public static IRepo<Posudba> GetPosudbaManager() => new PosudbaManager();
    }
}
