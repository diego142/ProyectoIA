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
        List<Nodo> nodos;
        List<Nodo> nodosCerrados;

        public Arbol(List<Nodo> _nodos, List<Nodo> _nodosCerrados)
        {
            InitializeComponent();

            nodos = _nodos;
            nodosCerrados = _nodosCerrados;
        }

        private void Arbol_Load(object sender, EventArgs e)
        {
            depurarLista();
            marcarVisitados();
            trazarRuta();
            generarArbol();
            VistaArbol.Nodes[0].ExpandAll();
        }

        private void marcarVisitados()
        {
            foreach (Nodo nodoActual in nodos)
            {
                foreach (Nodo padre in nodos)
                {
                    if (nodoActual.padre == padre.nombre)
                    {
                        for (int i = 0; i < padre.hijos.Count; i++)
                        {
                            if (nodoActual.nombre == padre.hijos[i])
                            {
                                padre.hijosVisitados[i] = true;
                            }
                        }
                    }
                }
            }
        }

        private bool esPadre(string padre, string hijoP)
        {
            return true;
        }

        private void depurarLista()
        {
            for(int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].visitas.Count == 0)
                {
                    nodos.Remove(nodos[i]);
                }
            }
        }

        private int obtenerPos(string nombreNodo)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].nombre == nombreNodo)
                {
                    return i;
                }
            }
            return -1;
        }

        private void generarArbol()
        {
            TreeNode nodoActual = VistaArbol.Nodes.Add(nodos[0].infoNodo());
            generarArbol(nodoActual, 0);
        }

        private void generarArbol(TreeNode nodoActual, int pos)
        {
            int posAux;
            TreeNode nodoAux;
            for (int i = 0; i < nodos[pos].hijos.Count; i++)
            {
                if (nodos[pos].hijosVisitados[i])
                {
                    nodoAux = nodoActual.Nodes.Add(nodos[obtenerPos(nodos[pos].hijos[i])].infoNodo());
                    posAux = obtenerPos(nodos[pos].hijos[i]);
                    generarArbol(nodoAux, posAux);
                }
                /*else
                {
                    nodoActual.Nodes.Add(nodos[pos].hijos[i] + " | No visitado");
                }*/
            }
            return;

        }

        private void trazarRuta()
        { 
            lblRuta.Text += nodos.First().nombre + "->";

            foreach (Nodo nodo in nodos)
            {
                for (int i = 0; i < nodo.hijos.Count; i++)
                {
                    //si el hijo no se encuentra en los nodos cerrados
                    if (!estaCerrado(nodo.hijos[i]) && nodo.hijosVisitados[i])
                    {
                        lblRuta.Text += nodo.hijos[i];
                        if (!esNodoFinal(nodo.hijos[i]))
                        {
                            lblRuta.Text += "->";
                        }
                    }
                }
            }
        }

        private bool estaCerrado(string nodo)
        {
            foreach (Nodo nodoC in nodosCerrados)
            {
                if (nodoC.nombre == nodo)
                {
                    return true;
                }
            }
            return false;
        }

        private bool esNodoFinal(string nodo)
        {
            foreach (Nodo n in nodos)
            {
                if (n.final)
                {
                    if (n.nombre == nodo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
