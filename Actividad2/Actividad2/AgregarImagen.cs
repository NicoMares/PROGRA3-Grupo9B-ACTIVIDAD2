using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Entidades;
using Logica.Logica;


namespace Actividad2
{
    public partial class AgregarImagen : Form
    {
        public E_Articulo ArticuloSeleccionado { get; set; }
        public AgregarImagen()
        {
            InitializeComponent();
        }

        private void AgregarImagen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                L_Imagen logica = new L_Imagen();
                if(logica.ExisteImagenEnBD(Lacaja.Text))
                {
                    MessageBox.Show("La imagen ya existe en la base de datos.");
                    return;
                }
                logica.AgregarImg(ArticuloSeleccionado.IdArt, Lacaja.Text);
                MessageBox.Show("Imagen agregada con exito");

            }
            catch
            {
                MessageBox.Show("Error al agregar la imagen");
            }
            finally
            {
                // Cerrar el formulario después de agregar la imagen
                this.Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Intentar cargar la imagen
                PbxAgregar.Load(Lacaja.Text);
            }
            catch (Exception ex)
            {
                // Si la URL no es válida, puedes poner un mensaje de error
                
                Lacaja.Clear();
            }
        }

        private void PbxAgregar_Click(object sender, EventArgs e)
        {

        }

        private void AgregarImagen_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lacaja.Clear();
        }
    }
}
