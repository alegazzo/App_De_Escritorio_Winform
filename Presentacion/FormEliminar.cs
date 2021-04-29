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
    public partial class FormEliminar : Form
    {
        public FormEliminar(Articulo aux )
        {
            InitializeComponent();
            txtCodigo.Text = aux.Codigo;
            txtNombre.Text = aux.Nombre;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            ArticuloNegocio aux = new ArticuloNegocio();


            if (txtEliminar.Text == "Eliminar") {
                aux.Eliminar(txtCodigo.Text);
                MessageBox.Show("Eliminado correctamente");
                Close();
            }
            else
            {
                MessageBox.Show("Palabra erronea");
             
            }


        }
    }
}
