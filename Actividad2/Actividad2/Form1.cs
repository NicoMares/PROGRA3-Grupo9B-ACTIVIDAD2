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


namespace Actividad2
{
    public partial class frmPrincipal : Form
    {
        private List<E_Articulo> articulos;
        private List<E_Imagen> imagenesArticuloActual = new List<E_Imagen>();
        private int indiceImagenActual = 0;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");   
        }
        public void CargarGrilla()
        {
            L_Articulo logica = new L_Articulo();
            articulos = logica.Listar();
            dgvArticulos.DataSource = articulos;
            dgvArticulos.Columns["IdArt"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            pbxArt.Load(articulos[0].ImagenUrl.ImagenUrl);
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///
            cboCriterio.Items.Clear();
            cboCriterio.Items.Add("Contiene");
            cboCriterio.Items.Add("Comienza con ");
            cboCriterio.Items.Add("Termina con ");
       

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            /// filtro
        }


        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AgregarProducto(object sender, EventArgs e)
        {
            FrmAltaArt frmAltaArt = new FrmAltaArt(this);
            frmAltaArt.ShowDialog(); 
        }

        private void EliminarProducto(object sender, EventArgs e)
        {

        }

        private void ModificarProducto(object sender, EventArgs e)
        {

        }

        private void BuscarFiltrado(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {

        }

        private void pbArticulos(object sender, EventArgs e)
        {

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               E_Articulo seleccionada = (E_Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionada.ImagenUrl.ImagenUrl);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarImagen(string url) {

            try
            {
                pbxArt.Load(url);
            }
            catch (Exception ex)
            {

                pbxArt.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpPkm3Hhfm2fa7zZFgK0HQrD8yvwSBmnm_Gw&s");
            }
        
        
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
