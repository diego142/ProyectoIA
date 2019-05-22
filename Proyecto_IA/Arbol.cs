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
        int fX;
        int fY;
        decimal gn;
        bool astar = false;
        

        public Arbol(List<Nodo> _nodos, List<Nodo> _nodosCerrados, bool _astar)
        {
            InitializeComponent();

            nodos = _nodos;
            nodosCerrados = _nodosCerrados;
            astar = _astar;
        }

        private void Arbol_Load(object sender, EventArgs e)
        {
            obtenerFinal();
            gn = 0;

            if (astar)
            {
                trazarRutaAS();
                depurarListaAS();
                marcarVisitadosAS();
                generarArbolAS();
            }
            else
            {
                depurarLista();
                marcarVisitados();
                trazarRuta();
                generarArbol();
                VistaArbol.Nodes[0].ExpandAll();
            }
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

        private void marcarVisitadosAS()
        {
            foreach (Nodo nodoActual in nodosCerrados)
            {
                foreach (Nodo padre in nodosCerrados)
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

        private void depurarListaAS()
        {
            for (int i = 0; i < nodosCerrados.Count; i++)
            {
                if (nodosCerrados[i].visitas.Count == 0)
                {
                    nodosCerrados.Remove(nodosCerrados[i]);
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

        private void obtenerFinal()
        {
            foreach (Nodo n in nodosCerrados)
            {
                if (n.final)
                {
                    fX = n.cX;
                    fY = n.cY;
                }
            }
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
                else
                {
                    nodoActual.Nodes.Add(nodos[pos].hijos[i] + " | No visitado");
                }
            }
            return;

        }

        private void generarArbolAS()
        {
            TreeNode nodoActual = VistaArbol.Nodes.Add(nodosCerrados[0].infoNodoAS(fX, fY, 0));
            gn = nodosCerrados[0].costo;
            generarArbolAS(nodoActual, 0);
        }

        private void generarArbolAS(TreeNode nodoActual, int pos)
        {
            int posAux;
            decimal gn_aux;
            TreeNode nodoAux;
            for (int i = 0; i < nodosCerrados[pos].hijos.Count; i++)
            {
                if (nodosCerrados[pos].hijosVisitados[i])
                {
                    nodoAux = nodoActual.Nodes.Add(nodosCerrados[obtenerPos(nodosCerrados[pos].hijos[i])].infoNodoAS(fX, fY, gn)); //truncar gn a 4
                    gn_aux = gn;
                    gn += nodosCerrados[pos].costo;
                    posAux = obtenerPos(nodosCerrados[pos].hijos[i]);
                    generarArbolAS(nodoAux, posAux);
                    gn = gn_aux;
                }
                else
                {
                    nodoActual.Nodes.Add(nodosCerrados[pos].hijos[i] + " | No visitado");
                }
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

        private void trazarRutaAS()
        {
            List<Nodo> ruta = new List<Nodo>();

            ruta.Add(nodosCerrados.Last());
            string padre = nodosCerrados.Last().padre;

            for (int i = 0; i < nodosCerrados.Count; i++)
            {

                if (padre == nodosCerrados[i].nombre)
                {
                    padre = nodosCerrados[i].padre;
                    ruta.Insert(0, nodosCerrados[i]);
                    i = -1;
                }
            }

            foreach (Nodo n in ruta)
            {
                lblRuta.Text += n.nombre;
                if (!n.final)
                {
                    lblRuta.Text += "->";
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
