using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet
{
    public class Card
    {
        public String nro = "", codSeguridad = "";
        public byte month;
        public int year;
        public Card()
        { }
        public Card(String _nro, String _codSeguridad, byte _month, int _year)
        {
            nro = _nro;
            codSeguridad = _codSeguridad;
            month = _month;
            year = _year;
        }
    }
}
