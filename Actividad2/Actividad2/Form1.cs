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
    public partial class Form1 : Form
    {
        private List<E_Articulo> articulos;
        private List<E_Imagenes> imagenesArticuloActual = new List<E_Imagenes>();
        private int indiceImagenActual = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L_Articulo articulo = new L_Articulo();
            articulos = articulo.Listar();
            dgvArticulos.DataSource = articulos;
            pbArt.Load(articulos[0].Imagenes[0].ImagenUrl);

            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");   
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
           E_Articulo Seleccionada = (E_Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            
        }
    }
}
