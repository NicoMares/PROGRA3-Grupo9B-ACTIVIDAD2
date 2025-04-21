using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class L_Categoria
    {

        public List<E_Categoria> ListarCategoria()
        {

            List<E_Categoria> lista = new List<E_Categoria>(); // instanciamos la lista
            ConexionSql conexion = new ConexionSql();

            try
            {

                conexion.Consulta("select id, Descripcion from Categorias"); //Declaramos el query
                conexion.Ejecutar();

                while (conexion.Lector.Read())
                {
                    E_Categoria aux = new E_Categoria(); // creamos el objeto para guardar los datos que leemos

                    aux.Id = (int)conexion.Lector["Id"]; //Indicamos el objeto con el dato a leer y parseamos el dato ya que lo lee como obj
                    aux.Descripcion = (string)conexion.Lector["Descripcion"];


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

        public void AgregarCategoria(E_Categoria categoria) {

                ConexionSql conexion = new ConexionSql();

                try
                {
                    conexion.Consulta("insert into CATEGORIAS (Descripcion) values (@Descipcion)");
                    
                    conexion.SetParametros("@Descripcion", categoria.Descripcion);

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
    }
}
