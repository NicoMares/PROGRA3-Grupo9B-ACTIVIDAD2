using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad2
{
    public partial class FrmAltaArt : Form
    {
        public FrmAltaArt()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptarArt_Click(object sender, EventArgs e)
        {

            E_Articulo nuevo = new E_Articulo(); // intancio el objeto de tipo art para setear los atributos
            L_Articulo l_Articulo = new L_Articulo();

            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                //nuevo.Marca = txtMarca.Text;    
                //nuevo.Categoria = txtCategoria.Text;
                //nuevo.Imagenes = txtUrl.Text;

                l_Articulo.Agregar(nuevo);
                MessageBox.Show("Articulo agregado con exito !");
                Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelarArt_Click(object sender, EventArgs e)
{
    Close();
}
    }
}
