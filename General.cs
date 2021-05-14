using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace TP4_PROYECTO
{
    public class General
    {
        private int txtReservaciones;
        private int txtCantidadVuelos;
        private int txtDesde;
        private int txtFilasAMostrar;

        public int TxtReservaciones { get => txtReservaciones; set => txtReservaciones = value; }
        public int TxtCantidadVuelos { get => txtCantidadVuelos; set => txtCantidadVuelos = value; }
        public int TxtDesde { get => txtDesde; set => txtDesde = value; }
        public int TxtFilasAMostrar { get => txtFilasAMostrar; set => txtFilasAMostrar = value; }

        public General(int txtReservaciones, int txtCantidadVuelos, int txtDesde, int txtFilasAMostrar)
        {
            TxtReservaciones = txtReservaciones;
            TxtCantidadVuelos = txtCantidadVuelos;
            TxtDesde = txtDesde;
            TxtFilasAMostrar = txtFilasAMostrar;
        }

        public void cargarTabla(DataGridView tabla, TextBox promedio)
        {
            Muestra muestraActual = new Muestra();
            Muestra muestraSiguiente = new Muestra();
            Random random = new Random();

            DataTable dt = new DataTable();
            tabla.DataSource = dt;

            // agregamos las columnas y el tipo de dato que se manejara en cada una de ellas
            dt.Columns.Add("Vuelo", typeof(int));
            dt.Columns.Add("RND Presentados", typeof(double));
            dt.Columns.Add("Presentados", typeof(int));
            dt.Columns.Add("Reprogramados", typeof(int));
            dt.Columns.Add("Costo", typeof(int));
            dt.Columns.Add("Utilidad", typeof(int));
            dt.Columns.Add("Ganancia Neta", typeof(int));
            dt.Columns.Add("Ac. Ganancia", typeof(long));
            dt.Columns.Add("Promedio", typeof(double));

            // creamos las muestras y cargamos a la dt las solicitadas
            for (int i = 0; i < txtCantidadVuelos; i++)
            {
                if (i == 0)
                {
                    muestraActual = new Muestra(i + 1, 0, random, txtReservaciones);
                }
                else
                {
                    muestraActual = muestraSiguiente;
                }

                if (i + 1 >= txtDesde && i + 1 < txtDesde + txtFilasAMostrar)
                {
                    dt.Rows.Add(muestraActual.vuelo, muestraActual.rndPresentados, muestraActual.presentados, muestraActual.pasajerosReprogramados, muestraActual.costoReprogramacion, muestraActual.utilidad, muestraActual.gananciaNeta, muestraActual.acGanancia, muestraActual.promedio);
                }

                muestraSiguiente = new Muestra(i + 2, muestraActual.acGanancia, random, txtReservaciones);
            }

            // agregamos la ultima fila
            dt.Rows.Add(muestraActual.vuelo, muestraActual.rndPresentados, muestraActual.presentados, muestraActual.pasajerosReprogramados, muestraActual.costoReprogramacion, muestraActual.utilidad, muestraActual.gananciaNeta, muestraActual.acGanancia, muestraActual.promedio);

            // llenamos el datagridview con los datos del datatable
            tabla.DataSource = dt;

            // asigno el promedio al txt asociado
            promedio.Text = muestraActual.promedio.ToString();
        }
    }
}
