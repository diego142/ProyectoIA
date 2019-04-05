using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_IA
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*List<Coordenada> lista = new List<Coordenada>();
            lista.Add(new Coordenada(1, 1, 1));
            lista.Add(new Coordenada(1, 0, 1));
            lista.Add(new Coordenada(1, 1, 1));
            lista.Add(new Coordenada(0, 1, 1));
            lista.Add(new Coordenada(1, 2, 1));
            lista.Add(new Coordenada(2, 1, 1));


            Application.Run(new Arbol(lista));*/
            //Application.Run(new Inicio());
            Application.Run(new Configuracion(new Inicio()));
        }
    }
}
