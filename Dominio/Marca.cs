using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Winform
{
    public class Marca
    {
        public string Nombre { get; set; }

        public Marca(string nombre) {

            Nombre = nombre;
        
        }

        public override string ToString()
        {
            return Nombre;
        }


    }


}
