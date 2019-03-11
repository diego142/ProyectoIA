using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA
{
    class Coordenada
    {
        private int coordenadaX;
        private int coordenadaY;
        public List<int> pasos = new List<int>();

        public Coordenada()
        {
            CoordenadaX = -1;
            CoordenadaY = -1;
        }

        public Coordenada(int _x, int _y, int _paso)
        {
            CoordenadaX = _x;
            CoordenadaY = _y;
            pasos.Add(_paso);
        }

        public int CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
        public int CoordenadaY { get => coordenadaY; set => coordenadaY = value; }

        public string listaFormateada()
        {
            string texto = "";
            int cont = 1;
            foreach (int num in pasos)
            {
                texto = texto + num.ToString() + ",";
                if (cont == 2)
                {
                    texto += '\n';
                    cont = 1;
                }
                else {
                    cont++;
                }
            }
            return texto;

        }
    }
}
