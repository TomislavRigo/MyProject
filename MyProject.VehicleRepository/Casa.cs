using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.VehicleMakeRepository
{
    public class Casa
    {
        public Casa(int visina, int sirina, string materijal)
        {
            this.visina = visina;
            this.sirina = sirina;
            this.materijal = materijal;

            var tip = NapraviCasu();
        }
        public int visina { get; set; }
        public int sirina { get; set; }
        public string materijal { get; set; }

        private bool NapraviCasu()
        {
            if (visina != 0 && sirina != 0 && string.IsNullOrEmpty(materijal))
            {
                return true;
            }
            return false;
        }
        public class drugaklasa
        {
            Casa aabc = new Casa(25,23,"sdasd");
        }   
    }
}
