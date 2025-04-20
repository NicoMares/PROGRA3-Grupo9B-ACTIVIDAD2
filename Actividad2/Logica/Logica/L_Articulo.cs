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

        public List<E_Articulo> Listar()
        {

            List<E_Articulo> lista = new List<E_Articulo>(); // instanciamos la lista
            ConexionSql conexion = new ConexionSql();

            try
            {

                conexion.Consulta("select a.Id, c.id as IdCategoria, m.id as IdMarca, a.Codigo, a.Nombre, a.Descripcion, a.Precio, c.Descripcion Categoria, m.Descripcion Marca, isnull (i.ImagenUrl, '') ImagenUrl from ARTICULOS a left join CATEGORIAS c on c.Id = a.IdCategoria left join MARCAS m on m.Id = a.IdMarca left join IMAGENES i on i.IdArticulo = a.Id"); //Declaramos el query
                conexion.Ejecutar();

                while (conexion.Lector.Read())
                {
                    E_Articulo aux = new E_Articulo(); // creamos el objeto para guardar los datos que leemos

                    aux.IdArt = (int)conexion.Lector["Id"]; //Indicamos el objeto con el dato a leer y parseamos el dato ya que lo lee como obj
                    aux.IdCategoria = (int)conexion.Lector["IdCategoria"];
                    aux.IdMarca = (int)conexion.Lector["IdMarca"];
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

        public E_Articulo ListarPorID(int id)
        {
            E_Articulo aux = new E_Articulo();
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta(@"select a.Id, c.id as IdCategoria, m.id as IdMarca, a.Codigo, a.Nombre, a.Descripcion, a.Precio, c.Descripcion Categoria, m.Descripcion Marca, isnull (i.ImagenUrl, '') ImagenUrl from ARTICULOS a left join CATEGORIAS c on c.Id = a.IdCategoria left join MARCAS m on m.Id = a.IdMarca left join IMAGENES i on i.IdArticulo = a.Id WHERE a.Id = @id");

                conexion.SetParametros("@id", id);
                conexion.Ejecutar();

                if (conexion.Lector.Read())
                {
                    aux.IdArt = (int)conexion.Lector["Id"];
                    aux.IdCategoria = (int)conexion.Lector["IdCategoria"];
                    aux.IdMarca = (int)conexion.Lector["IdMarca"];
                    aux.Codigo = (string)conexion.Lector["Codigo"];
                    aux.Nombre = (string)conexion.Lector["Nombre"];
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    aux.Precio = (decimal)conexion.Lector["Precio"];
                    aux.Marca = new E_Marca { Descripcion = (string)conexion.Lector["Marca"] };
                    aux.Categoria = new E_Categoria { Descripcion = (string)conexion.Lector["Categoria"] };
                    aux.ImagenUrl = new E_Imagen { ImagenUrl = (string)conexion.Lector["ImagenUrl"] };
                }

                return aux;
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

            List<E_Articulo> listaArt = new List<E_Articulo>(); // instanciamos la lista
            ConexionSql conexion = new ConexionSql();

            try
            {

                string query = ("select a.Id, c.id as IdCategoria, m.id as IdMarca, a.Codigo, a.Nombre, a.Descripcion, a.Precio, c.Descripcion Categoria, m.Descripcion Marca, isnull (i.ImagenUrl, '') ImagenUrl from ARTICULOS a left join CATEGORIAS c on c.Id = a.IdCategoria left join MARCAS m on m.Id = a.IdMarca left join IMAGENES i on i.IdArticulo = a.Id WHERE ");

                if (campo == "Codigo")
                {
                    switch (criterio)
                    {

                        case "Contiene":

                            query += "a.Codigo like '%" + filtro + "%'";
                            break;
                        case "Comienza con":
                            query += "a.Codigo like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            query += "a.Codigo like '%" + filtro + "'";
                            break;

                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Contiene":

                            query += "a.Nombre like '%" + filtro + "%'";
                            break;
                        case "Comienza con":
                            query += "a.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            query += "a.Nombre like '%" + filtro + "'";
                            break;
                    }
                }

                conexion.Consulta(query);
                conexion.Ejecutar();

                while (conexion.Lector.Read())
                {
                    E_Articulo aux = new E_Articulo();
                    aux.IdArt = (int)conexion.Lector["Id"];
                    aux.IdCategoria = (int)conexion.Lector["IdCategoria"];
                    aux.IdMarca = (int)conexion.Lector["IdMarca"];
                    aux.Codigo = (string)conexion.Lector["Codigo"];
                    aux.Nombre = (string)conexion.Lector["Nombre"];
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];
                    aux.Precio = (decimal)conexion.Lector["Precio"];
                    aux.Marca = new E_Marca { Descripcion = (string)conexion.Lector["Marca"] };
                    aux.Categoria = new E_Categoria { Descripcion = (string)conexion.Lector["Categoria"] };
                    aux.ImagenUrl = new E_Imagen { ImagenUrl = (string)conexion.Lector["ImagenUrl"] };
                    listaArt.Add(aux);
                }

                return listaArt;



            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
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