using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Actividad2
{
    class L_Articulo
    {
        


        public List<E_Articulo> listar() //Funcion para listar articulos
        {

            List<E_Articulo> lista = new List<E_Articulo>(); // instanciamos la lista
            SqlConnection conexion = new SqlConnection(); // instanciamos la conexion a la base
            SqlCommand comando = new SqlCommand();  // instanciamos el comando para ejecutar las query
            SqlDataReader lector; // No se instancia
        
            try
            {
                //Conexion para base de datos con declaracion de usuario especifico con login de sql
                conexion.ConnectionString = "Server=ULARIAGA-BRAIAN\\LOCALHOST; Database= CATALOGO_P3_DB; User Id= sa; Password=Super123.adm ";
                //Conexion para base de datos local con login de wind
                //conexion.ConnectionString = "Server=.\\SQLEXPRESS;  Database= CATALOGO_P3_DB; integrated security= true"; 
                comando.CommandType = System.Data.CommandType.Text; // Tipo de comando a ajecutar en el SQL, text(query), storeproceduire(SP)
                comando.CommandText = "select Codigo, Nombre, Descripcion from ARTICULOS"; //Declaramos el query
                comando.Connection = conexion; //Nos conectamos

                conexion.Open(); // abrimos conexion

                lector  = comando.ExecuteReader(); // Leemos el reusltado del query

                while (lector.Read())
                {
                   E_Articulo aux = new E_Articulo(); // creamos el objeto para guardar los datos que leemos

                    aux.Codigo = (string)lector["Codigo"]; //Indicamos el objeto con el dato a leer y parseamos el dato ya que lo lee como obj
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    lista.Add(aux); // agregamos el objeto leido a la lista

                }

                conexion.Close(); // cerramos conexion

                return lista;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
