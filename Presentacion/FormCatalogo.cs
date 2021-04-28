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

        private void button4_Click(object sender, EventArgs e)
        {

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
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error con la imagen : "+ ex.Message);
            }
            
        }

        private void dgvArticulos_MouseClick_1(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.ImagenUrl);
        }

        private void CargarDgv()
        {

            try
            {
                ArticuloNegocio catalogoArticulos = new ArticuloNegocio();
                listaArticulos = catalogoArticulos.Listar();
                dgvArticulos.DataSource = listaArticulos;

                dgvArticulos.Columns["ImagenUrl"].Visible = false;


                RecargarImg(listaArticulos[0].ImagenUrl);

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
    }
}
