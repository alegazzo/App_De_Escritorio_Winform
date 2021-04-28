using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;


namespace TP_Winform
{
    public partial class FormAgregar : Form
    {
        public FormAgregar()
        {
            InitializeComponent();
        }


        private void FormAgregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboMarca.DataSource = marcaNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo aux = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                aux.Codigo = txtCodigo.Text;
                aux.Nombre = txtNombre.Text;
                aux.Descripcion = txtDescripcion.Text;
                aux.ImagenUrl = txtImagen.Text;
                aux.Precio = Convert.ToDecimal(txtPrecio.Text);
                aux.Marca = (Marca)cboMarca.SelectedItem;
                aux.Categoria = (Categoria)cboCategoria.SelectedItem;

                articuloNegocio.Agregar(aux);
                MessageBox.Show("Agregado correctamente");
                Close();


                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
