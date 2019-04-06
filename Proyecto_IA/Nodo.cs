﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IA
{
    public class Nodo
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
        public List<bool> hijosVisitados = new List<bool>();

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

        private string vis2str()
        {
            string texto = "";
            for(int i = 0; i < visitas.Count; i++)
            {
                texto = texto + visitas[i];
                if (i + 1 < visitas.Count)
                {
                    texto += ", ";
                }
            }
            return texto;
        }

        private bool esAbierto()
        {
            for (int i = 0; i < hijosVisitados.Count; i++)
            {
                if (hijosVisitados[i] == false)
                {
                    return true;
                }
            }
            return false;
        }

        public string infoNodo()
        {
            string info = "";

            info += nombre + " | " + "Visitas: " + vis2str() + " | " + "Costo: " + costo + " | ";
            if (inicial)
            {
                info += "Estado: Inicial" + " | ";
            }
            else if (final)
            {
                info += "Estado: Final" + " | ";
            }

            if (esAbierto())
            {
                info += "Abierto";
            }
            else
            {
                info += "Cerrado";
            }

            return info;
        }

    }
}

