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
        private E_Articulo art = null; // intancio el objeto de tipo art para setear los atributos
        public FrmAltaArt()
        {
            InitializeComponent();

        }

        public FrmAltaArt(E_Articulo articulo)
        {
            InitializeComponent();
            this.art = articulo;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptarArt_Click(object sender, EventArgs e)
        {


            L_Articulo l_Articulo = new L_Articulo();
            L_Imagen l_Imagen = new L_Imagen();

            try
            {
                if (art == null)
                {
                    E_Articulo art = new E_Articulo(); // intancio el objeto de tipo art para setear los atributos
                art.Codigo = txtCodigo.Text;
                art.Nombre = txtNombre.Text;
                art.Descripcion = txtDescripcion.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);
                art.Marca = (E_Marca)cboMarca.SelectedItem;
                art.Categoria = (E_Categoria)cboCategoria.SelectedItem;
                l_Articulo.Agregar(art);
                    int idArt = l_Articulo.UltimoId();
                    string url = txtUrl.Text;
                    l_Imagen.AgregarImg(idArt, url);
                    MessageBox.Show("Articulo agregado con exito !");
                }
                else if (art.IdArt != 0)
                {
                    art.Codigo = txtCodigo.Text;
                    art.Nombre = txtNombre.Text;
                    art.Descripcion = txtDescripcion.Text;
                    art.Precio = decimal.Parse(txtPrecio.Text);
                    art.Marca = (E_Marca)cboMarca.SelectedItem;
                    art.Categoria = (E_Categoria)cboCategoria.SelectedItem;
                    string url = txtUrl.Text;
                    l_Articulo.Modificar(art);
                    MessageBox.Show("Articulo modificado con exito !");
                }


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
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboMarca.DataSource = l_Marca.ListarMarca();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";


                if (art != null)
                {
                    txtCodigo.Text = art.Codigo;
                    txtNombre.Text = art.Nombre;
                    txtDescripcion.Text = art.Descripcion;
                    txtPrecio.Text = art.Precio.ToString();
                    cboCategoria.SelectedValue = art.IdCategoria; //Seleccionamos el valor del objeto que traemos por parametro
                    cboMarca.SelectedValue = art.IdMarca;
                    txtUrl.Text = art.ImagenUrl.ImagenUrl;
                    CargarImagen(art.ImagenUrl.ImagenUrl);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            CargarImagen(url);
        }

        private void CargarImagen(string imagen)
        {

            try
            {
                if(string.IsNullOrEmpty(imagen))
                {
                    pbxImgAlta.Load("https://www.pngkey.com/png/detail/233-2332677_image-500580-placeholder-transparent.png");
                    return;
                }
                pbxImgAlta.Load(imagen);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
