using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class L_Validacion
    {


        public bool EsSoloTexto(string input)
        {
            return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
    }
}
