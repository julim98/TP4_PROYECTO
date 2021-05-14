using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4_PROYECTO
{
    public class Muestra
    {
        public int vuelo;
        public double rndPresentados;
        public int presentados;
        public int pasajerosReprogramados;
        public int costoReprogramacion;
        public int utilidad;
        public int gananciaNeta;
        public long acGanancia;
        public double promedio;

        public Muestra()
        {

        }

        public Muestra(int vuelo, long acumulado, Random random, int seleccion)
        {
            this.vuelo = vuelo;
            this.rndPresentados = Math.Round(random.NextDouble(), 2);
            this.presentados = calcularIntervalo(this.rndPresentados, seleccion);
            this.pasajerosReprogramados = cantidadReprogramados(this.presentados, out int costo);
            this.costoReprogramacion = costo;
            this.utilidad = calcularUtilidad(this.presentados);
            this.gananciaNeta = this.utilidad - this.costoReprogramacion;
            this.acGanancia = gananciaNeta + acumulado;
            this.promedio = Math.Round((double)acGanancia / vuelo, 2);
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

        public int calcularIntervalo(double rndPepresentados, int seleccion)
        {
            if (seleccion == 31)
            {
                if (rndPepresentados < 0.10)
                {
                    return 28;
                }
                else if (rndPepresentados < 0.35)
                {
                    return 29;
                }
                else if (rndPepresentados < 0.85)
                {
                    return 30;
                }
                else
                {
                    return 31;
                }
            }
            else if (seleccion == 32)
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
            else if (seleccion == 33)
            {
                if (rndPepresentados < 0.05)
                {
                    return 29;
                }
                else if (rndPepresentados < 0.25)
                {
                    return 30;
                }
                else if (rndPepresentados < 0.7)
                {
                    return 31;
                }
                else if (rndPepresentados < 0.9)
                {
                    return 32;
                }
                else
                {
                    return 33;
                }
            }
            else
            {
                if (rndPepresentados < 0.05)
                {
                    return 29;
                }
                else if (rndPepresentados < 0.15)
                {
                    return 30;
                }
                else if (rndPepresentados < 0.55)
                {
                    return 31;
                }
                else if (rndPepresentados < 0.85)
                {
                    return 32;
                }
                else if (rndPepresentados < 0.95)
                {
                    return 33;
                }
                else
                {
                    return 34;
                }
            }
        }
    }
}
