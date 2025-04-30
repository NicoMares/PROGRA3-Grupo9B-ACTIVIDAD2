using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class L_Marca
    {

        public List<E_Marca> ListarMarca()
        {

            List<E_Marca> lista = new List<E_Marca>(); // instanciamos la lista
            ConexionSql conexion = new ConexionSql();

            try
            {

                conexion.Consulta("select id, Descripcion from MARCAS"); //Declaramos el query
                conexion.Ejecutar();

                while (conexion.Lector.Read())
                {
                    E_Marca aux = new E_Marca(); // creamos el objeto para guardar los datos que leemos

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

        public void AgregarMarca(E_Marca marcaingresada)
        {

            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("insert into MARCAS (Descripcion) values (@Descripcion)");

                conexion.SetParametros("@Descripcion", marcaingresada.Descripcion);

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
