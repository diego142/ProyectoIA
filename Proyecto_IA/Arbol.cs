using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_IA
{
    public partial class Arbol : Form
    {
        List<Coordenada> lista_pasos;
        public Arbol(List<Coordenada> _lista)
        {
            InitializeComponent();
            lista_pasos = _lista;
        }

        private void Arbol_Load(object sender, EventArgs e)
        {
            //generarArbol();
        }

        private string formatearCoord(int x, int y)
        {
            string coord = "";
            char col = 'A';

            col += (char)x;
            coord = col + y.ToString();
            return coord;
        }

        private bool esAdyacente(Coordenada actual, Coordenada ady)
        {
            if ((actual.CoordenadaX + 1) == ady.CoordenadaX && actual.CoordenadaY == ady.CoordenadaY ) { return true; }
            if (actual.CoordenadaX == ady.CoordenadaX && (actual.CoordenadaY + 1) == ady.CoordenadaY ) { return true; }
            if ((actual.CoordenadaX - 1) == ady.CoordenadaX && actual.CoordenadaY == ady.CoordenadaY ) { return true; }
            if (actual.CoordenadaX == ady.CoordenadaX && (actual.CoordenadaY -1) == ady.CoordenadaY ) { return true; }

            return false;
        }

        /*private void generarArbol()
        {
            string previo = "";
            string nombreNodo = "";
            string raiz;
           
            raiz = formatearCoord(lista_pasos[0].CoordenadaX, lista_pasos[0].CoordenadaY);
            VistaArbol.Nodes.Add(raiz, raiz);

            foreach (Coordenada nodoActual in lista_pasos)
            {
                previo = formatearCoord(nodoActual.CoordenadaX, nodoActual.CoordenadaY);
                Console.WriteLine("previo: "+previo);

                foreach (Coordenada nodo in lista_pasos)
                {
                    nombreNodo = formatearCoord(nodo.CoordenadaX, nodo.CoordenadaY);

                    if (esAdyacente(nodoActual, nodo) && previo != nombreNodo)
                    {
                        TreeNode[] result = VistaArbol.Nodes.Find(previo, true);

                        VistaArbol.SelectedNode = result[0];
                        VistaArbol.SelectedNode.Nodes.Add(nombreNodo, nombreNodo);
                        Console.WriteLine("nombreNodo: " + nombreNodo);
                        //Console.WriteLine("index: " + VistaArbol.n);
                        
                    }
                }
            }
        }*/
    }
}
