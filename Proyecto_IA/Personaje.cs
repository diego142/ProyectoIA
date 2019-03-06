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
        int[] costos;
        int coordenadaX;
        int coordenadaY;

        public Personaje()
        {
            nombre = "";
            imagen = null;
            terrenos = new int[15];
            costos = new int[15];
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
        public int[] Costos { get => costos; set => costos = value; }
        public int CoordenadaX { get => coordenadaX; set => coordenadaX = value;}
        public int CoordenadaY { get => coordenadaY; set => coordenadaY = value;}



        public int obtenerPosicionTerreno(int terreno)
        {
            for (int i = 0; i < 15; i++)
            {
                if (terrenos[i] == terreno)
                {
                    return i;
                }
            }
            return -1;
        }

        public int obtenerPosicionPrecio(int costo)
        {
            for (int i = 0; i < 15; i++)
            {
                if (costos[i] == costo)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
