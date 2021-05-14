using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_PROYECTO
{
    class Muestra
    {
        public int vuelo;
        public double rndPresentados;
        public int presentados;
        public int pasajerosReprogramados;
        public int costoReprogramacion;
        public int utilidad;
        public int gananciaNeta;
        public int acGanancia;
        public double promedio;

        public Muestra()
        {

        }

        public Muestra(int vuelo, int acGanancia)
        {
            Random random = new Random();
            this.vuelo = vuelo;
            this.rndPresentados = random.NextDouble();
            this.presentados = calcularIntervalo(this.rndPresentados);
            this.pasajerosReprogramados = cantidadReprogramados(this.presentados, out int costo);
            this.costoReprogramacion = costo;
            this.utilidad = calcularUtilidad(this.presentados);
            this.gananciaNeta = this.utilidad - this.costoReprogramacion;
            this.acGanancia = gananciaNeta + acGanancia;
            this.promedio = this.acGanancia / vuelo;
        }



        private int cantidadReprogramados(int presentados, out int costo)
        {
            if (presentados - 30 > 0)
            {
                costo = (presentados - 30) * 150;
                return presentados - 30;
            }
            else
            {
                costo = 0;
                return 0;
            }
        }

        private int calcularUtilidad(int presentados)
        {
            if (presentados > 30)
            {
                return 3000;
            }
            else return presentados * 100;
        }

        public int calcularIntervalo(double rndPepresentados)
        {
            if (rndPepresentados < 0.05)
            {
                return 28;
            }
            else if (rndPepresentados < 0.3)
            {
                return 29;
            }
            else if (rndPepresentados < 0.8)
            {
                return 30;
            }
            else if (rndPepresentados < 0.95)
            {
                return 31;
            }
            else
            {
                return 32;
            }
        }
    }
}
