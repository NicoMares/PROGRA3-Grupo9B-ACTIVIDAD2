using Entidades;
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
    public partial class frmAgregar : Form
    {

        public string Tipo { get; set; }
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            L_Validacion l_Validacion = new L_Validacion();

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {

                MessageBox.Show("La descripcion no puede ser nula o vacia");

                return;

            }
            else if (!l_Validacion.EsSoloTexto(txtDescripcion.Text))
            {
                MessageBox.Show("La descripcion debe ser solo texto");

                return;
            }
            if (Tipo == "Categoria")
            {

                E_Categoria e_Categoria = new E_Categoria();
                L_Categoria l_categoria = new L_Categoria();

                try
                {
                    e_Categoria.Descripcion = txtDescripcion.Text;
                    l_categoria.AgregarCategoria(e_Categoria);
                    MessageBox.Show("Categoria agregada con exito");

                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
            else if (Tipo == "Marca")
            {
                E_Marca e_Marca = new E_Marca();
                L_Marca l_Marca = new L_Marca();

                try
                {
                    e_Marca.Descripcion = txtDescripcion.Text;
                    l_Marca.AgregarMarca(e_Marca);
                    MessageBox.Show("Marca agregada con exito");

                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            Tipo = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Tipo = null;
            Close();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            if (Tipo == "Categoria")
            {
                lblMarca.Visible = false;
            }
            else if (Tipo == "Marca")
            {
                lblCategoria.Visible = false;
            }
        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }
    }
}
