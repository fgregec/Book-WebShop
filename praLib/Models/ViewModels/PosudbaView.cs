using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praLib.Models.ViewModels
{
    public class PosudbaView
    {
        public PosudbaView(Knjiga knjiga, Posudba posudba)
        {
            this.knjiga = knjiga;
            this.posudba = posudba;
        }

        public Knjiga knjiga { get; set; }
        public Posudba posudba { get; set; }
    }
}
