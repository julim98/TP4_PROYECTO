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
        private List<int> vuelo = new List<int>();
        private List<double> rndPresentados = new List<double>();
        private List<int> presentados = new List<int>();
        private List<int> pasajerosReprogramados = new List<int>();
        private List<int> costoReprogramacion = new List<int>();
        private List<int> utilidad = new List<int>();
        private List<int> gananciaNeta = new List<int>();
        private List<int> acGanancia = new List<int>();
        private List<double> promedio = new List<double>();
        private int txtReservaciones;
        private int txtCantidadVuelos;
        private int txtDesde;
        private int txtFilasAMostrar;
        private Muestra ultimo;

        public List<int> Vuelo { get => vuelo; set => vuelo = value; }
        public List<double> RndPresentados { get => rndPresentados; set => rndPresentados = value; }
        public List<int> Presentados { get => presentados; set => presentados = value; }
        public List<int> PasajerosReprogramados { get => pasajerosReprogramados; set => pasajerosReprogramados = value; }
        public List<int> CostoReprogramacion { get => costoReprogramacion; set => costoReprogramacion = value; }
        public List<int> Utilidad { get => utilidad; set => utilidad = value; }
        public List<int> GananciaNeta { get => gananciaNeta; set => gananciaNeta = value; }
        public List<int> AcGanancia { get => acGanancia; set => acGanancia = value; }
        public List<double> Promedio { get => promedio; set => promedio = value; }
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

        public Muestra calcularPromedio()
        {
            Muestra muestraActual = new Muestra();
            Muestra muestraSiguiente = new Muestra();
            Random random = new Random();

            for (int i = 0; i < txtCantidadVuelos; i++)
            {
                if (i == 0)
                {
                    muestraActual = new Muestra(i + 1, 0, random);
                }
                else
                {
                    muestraActual = muestraSiguiente;
                }

                if (i + 1 >= txtDesde && i + 1 < txtDesde + txtFilasAMostrar)
                {
                    vuelo.Add(muestraActual.vuelo);
                    rndPresentados.Add(muestraActual.rndPresentados);
                    presentados.Add(muestraActual.presentados);
                    pasajerosReprogramados.Add(muestraActual.pasajerosReprogramados);
                    costoReprogramacion.Add(muestraActual.costoReprogramacion);
                    utilidad.Add(muestraActual.utilidad);
                    gananciaNeta.Add(muestraActual.gananciaNeta);
                    acGanancia.Add(muestraActual.acGanancia);
                    promedio.Add(muestraActual.promedio);
                }

                muestraSiguiente = new Muestra(i + 2, muestraActual.acGanancia, random);
            }
            ultimo = muestraActual;
            return muestraActual;
        }

        public void cargarTabla(DataGridView tabla)
        {
            DataTable dt = new DataTable();

            // agregamos las columnas y el tipo de dato que se manejara en cada una de ellas
            dt.Columns.Add("Vuelo", typeof(int));
            dt.Columns.Add("RND Presentados", typeof(double));
            dt.Columns.Add("Presentados", typeof(int));
            dt.Columns.Add("Reprogramados", typeof(int));
            dt.Columns.Add("Costo", typeof(int));
            dt.Columns.Add("Utilidad", typeof(int));
            dt.Columns.Add("Ganancia Neta", typeof(int));
            dt.Columns.Add("Ac. Ganancia", typeof(int));
            dt.Columns.Add("Promedio", typeof(double));


            // agregamos las columnas
            for (int i = 0; i < txtFilasAMostrar; i++)
            {
                dt.Rows.Add(vuelo[i], rndPresentados[i], presentados[i], pasajerosReprogramados[i], costoReprogramacion[i], utilidad[i], gananciaNeta[i], acGanancia[i], promedio[i]);
            }

            // agregamos la ultima fila
            dt.Rows.Add(ultimo.vuelo, ultimo.rndPresentados, ultimo.presentados, ultimo.pasajerosReprogramados, ultimo.costoReprogramacion, ultimo.utilidad, ultimo.gananciaNeta, ultimo.acGanancia, ultimo.promedio);

            // llenamos el datagridview con los datos del datatable
            tabla.DataSource = dt;
        }

    }
}
