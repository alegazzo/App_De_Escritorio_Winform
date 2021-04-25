using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Winform
{
    public class Categoria
    {
        public string Nombre { get; set; }

        public Categoria(string name) {

            Nombre = name;

        }

        public override string ToString()
        {
            return Nombre;
        }


    }
}
