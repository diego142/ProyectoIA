using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA
{
    class Nodo
    {
        public string padre;
        public string nombre;
        public int cX;
        public int cY;
        public decimal costo;
        public bool inicial;
        public bool final;
        public List<int> visitas = new List<int>();
        public List<string> hijos = new List<string>();

        public Nodo(string _padre, int _cx, int _cy, decimal _costo, bool _inicial, bool _final)
        {
            padre = _padre;
            cX = _cx;
            cY = _cy;
            costo = _costo;
            inicial = _inicial;
            final = _final;
            nombre = generarNombre();
        }

        private string generarNombre()
        {
            string coord = "";
            char col = 'A';

            col += (char)cX;
            coord = col + (cY + 1).ToString();
            return coord;
        }

    }
}

