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

        //Si el articulo entra como null va a ser un articulo a agregar, en cambio si entra cargado va a ser un articulo a modificar.
        private Articulo articulo = null;
        public FormAgregar()
        {
            InitializeComponent();
        }
        public FormAgregar(Articulo aux)
        {
            InitializeComponent();
            articulo = aux;
            Text = "Modificar Articulo";
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

          
            cboCategoria.DataSource = categoriaNegocio.listar();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Nombre";

            cboMarca.DataSource = marcaNegocio.listar();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Nombre";

            if (articulo!= null)
            {
                
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtImagen.Text = articulo.ImagenUrl;
                cboCategoria.SelectedValue = articulo.Categoria.Id;
                cboMarca.SelectedValue = articulo.Marca.Id;
                txtPrecio.Text = Convert.ToString(articulo.Precio);

            }

           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if (articulo == null) articulo = new Articulo(); //Si articulo es null es un articulo nuevo.


               

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenUrl = txtImagen.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text) ;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
        

                if (ValidarCampos() == true)
                {
                    

                    if (articulo.Id != 0)
                    {
                        //si el id es = 0 significa que es un new articulo(). Si ya tiene un id !=0 es un articulo a modificar que vino desde afuera.
                        articuloNegocio.Modificar(articulo);
                        MessageBox.Show("Modificado correctamente");
                    }
                    else
                    {
                        articuloNegocio.Agregar(articulo);
                        MessageBox.Show("Agregado correctamente");
                    }
                    Close();

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show( "Error: " + ex);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidarCampos()
        {
            bool aux = true;
            if (txtCodigo.Text == "")
            {
                aux = false;
                errorProvider1.SetError(txtCodigo, "Ingresar Codigo");

            }
            else
            {
                errorProvider1.SetError(txtCodigo, "");
            }

            if (txtNombre.Text == "")
            {
                aux = false;
                errorProvider2.SetError(txtNombre, "Ingresar Nombre");

            }
            else
            {
                errorProvider2.SetError(txtNombre, "");
            }

            if (txtDescripcion.Text == "")
            {
                aux = false;
                errorProvider3.SetError(txtDescripcion, "Ingresar Descripcion");

            }
            else
            {
                errorProvider3.SetError(txtDescripcion, "");
            }

            if (txtImagen.Text == "")
            {
                aux = false;
                errorProvider4.SetError(txtImagen, "Ingresar URL de la imagen");

            }
            else
            {
                errorProvider4.SetError(txtImagen, "");
            }

            if (txtPrecio.Text == "")
            {
                aux = false;
                errorProvider5.SetError(txtPrecio, "Ingresar Precio");

            }
            else
            {
                errorProvider5.SetError(txtPrecio, "");
            }
            return aux;
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            decimal num;
            if (!decimal.TryParse(txtPrecio.Text, out num))
            {
                errorProvider5.SetError(txtPrecio, "Ingrese el valor en numeros");
            }
            else
            {
                errorProvider5.SetError(txtPrecio, "");
            }
        }
    }
}
