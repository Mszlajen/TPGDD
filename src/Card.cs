using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet
{
    class Card
    {
        public String nro, codSeguridad;
        public Card()
        { }
        public Card(String _nro, String _codSeguridad)
        {
            nro = _nro;
            codSeguridad = _codSeguridad;
        }
    }
}
