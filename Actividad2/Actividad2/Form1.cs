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
    public partial class frmPrincipal : Form
    {
        private List<E_Articulo> articulos;
        private List<E_Imagen> imagenesArt = new List<E_Imagen>();
        private int indiceImg = 0;
        public frmPrincipal()
        {
            InitializeComponent();
        }

   
        private void Form1_Load(object sender, EventArgs e)
        {
            btnVolver.Visible = false;
            dgvArticulos.Visible = false;
            btnAnterior.Visible = false;   
            btnProximo.Visible = false;


            CargarGrilla();

        }
        public void CargarGrilla()
        {
            L_Articulo logica = new L_Articulo();
            articulos = logica.Listar();
            dgvArt.DataSource = articulos;
            dgvArt.Columns["IdArt"].Visible = false;
            dgvArt.Columns["IdCategoria"].Visible = false;
            dgvArt.Columns["IdMarca"].Visible = false;
            dgvArt.Columns["Descripcion"].Visible = false;
            dgvArt.Columns["Precio"].Visible = false;
            dgvArt.Columns["Marca"].Visible = false;
            dgvArt.Columns["Categoria"].Visible = false;
            dgvArt.Columns["ImagenUrl"].Visible = false;

        }

        public void CargarDetallesIndividual(int id)
        {
            L_Articulo logica = new L_Articulo();
            E_Articulo art = new E_Articulo();
            art = logica.ListarPorID(id);
            List <E_Articulo> lista = new List <E_Articulo>();  
            lista.Add(art);
            dgvArt.Visible = false;
            dgvArticulos.DataSource = lista;

            dgvArticulos.Columns["IdArt"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["IdMarca"].Visible = false;
            dgvArticulos.Columns["IdCategoria"].Visible = false;
            btnAnterior.Visible = true;
            btnProximo.Visible = true;
            btnActualizar.Visible = false;

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void EliminarProducto(object sender, EventArgs e)
        {
            // Mostrar mensaje de confirmación
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que querés eliminar este producto?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                L_Articulo logica = new L_Articulo();
                E_Articulo eliminar = (E_Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                logica.EliminarFisico(eliminar.IdArt);
                CargarGrilla();

            }
            else
            {
                // El usuario eligio no
                MessageBox.Show("El producto no fue eliminado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BuscarFiltrado(object sender, EventArgs e)
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
                int id = seleccionada.IdArt;
                List<E_Imagen> lista = new List<E_Imagen>(); 
                L_Imagen imagen = new L_Imagen();
                lista = imagen.ListarImagenesPorID(id);

                CargarImagen(lista);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarImagen(List<E_Imagen> imagenes)
        {

            imagenesArt = imagenes;

            if (imagenesArt == null || imagenesArt.Count == 0)
            {
                pbxArt.Load("https://www.pngkey.com/png/detail/233-2332677_image-500580-placeholder-transparent.png");
                return;
            }

            try
            {
                
                
                pbxArt.Load(imagenesArt[indiceImg].ImagenUrl);
            }

            catch (Exception)
            {
                pbxArt.Load("https://www.pngkey.com/png/detail/233-2332677_image-500580-placeholder-transparent.png");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        //private void dgvArt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dgvArticulos.Visible = true;
        //    btnVolver.Visible = true;
        //    btnActualizar.Visible = false;

        //    int idSeleccionado = ((E_Articulo)dgvArt.Rows[e.RowIndex].DataBoundItem).IdArt;

        //    CargarDetallesIndividual(idSeleccionado);
        //}

        private void btnVolver_Click(object sender, EventArgs e)
        {
            dgvArt.Visible = true;
            dgvArticulos.Visible = false;
            pbxArt.Image = null;
            btnVolver.Visible = false;
            btnAnterior.Visible = false;
            btnProximo.Visible = false;
            indiceImg = 0;
            btnActualizar.Visible = true;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (imagenesArt != null && imagenesArt.Count > 0)
            {
                indiceImg = (indiceImg - 1 + imagenesArt.Count) % imagenesArt.Count;
                CargarImagen(imagenesArt);
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (imagenesArt != null && imagenesArt.Count > 0)
            {
                indiceImg = (indiceImg + 1) % imagenesArt.Count;
                CargarImagen(imagenesArt);
            }
        }

        private void dgvArt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
    
                dgvArticulos.Visible = true;
                btnVolver.Visible = true;
                int idSeleccionado = ((E_Articulo)dgvArt.Rows[e.RowIndex].DataBoundItem).IdArt;

                CargarDetallesIndividual(idSeleccionado);
            
        }

        private void tmNuevoArt_Click(object sender, EventArgs e)
        {

            

            FrmAltaArt frmAltaArt = new FrmAltaArt();
            frmAltaArt.ShowDialog();
            CargarGrilla();
        }

        private void tmModificarArt_Click(object sender, EventArgs e)
        {
            if (dgvArt.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccioná un artículo.");
                return;
            }


            E_Articulo seleccionado; // creamos el objeto art
            L_Articulo l_Articulo = new L_Articulo(); // creamos el obj de la logica art para usar las fuciones
            seleccionado = (E_Articulo)dgvArt.CurrentRow.DataBoundItem; //seleccionamos el elemento de la grid
            seleccionado = l_Articulo.ListarPorID(seleccionado.IdArt); //llamamos al obj logica, usamos el meotodo para obtener los datos y se lo pasamos al obj art
            
            FrmAltaArt modificar = new FrmAltaArt(seleccionado);
            modificar.ShowDialog();
            CargarGrilla();
        }

        private void tmEliminarArt_Click(object sender, EventArgs e)
        {

            if (dgvArt.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccioná un artículo.");
                return;
            }


            DialogResult resultado = MessageBox.Show("¿Estás seguro de que querés eliminar este producto?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                L_Articulo logica = new L_Articulo();
                E_Articulo eliminar = (E_Articulo)dgvArt.CurrentRow.DataBoundItem;
                logica.EliminarFisico(eliminar.IdArt);
                CargarGrilla();

            }
            else
            {
                // El usuario eligio no
                MessageBox.Show("El producto no fue eliminado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
