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
    public partial class FormCatalogo : Form
    {
        public FormCatalogo()
        {
            InitializeComponent();  
        }

      
        private List<Articulo> listaArticulos ;
    

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar nuevaVentana = new FormAgregar();
            nuevaVentana.ShowDialog();
            CargarDgv();
        }

        
        private void RecargarImg(string img)
        {
            try
            {
                pbArticulo.Load(img);
            }
            catch (Exception)
            {

                pbArticulo.Load("https://data.pixiz.com/output/user/frame/preview/400x400/1/1/8/3/1713811_09879.jpg");
            }
            
        }

        private void dgvArticulos_MouseClick_1(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.ImagenUrl);
            CargarDescripcion(seleccionado.Descripcion);
        }

        private void CargarDgv()
        {
            
            try
            {
                ArticuloNegocio catalogoArticulos = new ArticuloNegocio();
                listaArticulos = catalogoArticulos.Listar();
                dgvArticulos.DataSource = listaArticulos;

                ocultarColumnas();
                RecargarImg(listaArticulos[0].ImagenUrl);
                CargarDescripcion(listaArticulos[0].Descripcion);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FormCatalogo_Load(object sender, EventArgs e)
        {
            CargarDgv();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            
            
            FormAgregar nuevaVentana = new FormAgregar((Articulo)dgvArticulos.CurrentRow.DataBoundItem,true);
            nuevaVentana.ShowDialog();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            ArticuloNegocio aux = new ArticuloNegocio();

            try
            {
                if (MessageBox.Show("¿De verdad deseas eliminar este articulo?", "Eliminar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    aux.Eliminar(seleccionado.Id);
                    MessageBox.Show("Articulo eliminado con exito");
                }

            }
            catch (Exception)
            {

                throw;
            }
          
            CargarDgv();
        }

        private void CargarDescripcion(string text)
        {
            lblDescripcion.Text = text;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //utilizamos la misma ventana de agregararticulo pero sobrecargamos su constructor al pasarle un articulo para cambiar su funcionalidad, asi podra modificar el articulo que se desee.
            FormAgregar nuevaVentana = new FormAgregar((Articulo)dgvArticulos.CurrentRow.DataBoundItem);
            nuevaVentana.ShowDialog();
            CargarDgv();
        }

     //Filtro
        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            //Cuando se ingresa una tecla en el txtFiltro busca si ese valor lo contiene el nombre, descripcion, precio, categoria o marca de algunos de los registros.
            if(txtFiltro.Text != "")
            {
                List<Articulo> listaFiltrada = listaArticulos.FindAll(X => X.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || X.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()) || X.Precio.ToString().Contains(txtFiltro.Text) || X.Marca.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || X.Categoria.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || X.Codigo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaFiltrada;
            }
            else
            {
                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaArticulos;
                
            }
            ocultarColumnas();
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
        }
    }
}
