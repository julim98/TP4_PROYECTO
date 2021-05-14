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
    public partial class Resultado : Form
    {

        public Resultado(General general)
        {
            InitializeComponent();
            Muestra ultimo = general.calcularPromedio();
            general.cargarTabla(dgvVuelos);
            txtPromedio.Text = ultimo.promedio.ToString();
        }
    }
}
