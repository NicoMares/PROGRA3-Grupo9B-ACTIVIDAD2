using Entidades;
using Logica;
using Logica.Logica;
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
        private frmPrincipal padre;
        public FrmAltaArt(frmPrincipal padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptarArt_Click(object sender, EventArgs e)
        {

            E_Articulo nuevo = new E_Articulo(); // intancio el objeto de tipo art para setear los atributos
            L_Articulo l_Articulo = new L_Articulo();
            L_Imagen l_Imagen = new Logica.Logica.L_Imagen();

            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Marca = (E_Marca)cboMarca.SelectedItem;    
                nuevo.Categoria = (E_Categoria)cboCategoria.SelectedItem;
                l_Articulo.Agregar(nuevo);
                int idArt = l_Articulo.UltimoId();
                string url = txtUrl.Text;
                l_Imagen.AgregarImg(idArt, url);

                MessageBox.Show("Articulo agregado con exito !");
                padre.CargarGrilla();
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

        private void FrmAltaArt_Load(object sender, EventArgs e)
        {
            L_Marca l_Marca = new L_Marca();
            L_Categoria l_Categoria = new L_Categoria();

            try
            {
                cboCategoria.DataSource = l_Categoria.ListarCategoria();
                cboMarca.DataSource = l_Marca.ListarMarca();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
