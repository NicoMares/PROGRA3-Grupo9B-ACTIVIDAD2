using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Actividad2.Entidades;

namespace Actividad2
{
    class E_Articulo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public E_Marca Marca { get; set; }
        public E_Categoria Categoria { get; set; }



    }
}
