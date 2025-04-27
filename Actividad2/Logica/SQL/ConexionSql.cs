using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Logica
{
    public class ConexionSql
    {
        private SqlConnection conexion = new SqlConnection(); // instanciamos la conexion a la base
        private SqlCommand comando = new SqlCommand();  // instanciamos el comando para ejecutar las query
        private SqlDataReader lector; // No se instancia

        public SqlDataReader Lector
        {
            get { return lector; } // Generamos el get para leer desde afuera el lector ya que es private
        }

        //conexion a la base
        public ConexionSql()
        {
            try
            {
                conexion = new SqlConnection(@"Server=.\SQLEXPRESS;Database=WANNIMA;Integrated Security=True");

                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        //Metodo para la consulta
        public void Consulta(string consulta)
        {
            try
            {
            comando.CommandType = System.Data.CommandType.Text; // Tipo de comando a ajecutar en el SQL, text(query), storeproceduire(SP)
            comando.CommandText = consulta; //Pasamos la consulta por parametro

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        //Metodo para ejecutar consulta
        public void Ejecutar()
        {

            comando.Connection = conexion; //Nos conectamos

            try
            {
                conexion.Open(); // abrimos conexion
                lector = comando.ExecuteReader(); // Leemos el reusltado del query

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void EjecutarAccion()
        {

            comando.Connection = conexion; //Nos conectamos

            try
            {
                conexion.Open(); // abrimos conexion
                comando.ExecuteReader(); // Leemos el reusltado del query sin guardarlo

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void cerrarConexion()
        {

            try
            {

                if (lector != null)
                {
                    lector.Close();
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexion != null && conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }

            }
        }

            public void SetParametros(string nombre, object valor)
            {
                comando.Parameters.AddWithValue(nombre, valor);
            }

        
        }
    }

