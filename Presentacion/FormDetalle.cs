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

namespace TP_Winform
{
    public partial class FormDetalle : Form
    {
        public FormDetalle(Articulo aux)
        {
            InitializeComponent();

            txtCodigo.Text = aux.Codigo;
            txtNombre.Text = aux.Nombre;
            txtDescripcion.Text = aux.Descripcion;
            txtCategoria.Text = aux.Categoria.Nombre;
            txtMarca.Text = aux.Marca.Nombre;
            txtPrecio.Text =Convert.ToString(aux.Precio);
            txtUrlImagen.Text = aux.ImagenUrl;
            RecargarImg(aux.ImagenUrl);

        }


        private void RecargarImg(string img)
        {
            try
            {
               PbDetalle.Load(img);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error con la imagen : " + ex.Message);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
