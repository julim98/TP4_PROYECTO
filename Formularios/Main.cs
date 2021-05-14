using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4_PROYECTO.Formularios
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            cargarCmb();
        }

        private bool verficarEntradas()
        {
            if (!int.TryParse(txtCantidad.Text, out int cantidad) && !(cantidad > 0))
            {
                MessageBox.Show("Ingrese correctamente la cantidad de vuelos");
                return false;
            }

            if (!int.TryParse(txtDesde.Text, out int desde) && !(desde > 0) && !(desde <= cantidad))
            {
                MessageBox.Show("Ingrese correctamente desde que vuelo quiere visualizar");
                return false;
            }

            if (!int.TryParse(txtCantFilas.Text, out int cantFilas) && !(cantFilas > 0))
            {
                MessageBox.Show("Ingrese correctamente la cantidad de filas");
                return false;
            }

            if (!((desde + cantFilas - 1) <= cantidad))
            {
                MessageBox.Show("Las filas a mostrar superan a las filas que desea crear");
                return false;
            }

            return true;
        }

        private void cargarCmb()
        {
            cmbReservas.Items.Add(31);
            cmbReservas.Items.Add(32);
            cmbReservas.Items.Add(33);
            cmbReservas.Items.Add(34);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (verficarEntradas())
            {
                General general = new General(int.Parse(cmbReservas.SelectedItem.ToString()), int.Parse(txtCantidad.Text), int.Parse(txtDesde.Text), int.Parse(txtCantFilas.Text));
                Resultado resultado = new Resultado(general);
                resultado.Show();
            }
        }
    }
}
