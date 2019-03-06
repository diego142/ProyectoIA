using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA
{
    public class Terreno
    {
        private int codigo;
        private string nombre;
        private Color color;
        private Image imagen;

        public Terreno() {
            codigo = -1;
            nombre = null;
            color = Color.Transparent;
            imagen = null;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public Color Color { get => color; set => color = value; }
        public Image Imagen { get => imagen; set => imagen = value; }
    }
}
