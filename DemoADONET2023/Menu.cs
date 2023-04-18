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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DemoADONET2023
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                dgvProductos.DataSource = negocio.Listar(txtNombre.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }
        }
    }
}
