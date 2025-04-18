using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
using Entidades;
using Logica.Logica;

namespace Logica
{
    public class L_Articulo
    {
        

        /*
        public List<E_Articulo> listar() //Funcion para listar articulos
        {

            List<E_Articulo> lista = new List<E_Articulo>(); // instanciamos la lista
            SqlConnection conexion = new SqlConnection(); // instanciamos la conexion a la base
            SqlCommand comando = new SqlCommand();  // instanciamos el comando para ejecutar las query
            SqlDataReader lector; // No se instancia


            try
            {
               // Conexion para base de datos con declaracion de usuario especifico con login de sql
                conexion.ConnectionString = "Server=ULARIAGA-BRAIAN\\LOCALHOST; Database= CATALOGO_P3_DB; User Id= sa; Password=Super123.adm "; /// brian

              //  Conexion para base de datos local con login de wind
                /// conexion.ConnectionString = "Server=.\\SQLEXPRESS;  Database= CATALOGO_P3_DB; integrated security= true"; /// Andres & Nico

                comando.CommandType = System.Data.CommandType.Text; // Tipo de comando a ajecutar en el SQL, text(query), storeproceduire(SP)
                comando.CommandText = "select a.Codigo, a.Nombre, a.Descripcion, c.Descripcion Categoria, m.Descripcion Marca from ARTICULOS a left join CATEGORIAS c on c.Id = a.IdCategoria left join MARCAS m on m.Id = a.IdMarca"; //Declaramos el query
                comando.Connection = conexion; //Nos conectamos
                conexion.Open(); // abrimos conexion
                lector = comando.ExecuteReader(); // Leemos el reusltado del query

                while (lector.Read())
                {
                   E_Articulo aux = new E_Articulo(); // creamos el objeto para guardar los datos que leemos

                    aux.Codigo = (string)lector["Codigo"]; //Indicamos el objeto con el dato a leer y parseamos el dato ya que lo lee como obj
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Marca = new E_Marca(); // instanciamos ya que marca es agregacion y no composicion | tambien se debio sobreescribir el tostring en la entidad
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Categoria = new E_Categoria();// instanciamos ya que marca es agregacion y no composicion  | tambien se debio sobreescribir el tostring en la entidad
                    aux.Categoria.Descripcion = (string)lector["Categoria"];

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
        */
        public List<E_Articulo> Listar() {

            List<E_Articulo> lista = new List<E_Articulo>(); // instanciamos la lista
            ConexionSql conexion = new ConexionSql();

            try
            {

                conexion.Consulta("select a.Codigo, a.Nombre, a.Descripcion, c.Descripcion Categoria, m.Descripcion Marca from ARTICULOS a left join CATEGORIAS c on c.Id = a.IdCategoria left join MARCAS m on m.Id = a.IdMarca"); //Declaramos el query
                conexion.Ejecutar();

                while (conexion.Lector.Read())
                {
                    E_Articulo aux = new E_Articulo(); // creamos el objeto para guardar los datos que leemos

                    aux.Codigo = (string)conexion.Lector["Codigo"]; //Indicamos el objeto con el dato a leer y parseamos el dato ya que lo lee como obj
                    aux.Nombre = (string)conexion.Lector["Nombre"];
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    aux.Marca = new E_Marca(); // instanciamos ya que marca es agregacion y no composicion | tambien se debio sobreescribir el tostring en la entidad
                    aux.Marca.Descripcion = (string)conexion.Lector["Marca"];
                    aux.Categoria = new E_Categoria();// instanciamos ya que marca es agregacion y no composicion  | tambien se debio sobreescribir el tostring en la entidad
                    aux.Categoria.Descripcion = (string)conexion.Lector["Categoria"];

                    lista.Add(aux); // agregamos el objeto leido a la lista
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }finally
            {

                conexion.cerrarConexion();

            }
        
        
        
        }




        public List <E_Articulo> Filtro(string campo, string criterio, string filtro)
        {

            List<E_Articulo> Lista_Articulo = new List<E_Articulo> ();
            try
            {

                return Lista_Articulo;



            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
