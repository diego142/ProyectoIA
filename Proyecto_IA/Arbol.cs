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
        public Arbol(List<Nodo> _nodos)
        {
            InitializeComponent();
            nodos = _nodos;
        }

        private void Arbol_Load(object sender, EventArgs e)
        {
            depurarLista();
            marcarVisitados();
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
            }
            return;

        }
    }
}
