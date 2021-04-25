using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
        private void Form1_Load(object sender, EventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregar nuevaVentana = new FormAgregar();
            nuevaVentana.ShowDialog();
        }

        private void RecargarImg(string img)
        {
            pbArticulo.Load(img);
        }

        private void dgvArticulos_MouseClick_1(object sender, MouseEventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            RecargarImg(seleccionado.ImagenUrl);
        }
    }
}
