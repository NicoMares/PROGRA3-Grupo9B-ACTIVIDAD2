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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L_Articulo articulo = new L_Articulo();
            dgvArticulos.DataSource = articulo.listar();

            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
<<<<<<< Updated upstream
               
        }

        private void label3_Click(object sender, EventArgs e)
        {

=======
        }
        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

       
>>>>>>> Stashed changes
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCriterio.Items.Clear();
<<<<<<< Updated upstream
            cboCriterio.Items.Add("Contiene");
            cboCriterio.Items.Add("Comienza con ");
            cboCriterio.Items.Add("Termina con ");
       
=======
            cboCriterio.Items.Add("Comienza con ");
            cboCriterio.Items.Add("Termina con ");
            cboCriterio.Items.Add("Empieza con ");
            cboCriterio.SelectedIndex = 0;
>>>>>>> Stashed changes
        }
    }
}
