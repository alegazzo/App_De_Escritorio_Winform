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
    public partial class FormExtra : Form
    {
        private Marca marca= null;

        private Categoria categoria= null;

        private bool estado = false;

        public FormExtra()
        {
            InitializeComponent();
        }


        public FormExtra ( bool estado)
        {
            InitializeComponent();
            this.estado = estado;
            Text = "Agregar Categoria";
            lblAgregar.Text = "Categoria:";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio auxC = new CategoriaNegocio();
            MarcaNegocio auxM = new MarcaNegocio();

            try
            {
                if (txtAgregar.Text != "") 
                {
                    //si estado es false lo que se agrega es una marca, en lo contrario seria una categoria.
                    if (estado)
                    {
                        categoria = new Categoria(txtAgregar.Text);
                        auxC.Agregar(categoria);
                        MessageBox.Show("Categoria agregada!");

                    }
                    else
                    {
                        marca = new Marca(txtAgregar.Text);
                        auxM.Agregar(marca);
                        MessageBox.Show("Marca agregada!");
                    }
                    Close();
                }
                errorProvider1.SetError(txtAgregar, "Datos incompletos");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
