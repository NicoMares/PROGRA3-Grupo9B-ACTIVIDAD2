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
                    while (string.IsNullOrWhiteSpace(txtCodigo.Text))
                    {
                        MessageBox.Show("Por favor, ingresá un código.");
                        return;
                    }

                    while (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("Por favor, ingresá un nombre.");
                        return;
                    }

                    while (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    {
                        MessageBox.Show("Por favor, ingresá una descripción.");
                        return;
                    }

                    decimal precio;
                    while (!decimal.TryParse(txtPrecio.Text, out precio))
                    {
                        MessageBox.Show("Por favor, ingresá un precio válido.");
                        return;
                    }

                    while (cboMarca.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, seleccioná una marca.");
                        return;
                    }

                    while (cboCategoria.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, seleccioná una categoría.");
                        return;
                    }

                    // Si pasa todas las validaciones, se carga el artículo
                    E_Articulo art = new E_Articulo();
                    art.Codigo = txtCodigo.Text;
                    art.Nombre = txtNombre.Text;
                    art.Descripcion = txtDescripcion.Text;
                    art.Precio = precio;
                    art.Marca = (E_Marca)cboMarca.SelectedItem;
                    art.Categoria = (E_Categoria)cboCategoria.SelectedItem;

                    l_Articulo.Agregar(art);

                    int idArt = l_Articulo.UltimoId();
                    string url = txtUrl.Text;

                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        l_Imagen.AgregarImg(idArt, url);
                    }

                    MessageBox.Show("¡Artículo agregado con éxito!");
                }
                else if (art.IdArt != 0)
                {
                    while (string.IsNullOrWhiteSpace(txtCodigo.Text))
                    {
                        MessageBox.Show("Por favor, ingresá un código.");
                        return;
                    }

                    while (string.IsNullOrWhiteSpace(txtNombre.Text))
                    {
                        MessageBox.Show("Por favor, ingresá un nombre.");
                        return;
                    }

                    while (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    {
                        MessageBox.Show("Por favor, ingresá una descripción.");
                        return;
                    }

                    decimal precio;
                    while (!decimal.TryParse(txtPrecio.Text, out precio))
                    {
                        MessageBox.Show("Por favor, ingresá un precio válido.");
                        return;
                    }

                    while (cboMarca.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, seleccioná una marca.");
                        return;
                    }

                    while (cboCategoria.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, seleccioná una categoría.");
                        return;
                    }

                    // Modificación de datos
                    art.Codigo = txtCodigo.Text;
                    art.Nombre = txtNombre.Text;
                    art.Descripcion = txtDescripcion.Text;
                    art.Precio = precio;
                    art.Marca = (E_Marca)cboMarca.SelectedItem;
                    art.Categoria = (E_Categoria)cboCategoria.SelectedItem;

                    string url = txtUrl.Text;

                    l_Articulo.Modificar(art);

                    // Si querés, podés también actualizar la imagen si se modificó la URL
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        l_Imagen.AgregarImg(art.IdArt, url); // Suponiendo que tengas ese método
                    }

                    MessageBox.Show("¡Artículo modificado con éxito!");
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
               
                  
                pbxImgAlta.Load(imagen);
            }
            catch(Exception)
            {
                pbxImgAlta.Load("https://www.pngkey.com/png/detail/233-2332677_image-500580-placeholder-transparent.png");

            }
        }
    }
}
