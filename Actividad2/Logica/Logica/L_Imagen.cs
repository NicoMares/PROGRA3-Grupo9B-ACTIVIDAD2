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
    }
}
