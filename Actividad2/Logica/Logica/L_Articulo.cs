using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;
using Entidades;
using Logica.Logica;
using System.Security.Cryptography.X509Certificates;


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
        public List<E_Articulo> Listar()
        {

            List<E_Articulo> lista = new List<E_Articulo>(); // instanciamos la lista
            ConexionSql conexion = new ConexionSql();

            try
            {

                conexion.Consulta("select a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, c.Descripcion Categoria, m.Descripcion Marca, isnull (i.ImagenUrl, '') ImagenUrl from ARTICULOS a left join CATEGORIAS c on c.Id = a.IdCategoria left join MARCAS m on m.Id = a.IdMarca left join IMAGENES i on i.IdArticulo = a.Id"); //Declaramos el query
                conexion.Ejecutar();

                while (conexion.Lector.Read())
                {
                    E_Articulo aux = new E_Articulo(); // creamos el objeto para guardar los datos que leemos

                    aux.IdArt = (int)conexion.Lector["Id"]; //Indicamos el objeto con el dato a leer y parseamos el dato ya que lo lee como obj
                    aux.Codigo = (string)conexion.Lector["Codigo"]; //Indicamos el objeto con el dato a leer y parseamos el dato ya que lo lee como obj
                    aux.Nombre = (string)conexion.Lector["Nombre"];
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    aux.Precio = (decimal)conexion.Lector["Precio"];
                    aux.Marca = new E_Marca(); // instanciamos ya que marca es agregacion y no composicion | tambien se debio sobreescribir el tostring en la entidad
                    aux.Marca.Descripcion = (string)conexion.Lector["Marca"];
                    aux.Categoria = new E_Categoria();// instanciamos ya que marca es agregacion y no composicion  | tambien se debio sobreescribir el tostring en la entidad
                    aux.Categoria.Descripcion = (string)conexion.Lector["Categoria"];
                    aux.ImagenUrl = new E_Imagen();
                    aux.ImagenUrl.ImagenUrl = (string)conexion.Lector["ImagenUrl"];


                    lista.Add(aux); // agregamos el objeto leido a la lista

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                conexion.cerrarConexion();

            }



        }




        public List<E_Articulo> Filtro(string campo, string criterio, string filtro)
        {

            List<E_Articulo> Lista_Articulo = new List<E_Articulo>();
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

        public List<E_Imagen> ListarImagenes(int IdArticulo)
        {
            List<E_Imagen> lista = new List<E_Imagen>();
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                conexion.SetParametros("@IdArticulo", IdArticulo);

                conexion.Ejecutar();

                while (conexion.Lector.Read())
                {
                    E_Imagen imagen = new E_Imagen();

                    imagen.Id = (int)conexion.Lector["Id"];
                    imagen.IdArticulo = (int)conexion.Lector["IdArticulo"];
                    imagen.ImagenUrl = (string)conexion.Lector["ImagenUrl"];

                    lista.Add(imagen);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Agregar(E_Articulo articulo)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdCategoria, IdMarca) VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdCategoria, @IdMarca)");
                //conexion.Consulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @Precio)");

                conexion.SetParametros("@Codigo", articulo.Codigo);
                conexion.SetParametros("@Nombre", articulo.Nombre);
                conexion.SetParametros("@Descripcion", articulo.Descripcion);
                conexion.SetParametros("@Precio", articulo.Precio);
                conexion.SetParametros("@IdCategoria", articulo.Categoria.Id);
                conexion.SetParametros("@IdMarca", articulo.Marca.Id);

                conexion.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }

        }

        public int UltimoId()
        {

            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("select Id from ARTICULOS order by id desc"); //Declaramos el query
                conexion.Ejecutar();

                conexion.Lector.Read();
                E_Articulo aux = new E_Articulo(); // creamos el objeto para guardar los datos que leemos

                return aux.IdArt = (int)conexion.Lector["Id"];


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();

            }


        }



        public void EliminarFisico(int idArticulo)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                conexion.SetParametros("@Id", idArticulo);
                conexion.Ejecutar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Modificar(E_Articulo articulo)
        {

            ConexionSql conexion = new ConexionSql();

            try
            {

                conexion.Consulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, IdCategoria = @IdCategoria, IdMarca = @IdMarca WHERE Id = @Id");

                conexion.SetParametros("@Codigo", articulo.Codigo);
                conexion.SetParametros("@Nombre", articulo.Nombre);
                conexion.SetParametros("@Descripcion", articulo.Descripcion);
                conexion.SetParametros("@Precio", articulo.Precio);
                conexion.SetParametros("@IdCategoria", articulo.Categoria.Id);
                conexion.SetParametros("@IdMarca", articulo.Marca.Id);
                conexion.SetParametros("@Id", articulo.IdArt);

                conexion.Ejecutar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();





            }
        }

    }

}