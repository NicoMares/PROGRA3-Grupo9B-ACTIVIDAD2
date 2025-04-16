using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Actividad2
{
    class E_Articulo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        public int IDCategoria { get; set; }
        public decimal Precio { get; set; }
        public int IdMarca { get; set; }
       
        public  List<string> Imagen { get; set; }



    }
}
