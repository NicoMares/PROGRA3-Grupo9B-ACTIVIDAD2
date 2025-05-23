﻿using System;
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
using System.Security.Policy;


namespace Actividad2
{
    public partial class frmPrincipal : Form
    {
        private List<E_Articulo> articulos;
        private List<E_Imagen> imagenesArt = new List<E_Imagen>();
        private int indiceImg = 0;

        public string UrlCargado { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg";
        public E_Articulo ArticuloSeleccionadoPrincipal { get; set; }
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
            pbxArt.Enabled = false;
            AgregarIMG.Visible = false;
            AgregarIMG.Enabled = false;




            CargarGrilla();
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");

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

        public void CargarGrilla(List<E_Articulo> lista)
        {

            dgvArt.DataSource = lista;
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
            List<E_Articulo> lista = new List<E_Articulo>();
            lista.Add(art);
            dgvArt.Visible = false;
            dgvArticulos.DataSource = lista;
            ArticuloSeleccionadoPrincipal = (E_Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            dgvArticulos.Columns["IdArt"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["IdMarca"].Visible = false;
            dgvArticulos.Columns["IdCategoria"].Visible = false;
            btnAnterior.Visible = true;
            btnProximo.Visible = true;
            tmiAcciones.Visible = false;
            btnActualizar.Visible = false;
            lblFiltro.Visible = false;
            txtFiltro.Visible = false;
            pbxArt.Enabled = true;
            AgregarIMG.Visible = true;
            AgregarIMG.Enabled = true;

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCriterio.Items.Clear();
            cboCriterio.Items.Add("Contiene");
            cboCriterio.Items.Add("Comienza con");
            cboCriterio.Items.Add("Termina con");

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<E_Articulo> listaFiltrada;

            if (txtFiltro.Text != "")
            {

                listaFiltrada = articulos.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            }
            else
            {
                listaFiltrada = articulos;
            }

            dgvArt.DataSource = null;
            CargarGrilla(listaFiltrada);
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    E_Articulo seleccionada = (E_Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    int id = seleccionada.IdArt;
                    List<E_Imagen> lista = new List<E_Imagen>();
                    L_Imagen imagen = new L_Imagen();
                    lista = imagen.ListarImagenesPorID(id);

                    CargarImagen(lista);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void CargarImagen(List<E_Imagen> imagenes)
        {

            imagenesArt = imagenes;
            L_Imagen logica = new L_Imagen();


            if (imagenesArt == null || imagenesArt.Count == 0)
            {
                pbxArt.Load("https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg");
                

            }

            try
            {
                pbxArt.Load(imagenesArt[indiceImg].ImagenUrl);
               UrlCargado = imagenesArt[indiceImg].ImagenUrl;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la imagen: " + ex.Message);
                pbxArt.Load("https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
            txtFiltro.Clear();
            txtFiltroAvz.Clear();
        }
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
            tmiAcciones.Visible = true;
            lblFiltro.Visible = true;
            txtFiltro.Visible = true;
            pbxArt.Enabled = false;
            AgregarIMG.Visible = false;
            AgregarIMG.Enabled = false;

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
            if (e.RowIndex < 0) return;
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
                L_Imagen l_Imagen = new L_Imagen();
                E_Articulo eliminar = (E_Articulo)dgvArt.CurrentRow.DataBoundItem;
                logica.EliminarFisico(eliminar.IdArt);
                l_Imagen.EliminarFisico(eliminar.IdArt);
                CargarGrilla();

            }
            else
            {
                // El usuario eligio no
                MessageBox.Show("El producto no fue eliminado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            L_Articulo l_Articulo = new L_Articulo();

            try
            {   
                if(cboCampo.SelectedItem == null)
                {
                    MessageBox.Show("Por Favor, Seleccionar un campo");
                    return;

                }
                string campo = cboCampo.SelectedItem.ToString();

                if(cboCriterio.SelectedItem == null)
                {
                    MessageBox.Show("Por Favor, Seleccionar un criterio");
                    return;
                }

                string criterio = cboCriterio.SelectedItem.ToString();

      
                string filtro = txtFiltroAvz.Text;
                CargarGrilla( l_Articulo.Filtro(campo, criterio, filtro));
                
                txtFiltroAvz.Clear();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Tipo = "Marca";
            agregar.ShowDialog();

        }

        private void agregarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregar agregar = new frmAgregar();
            agregar.Tipo = "Categoria";
            agregar.ShowDialog();
        }

        private void pbxArt_Click(object sender, EventArgs e)
        {
            L_Imagen logica = new L_Imagen();
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que querés eliminar esta imagen?",
                                                     "Confirmar eliminación",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);
            //OJO SI TIENEN LA MISMA IMAGEN
            //SE BORRAN TODAS LAS IMAGENES IGUALES, AVERIGUAR LUEGO
            if (resultado == DialogResult.Yes)
            {


                if(UrlCargado == "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg")
                {
                    MessageBox.Show("No se puede eliminar la imagen por defecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //SE BORRAN LAS IMAGENES IGUALES SIEMPRE REVISAR
                logica.EliminarFisico(UrlCargado);
                MessageBox.Show("La imagen fue eliminada.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnVolver.PerformClick();

            }
            else
            {
                // El usuario eligio no
                MessageBox.Show("El producto no fue eliminado.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AgregarIM_Click(object sender, EventArgs e)
        {
            AgregarImagen agregar = new AgregarImagen();
            agregar.ArticuloSeleccionado = ArticuloSeleccionadoPrincipal;
            agregar.ShowDialog();
            btnVolver.PerformClick();
        }
    }
}
