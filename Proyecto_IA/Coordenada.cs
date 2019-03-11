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
        private int paso;

        public Coordenada()
        {
            CoordenadaX = -1;
            CoordenadaY = -1;
            Paso = 0;
        }

        public Coordenada(int _x, int _y, int _pasos)
        {
            CoordenadaX = _x;
            CoordenadaY = _y;
            Paso = _pasos;
        }

        public int CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
        public int CoordenadaY { get => coordenadaY; set => coordenadaY = value; }
        public int Paso { get => paso; set => paso = value; }
    }
}
