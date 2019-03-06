using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Proyecto_IA
{
    public partial class Laberinto : Form
    {
        List <Terreno> terrenos;
        List <Personaje> personajes;
        string[][] datos;
        static int CELL_WIDTH = 30;
        ToolTip inform;
        Graphics coordenadas;
        Font fuente;
        SolidBrush pintaloDeBlanco;
        Brush cInicial;

        Point coordenadaActual;
        Point coordenada_InicialXY;
        Point coordenada_FinalXY;

        Graphics graficos;

        public Laberinto(List<Terreno> _terrenos, List<Personaje> _personajes, string[][] _datos)
        {
            InitializeComponent();

            terrenos = _terrenos;
            personajes = _personajes;
            datos = _datos;

            panelMapa.Width = 0;
            panelMapa.Height = 0;

            pintaloDeBlanco = new SolidBrush(Color.White);
            fuente = new Font("Consolas", 12.0f, FontStyle.Bold);
            cInicial = new SolidBrush(Color.Green);

            coordenadaActual = new Point(-1, -1);
            coordenada_InicialXY = new Point(-1, -1);
            coordenada_FinalXY = new Point(-1, -1);
        }

        private void Laberinto_Load(object sender, EventArgs e)
        {
            foreach (Personaje personaje in personajes)
            {
                cmbPersonaje.Items.Add(personaje.Nombre);
            }
            cmbPersonaje.SelectedIndex = 0;
        }

        private Terreno obtenerTerreno(int cod)
        {
            foreach (Terreno terreno in terrenos)
            {
                if (terreno.Codigo == cod)
                {
                    return terreno;
                }
            }
            return new Terreno();
        }

        private void cmbPersonaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvpropiedades.Rows.Clear();
            string nombre = cmbPersonaje.Text;
            

            foreach (Personaje personaje in personajes)
            {
                if (nombre == personaje.Nombre)
                {
                    pbPersonaje.Image = personaje.Imagen;
                    int tam = terrenos.Count();
                    for (int i = 0; i < tam; i++)
                    {
                        dgvpropiedades.Rows.Add(terrenos[i].Nombre, personaje.Terrenos[i], personaje.Costos[i]);
                    }
                }
            }
        }

        private void panelMapa_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                if (inform != null)
                {
                    inform.Dispose();
                }

                char letra = 'A';
               
                letra += (char)(e.X / CELL_WIDTH);
                String text = letra + ((e.Y / CELL_WIDTH) + 1).ToString();

                inform = new ToolTip();

                inform.Show(text, panelMapa, e.X, e.Y - 10, 800);
            }

            else if ((e.Button == MouseButtons.Left))
            {
                coordenadaActual.X = e.X / CELL_WIDTH;
                coordenadaActual.Y = e.Y / CELL_WIDTH;

                char letra = 'A';
                letra += (char)coordenadaActual.X;
                labelX.Text = letra.ToString();
                labelY.Text = (coordenadaActual.Y + 1).ToString();
            }
        }

        private void Laberinto_Paint(object sender, PaintEventArgs e)
        {
            panelMapa.Width = datos[0].Length * CELL_WIDTH;
            panelMapa.Height = datos.Length * CELL_WIDTH;

            char columnas = 'A';

            coordenadas = this.CreateGraphics();
           
     
            for (int y = 0; y < datos.Length; y++)//Filas
            {
                string filas = (y + 1).ToString();
                coordenadas.DrawString(filas, fuente, pintaloDeBlanco, panelMapa.Location.X - CELL_WIDTH - 1, 
                panelMapa.Location.Y + (y * CELL_WIDTH) + (CELL_WIDTH / 2));
            }

            for (int x = 0; x < datos[0].Length; x++)//Columnas
            {
                string text = columnas.ToString();
                coordenadas.DrawString(text, fuente, pintaloDeBlanco, panelMapa.Location.X + (x * CELL_WIDTH),
                panelMapa.Location.Y - (CELL_WIDTH / 2));
                columnas += (char)1;
            }
        }

        private void panelMapa_Paint(object sender, PaintEventArgs e)
        {
            graficos = panelMapa.CreateGraphics();
            String I = "I";

            for (int i = 0; i < datos.Length; i++)
            {
                int col = datos[0].Length;

                for (int j = 0; j < col; j++)
                {
                    Terreno terreno = obtenerTerreno(int.Parse(datos[i][j]));

                    graficos.DrawImage(terreno.Imagen, j * CELL_WIDTH, i * CELL_WIDTH);

                    if (coordenada_InicialXY.X == j && coordenada_InicialXY.Y == i)
                    {
                        //graficos.FillRectangle(cInicial, coordenada_InicialXY.X * CELL_WIDTH, coordenada_InicialXY.Y * CELL_WIDTH,
                        //CELL_WIDTH,CELL_WIDTH);
                        // *DIBUJAR UNA I*
                        graficos.DrawString(I, fuente, pintaloDeBlanco, coordenada_InicialXY.X * CELL_WIDTH, coordenada_InicialXY.Y * CELL_WIDTH);
                    }

                    if (coordenada_FinalXY.X == j && coordenada_FinalXY.Y == i)
                    {
                        graficos.FillRectangle(cInicial, coordenada_FinalXY.X * CELL_WIDTH, coordenada_FinalXY.Y * CELL_WIDTH,
                            CELL_WIDTH, CELL_WIDTH);
                    }

                }
            }
        }

        private void btnCelda_Inicial_Click(object sender, EventArgs e)
        {
            string nombre = cmbPersonaje.Text;

            foreach (Personaje personaje in personajes)
            {
                if (nombre == personaje.Nombre)
                {
                    for(int i=0; i < terrenos.Count; i++)
                    {
                        if (int.Parse(datos[coordenadaActual.Y][coordenadaActual.X]) == personaje.Terrenos[i])
                        {
                           
                            if (personaje.Costos[i] == -1)
                            {
                                MessageBox.Show("No se puede inicializar ahí!");
                            }
                            else
                            {
                                coordenada_InicialXY.X = coordenadaActual.X;
                                coordenada_InicialXY.Y = coordenadaActual.Y;

                                personaje.CoordenadaX = coordenadaActual.X;
                                personaje.CoordenadaY = coordenadaActual.Y;

                                MessageBox.Show("Coordenada Inicial Seleccionada!");
                                panelMapa.Refresh();

                            }
                        }
                    }                   
                }
            }   
        }

        private void btnCelda_Final_Click(object sender, EventArgs e)
        {
            string nombre = cmbPersonaje.Text;

            if (coordenadaActual.X == coordenada_InicialXY.X && coordenadaActual.Y == coordenada_InicialXY.Y)
            {
                MessageBox.Show("No puedes asignar la coordenada Final en la Inicial!");
            }
            else
            {
                foreach (Personaje personaje in personajes)
                {
                    if (nombre == personaje.Nombre)
                    {
                        for (int i = 0; i < terrenos.Count; i++)
                        {
                            if (int.Parse(datos[coordenadaActual.Y][coordenadaActual.X]) == personaje.Terrenos[i])
                            {

                                if (personaje.Costos[i] == -1)
                                {
                                    MessageBox.Show("No se puede inicializar ahí!");
                                }
                                else
                                {
                                    coordenada_FinalXY.X = coordenadaActual.X;
                                    coordenada_FinalXY.Y = coordenadaActual.Y;

                                    MessageBox.Show("Coordenada Final Seleccionada!");
                                    panelMapa.Refresh();
                                }

                            }
                        }
                    }
                }
            }
        }

        private void Laberinto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
