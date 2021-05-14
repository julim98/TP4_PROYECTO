﻿using System;
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
            general.cargarTabla(dgvVuelos, txtPromedio);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
