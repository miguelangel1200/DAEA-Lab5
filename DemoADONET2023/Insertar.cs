using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoADONET2023
{
    public partial class Insertar : Form
    {
        public Insertar()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                negocio.Insertar(new Entidad.Product
                {
                    Nombre = txtNombrePro.Text,
                    Precio = Convert.ToDouble(txtPrecioPro.Text)
                });
                MessageBox.Show("Producto Insertado");
                this.Hide();

                Menu frm = new Menu();
                frm.Show();

            }
            catch (Exception ex)  
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
