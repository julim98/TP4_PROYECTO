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
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += delegate (object s, EventArgs ee)
            {
                ((Timer)s).Stop();
                general.cargarTabla(dgvVuelos, txtPromedio);
            };
            timer.Start();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Resultado_Load(object sender, EventArgs e)
        {

        }
    }
}
