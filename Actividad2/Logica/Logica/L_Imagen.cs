using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Logica
{
    public class L_Imagen
    {


        public void AgregarImg(int id, string url)
        {
            ConexionSql conexion = new ConexionSql();

            try
            {
                conexion.Consulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@Id, @Url)");

                conexion.SetParametros("@Id", id);
                conexion.SetParametros("@Url", url);
   
                conexion.EjecutarAccion();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public List<E_Imagen> ListarImagenesPorID(int id)
        {
            List<E_Imagen> listaImagenes = new List<E_Imagen>();
            ConexionSql conexion = new ConexionSql();

            try
            {
                
                conexion.Consulta(@"SELECT ImagenUrl FROM IMAGENES  WHERE IdArticulo = @id");

                conexion.SetParametros("@id", id);  
                conexion.Ejecutar();

                while (conexion.Lector.Read())  
                {
                    E_Imagen imagen = new E_Imagen();
                    imagen.ImagenUrl = (string)conexion.Lector["ImagenUrl"];
                    listaImagenes.Add(imagen);  
                }

                return listaImagenes;
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
                conexion.Consulta("DELETE FROM IMAGENES WHERE IdArticulo = @Id");
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

    }
}
