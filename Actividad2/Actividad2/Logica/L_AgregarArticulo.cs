using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Actividad2
{
     class L_AgregarArticulo
    {

        public void AgregarArt(E_Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                //conexion.ConnectionString = "Server=ULARIAGA-BRAIAN\\LOCALHOST; Database= CATALOGO_P3_DB; User Id= sa; Password=Super123.adm ";
                conexion.ConnectionString = "Server=.\\SQLEXPRESS;  Database= CATALOGO_P3_DB; integrated security= true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "insert into ARTICULOS (Codigo, Nombre, Descripcion) values (@Codigo, @Nombre, @Descripcion)";
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                //falta add.categoria, addmarca y addimage
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }















    }
}
