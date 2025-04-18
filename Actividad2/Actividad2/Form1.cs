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


namespace Actividad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L_Articulo articulo = new L_Articulo();
            dgvArticulos.DataSource = articulo.Listar();

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /// buscar
            L_Articulo articulo = new L_Articulo();

            try
            {
                string Campo = cboCampo.SelectedItem.ToString();
                string Criterio = cboCriterio.SelectedItem.ToString();
                string Filtro = txtFiltro.Text;

                dgvArticulos.DataSource = articulo.Filtro(Campo, Criterio, Filtro);                                 ///dgv Data Grid view

            }
            catch (Exception)
            {

                throw;
            }

            

        }
    }
}
