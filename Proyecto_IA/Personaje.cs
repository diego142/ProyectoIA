using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA
{
    public class Personaje
    {
        string nombre;
        Image imagen;
        int[] terrenos;
        decimal[] costos;
        int coordenadaX;
        int coordenadaY;

        public Personaje()
        {
            nombre = "";
            imagen = null;
            terrenos = new int[15];
            costos = new decimal[15];
            coordenadaX = -1;
            coordenadaY = -1;


            for (int i = 0; i < 15; i++)
            {
                costos[i] = -1;
            }
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public Image Imagen { get => imagen; set => imagen = value; }
        public int[] Terrenos { get => terrenos; set => terrenos = value; }
        public decimal[] Costos { get => costos; set => costos = value; }
        public int CoordenadaX { get => coordenadaX; set => coordenadaX = value;}
        public int CoordenadaY { get => coordenadaY; set => coordenadaY = value;}

    }
}
