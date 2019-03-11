using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_IA
{
    public partial class Laberinto : Form
    {
        List <Terreno> terrenos;
        List <Personaje> personajes;
        string[][] datos;
        static int CELL_WIDTH = 37;
        List<Coordenada> lista_pasos; 
        int numero_pasos;
        ToolTip informacion;
        Graphics coordenadas;
        Graphics graficosImg;
        SolidBrush pintaloDeBlanco;
        Font fuente;
        Font fuente2;
        Image banderaIni;
        Image banderaFin;
        string rutaI = "";
        string rutaF = "";

        Point coordenadaActual;
        Point coordenada_InicialXY;
        Point coordenada_FinalXY;

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
            fuente2 = new Font("Consolas", 8.0f, FontStyle.Regular);

            coordenadaActual = new Point(-1, -1);
            coordenada_InicialXY = new Point(-1, -1);
            coordenada_FinalXY = new Point(-1, -1);

            rutaI = Path.Combine(Application.StartupPath, @"..\..\Recursos\bandera_inicio.png");
            rutaF = Path.Combine(Application.StartupPath, @"..\..\Recursos\bandera_final.png");

            banderaIni = Image.FromFile(rutaI);
            banderaFin = Image.FromFile(rutaF);
            lista_pasos = new List<Coordenada>();
            numero_pasos = 1;
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

        private void agrearPasos(Personaje personaje)
        {
            foreach (Coordenada cordenada in lista_pasos)
            {
                if (cordenada.CoordenadaX == personaje.CoordenadaX && cordenada.CoordenadaY == personaje.CoordenadaY)
                {
                    cordenada.pasos.Add(numero_pasos);
                    return;
                }
            }

            lista_pasos.Add(new Coordenada(personaje.CoordenadaX, personaje.CoordenadaY, numero_pasos));
        }
        
        private bool validaMovimiento(string movimiento, Personaje personaje)
        {
            int cordX = personaje.CoordenadaX;
            int cordY = personaje.CoordenadaY;


            switch (movimiento)
            {
                case "arriba":
                    cordY -= 1;

                    if (cordY < 0)
                    {
                        MessageBox.Show("No puedes moverte fuera del mapa");
                        return false;
                    }

                    for (int i = 0; i < terrenos.Count; i++)
                    {
                        if (personaje.Terrenos[i] == int.Parse(datos[cordY][cordX]))
                        {
                            if (personaje.Costos[i] == -1)
                            {
                                return false;
                            }
                        }
                    }

                    break;

                case "derecha":
                    cordX += 1;
                    if (cordX > (datos[0].Length-1))
                    {
                        MessageBox.Show("No puedes moverte fuera del mapa");
                        return false;
                    }

                    for (int i = 0; i < terrenos.Count; i++)
                    {
                        if (personaje.Terrenos[i] == int.Parse(datos[cordY][cordX]))
                        {
                            if (personaje.Costos[i] == -1)
                            {
                                return false;
                            }
                        }
                    }

                    break;

                case "abajo":

                    cordY += 1;

                    if (cordY > (datos.Length-1))
                    {
                        MessageBox.Show("No puedes moverte fuera del mapa");
                        return false;
                    }

                    for (int i = 0; i < terrenos.Count; i++)
                    {
                        if (personaje.Terrenos[i] == int.Parse(datos[cordY][cordX]))
                        {
                            if (personaje.Costos[i] == -1)
                            {
                                return false;
                            }
                        }
                    }

                    break;

                case "izquierda":
                    cordX -= 1;
                    if (cordX < 0)
                    {
                        MessageBox.Show("No puedes moverte fuera del mapa");
                        return false;
                    }

                    for (int i = 0; i < terrenos.Count; i++)
                    {
                        if (personaje.Terrenos[i] == int.Parse(datos[cordY][cordX]))
                        {
                            if (personaje.Costos[i] == -1)
                            {
                                return false;
                            }
                        }
                    }

                    break;
            }

            return true;
        }

        private bool seLlegoAlFinal()
        {
            string nombre = cmbPersonaje.Text;

            foreach (Personaje personaje in personajes)
            {
                if (personaje.Nombre == nombre)
                {
                    if (personaje.CoordenadaX == coordenada_FinalXY.X && personaje.CoordenadaY == coordenada_FinalXY.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void reiniciar(int opc)
        {
            switch (opc)
            {
                case 0:
                    string nombre = cmbPersonaje.Text;
                    foreach (Personaje personaje in personajes)
                    {
                        if (nombre == personaje.Nombre)
                        {
                            personaje.CoordenadaX = -1;
                            personaje.CoordenadaY = -1;

                            coordenada_InicialXY.X = -1;
                            coordenada_InicialXY.Y = -1;

                            coordenada_FinalXY.X = -1;
                            coordenada_FinalXY.Y = -1;

                            btnElegir.Enabled = true;

                            cmbPersonaje.Enabled = true;
                            lista_pasos.Clear();
                            numero_pasos = 1;

                            panelMapa.Refresh();

                        }
                    }

                    break;
                case 1:
                    Application.Restart();
                    break;
            }
            
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

                if (informacion != null)
                {
                    informacion.Dispose();
                }

                char letra = 'A';

                letra += (char)(e.X / CELL_WIDTH);//Columnas
                String text = letra + ((e.Y / CELL_WIDTH) + 1).ToString();//Filas

                foreach (Personaje personaje in personajes)
                {

                    for (int j = 0; j < terrenos.Count; j++)
                    {
                        if (int.Parse(datos[e.Y / CELL_WIDTH][e.X / CELL_WIDTH]) == personaje.Terrenos[j])
                        {
                            text += '\n' + terrenos[j].Nombre;
                        }
                    }
                }
               
                foreach (Coordenada cord in lista_pasos)
                {
  
                    if ((e.X/CELL_WIDTH) == cord.CoordenadaX && (e.Y/CELL_WIDTH) == cord.CoordenadaY)
                    {
                        text = text + '\n' + cord.listaFormateada();
                    }
                }

                
                informacion = new ToolTip();

                informacion.Show(text, panelMapa, e.X, e.Y, 1500);
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
                string Dcolumnas = columnas.ToString();
                coordenadas.DrawString(Dcolumnas, fuente, pintaloDeBlanco, panelMapa.Location.X + (x * CELL_WIDTH),
                panelMapa.Location.Y - (CELL_WIDTH / 2));
                columnas += (char)1;
            }
        }

        private void panelMapa_Paint(object sender, PaintEventArgs e)
        {
            graficosImg = panelMapa.CreateGraphics();

            for (int i = 0; i < datos.Length; i++)
            {

                for (int j = 0; j < datos[0].Length; j++)
                {
                    Terreno terreno = obtenerTerreno(int.Parse(datos[i][j]));

                    graficosImg.DrawImage(terreno.Imagen, j * CELL_WIDTH, i * CELL_WIDTH);

                    if (coordenada_InicialXY.X == j && coordenada_InicialXY.Y == i)
                    {
                        graficosImg.DrawImage(banderaIni, coordenada_InicialXY.X * CELL_WIDTH, coordenada_InicialXY.Y * CELL_WIDTH, 20,20);
                    }

                    if (coordenada_FinalXY.X == j && coordenada_FinalXY.Y == i)
                    {
                        graficosImg.DrawImage(banderaFin, coordenada_FinalXY.X * CELL_WIDTH, coordenada_FinalXY.Y * CELL_WIDTH, 20, 20); 
                    }

                }
            }

            foreach (Personaje personaje in personajes)
            {
                graficosImg.DrawImage(personaje.Imagen, personaje.CoordenadaX * CELL_WIDTH, personaje.CoordenadaY * CELL_WIDTH, 30,30);
            }

            foreach(Coordenada coordenada in lista_pasos)
            {
                graficosImg.DrawString(coordenada.listaFormateada(), fuente2, pintaloDeBlanco, coordenada.CoordenadaX * CELL_WIDTH, coordenada.CoordenadaY * CELL_WIDTH);
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

                                lista_pasos.Add(new Coordenada(personaje.CoordenadaX, personaje.CoordenadaY, numero_pasos));

                                MessageBox.Show("Coordenada Inicial Seleccionada!");
                                panelMapa.Refresh();
                                btnCelda_Inicial.Enabled = false;
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
                                    btnCelda_Final.Enabled = false;
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

        private void btnElegir_Click(object sender, EventArgs e)
        {
            cmbPersonaje.Enabled = false;
            btnElegir.Enabled = false;

            btnCelda_Inicial.Enabled = true;
            btnCelda_Final.Enabled = true;
        }

        private void moverPersonajeArriba()
        {
            string personajeNombre = cmbPersonaje.Text;

            foreach (Personaje personaje in personajes)
            {
                if (personajeNombre == personaje.Nombre)
                {
                    if (validaMovimiento("arriba", personaje))
                    {
                        personaje.CoordenadaY -= 1; 
                        panelMapa.Refresh();
                        numero_pasos++;
                        agrearPasos(personaje);
                    }
                }
            }
        }

        private void moverPersonajeDerecha()
        {
            string personajeNombre = cmbPersonaje.Text;

            foreach (Personaje personaje in personajes)
            {
                if (personajeNombre == personaje.Nombre)
                {
                    if (validaMovimiento("derecha", personaje))
                    { 
                        personaje.CoordenadaX += 1;
                        panelMapa.Refresh();
                        numero_pasos++;
                        agrearPasos(personaje);

                    }
                }
            }
        }

        private void moverPersonajeAbajo()
        {
            string personajeNombre = cmbPersonaje.Text;

            foreach (Personaje personaje in personajes)
            {
                if (personajeNombre == personaje.Nombre)
                {
                    if (validaMovimiento("abajo", personaje))
                    {
                        personaje.CoordenadaY += 1;
                        panelMapa.Refresh();
                        numero_pasos++;
                        agrearPasos(personaje);
                    }

                }
            }
        }

        private void moverPersonajeIzquierda()
        {
            string personajeNombre = cmbPersonaje.Text;

            foreach (Personaje personaje in personajes)
            {
                if (personajeNombre == personaje.Nombre)
                {
                    if (validaMovimiento("izquierda", personaje))
                    {
                        personaje.CoordenadaX -= 1;
                        panelMapa.Refresh();
                        numero_pasos++;
                        agrearPasos(personaje);

                    }
                }
            }
        }

        private void Laberinto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
               case Keys.Up:
                    moverPersonajeArriba();
                    break;
                case Keys.Right:
                    moverPersonajeDerecha();
                    break;
                case Keys.Down:
                    moverPersonajeAbajo();
                    break;
                case Keys.Left:
                    moverPersonajeIzquierda();
                    break;              
            }

            if (seLlegoAlFinal())
            {
                MessageBox.Show("Llegaste a la meta");
                DialogResult opc = MessageBox.Show("¿Quieres volver a jugar?", "Juego terminado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opc == DialogResult.Yes)
                {
                    reiniciar(0);
                }
                else
                {
                    reiniciar(1);
                }
            }
        }
    }
}
