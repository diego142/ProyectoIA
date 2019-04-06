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
using System.Media;

namespace Proyecto_IA
{
    public partial class Laberinto : Form
    {
        Form frmConfiguracion;
        List<Terreno> terrenos;
        List<Personaje> personajes;
        string[][] datos;
        static int CELL_WIDTH = 37;
        List<Coordenada> lista_pasos;
        List<Nodo> nodos;
        int numero_pasos;
        ToolTip informacion;
        Graphics coordenadas;
        Graphics graficosImg;
        SolidBrush pintaloDeBlanco;
        Font fuente;
        Font fuente2;
        Image banderaIni;
        Image banderaFin;
        Image niebla;
        string rutaI = "";
        string rutaF = "";
        string rutaNiebla = "";
        string rutaMusica = "";
        string rutaMovimiento = "";

        Point coordenadaActual;
        Point coordenada_InicialXY;
        Point coordenada_FinalXY;
        SoundPlayer sound;
        SoundPlayer soundMove;

        bool jugando;

        public Laberinto(List<Terreno> _terrenos, List<Personaje> _personajes, string[][] _datos, Form _frm)
        {
            InitializeComponent();
            frmConfiguracion = _frm;

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
            rutaNiebla = Path.Combine(Application.StartupPath, @"..\..\Recursos\niebla.png");
            rutaMusica = Path.Combine(Application.StartupPath, @"..\..\Recursos\song_laberinto.wav");
            rutaMovimiento = Path.Combine(Application.StartupPath, @"..\..\Recursos\movimiento.wav");

            banderaIni = Image.FromFile(rutaI);
            banderaFin = Image.FromFile(rutaF);
            niebla = Image.FromFile(rutaNiebla);
            lista_pasos = new List<Coordenada>();
            nodos = new List<Nodo>();
            numero_pasos = 1;
            jugando = false;

            sound = new SoundPlayer(rutaMusica);
            soundMove = new SoundPlayer(rutaMovimiento);
        }

        private void Laberinto_Load(object sender, EventArgs e)
        {
            foreach (Personaje personaje in personajes)
            {
                cmbPersonaje.Items.Add(personaje.Nombre);
            }
            cmbPersonaje.SelectedIndex = 0;
        }   //Cargo los nomnbres de todos los personajes y por default se deja el primero

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
        }       //Se busca el terreno a partir de su codigo asignado

        private int obtenerCosto(int cod)
        {
            for (int i = 0; i < terrenos.Count; i++)
            {
                if (terrenos[i].Codigo == cod)
                {
                    return i;
                }
            }
            return -1;
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
        } //Se agrega una coordenada a la lista de pasos

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
                    if (cordX > (datos[0].Length - 1))
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

                    if (cordY > (datos.Length - 1))
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
        } //Valida si el movimiento que hace el usuario esta permitido

        private bool seLlegoAlFinal()
        {
            string nombre = cmbPersonaje.Text;

            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == nombre);

            if (personaje.CoordenadaX == coordenada_FinalXY.X && personaje.CoordenadaY == coordenada_FinalXY.Y)
            {
                return true;
            }
            
            return false;
        }   //Verifica si el personaje llego a la coordenada final

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
                            btnRegresar.Enabled = true;

                            cmbPersonaje.Enabled = true;
                            lista_pasos.Clear();
                            nodos.Clear();
                            numero_pasos = 1;
                            jugando = false;

                            panelMapa.Refresh();

                        }
                    }

                    break;
                case 1:
                    Application.Restart();
                    break;
            }

        }   //Metodo para reinicar juego o reiniciar aplicación

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
        }   //Se actualizan los datos del personaje escogido en el Dtg y la imagen

        private void panelMapa_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                if (informacion != null)
                {
                    informacion.Dispose();
                }

                char columnas = 'A';

                columnas += (char)(e.X / CELL_WIDTH);//Columnas
                String texto = columnas + ((e.Y / CELL_WIDTH) + 1).ToString();//Filas

                foreach (Personaje personaje in personajes)
                {

                    for (int j = 0; j < terrenos.Count; j++)
                    {
                        if (int.Parse(datos[e.Y / CELL_WIDTH][e.X / CELL_WIDTH]) == personaje.Terrenos[j])
                        {
                            texto += '\n' + terrenos[j].Nombre;
                        }
                    }
                }

                foreach (Coordenada cord in lista_pasos)
                {

                    if ((e.X / CELL_WIDTH) == cord.CoordenadaX && (e.Y / CELL_WIDTH) == cord.CoordenadaY)
                    {
                        texto = texto + '\n' + cord.listaFormateada();
                    }
                }


                informacion = new ToolTip();

                informacion.Show(texto, panelMapa, e.X, e.Y, 1500);
            }

            else if ((e.Button == MouseButtons.Left))
            {
                coordenadaActual.X = e.X / CELL_WIDTH;
                coordenadaActual.Y = e.Y / CELL_WIDTH;

                char columnas = 'A';
                columnas += (char)coordenadaActual.X;
                labelX.Text = columnas.ToString();
                labelY.Text = (coordenadaActual.Y + 1).ToString();
            }
        }   //Detecta los clicks que se han hecho en el panel

        private void Laberinto_Paint(object sender, PaintEventArgs e)
        {
            panelMapa.Width = datos[0].Length * CELL_WIDTH;
            panelMapa.Height = datos.Length * CELL_WIDTH;

            char columnas = 'A';

            coordenadas = this.CreateGraphics();


            for (int y = 0; y < datos.Length; y++)//Filas
            {
                string filas = (y + 1).ToString();
                coordenadas.DrawString(filas, fuente, pintaloDeBlanco, panelMapa.Location.X - 30,
                panelMapa.Location.Y + (y * CELL_WIDTH) + 10);
            }

            for (int x = 0; x < datos[0].Length; x++)//Columnas
            {
                string Dcolumnas = columnas.ToString();
                coordenadas.DrawString(Dcolumnas, fuente, pintaloDeBlanco, panelMapa.Location.X + (x * CELL_WIDTH) + 10,
                panelMapa.Location.Y - 20);
                columnas += (char)1;
            }
        }       //Método para dibujar las coordenadas alrededor el panelmapa

        private void panelMapa_Paint(object sender, PaintEventArgs e)
        {
            graficosImg = panelMapa.CreateGraphics();

            for (int i = 0; i < datos.Length; i++)
            {
                for (int j = 0; j < datos[0].Length; j++)
                {
                    if (jugando)
                    {
                        graficosImg.DrawImage(niebla, j * CELL_WIDTH, i * CELL_WIDTH);
                    }
                    else
                    {
                        Terreno terreno = obtenerTerreno(int.Parse(datos[i][j]));

                        graficosImg.DrawImage(terreno.Imagen, j * CELL_WIDTH, i * CELL_WIDTH);
                    }
                }
            }
            if (jugando)
            {
                desenmascarar();
            }
            graficosImg.DrawImage(banderaIni, coordenada_InicialXY.X * CELL_WIDTH, coordenada_InicialXY.Y * CELL_WIDTH, 20, 20);
            graficosImg.DrawImage(banderaFin, coordenada_FinalXY.X * CELL_WIDTH, coordenada_FinalXY.Y * CELL_WIDTH, 20, 20);


            foreach (Personaje personaje in personajes)
            {
                graficosImg.DrawImage(personaje.Imagen, personaje.CoordenadaX * CELL_WIDTH, personaje.CoordenadaY * CELL_WIDTH, 30,30);
            }

            foreach(Coordenada coordenada in lista_pasos)
            {
                graficosImg.DrawString(coordenada.listaFormateada(), fuente2, pintaloDeBlanco, coordenada.CoordenadaX * CELL_WIDTH, coordenada.CoordenadaY * CELL_WIDTH);
            }

        }   //Se dibujan los terrenos, personaje, coordenada inicial y final y lista de pasos

        private void btnCelda_Inicial_Click(object sender, EventArgs e)
        {
            if (coordenadaActual.X == -1 || coordenadaActual.Y == -1)
            {
                MessageBox.Show("Por favor elija una coordenada <3");
            }
            else
            {
                string nombre = cmbPersonaje.Text;
                Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == nombre);

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
                            coordenada_InicialXY.X = coordenadaActual.X;
                            coordenada_InicialXY.Y = coordenadaActual.Y;

                            personaje.CoordenadaX = coordenadaActual.X;
                            personaje.CoordenadaY = coordenadaActual.Y;

                            lista_pasos.Add(new Coordenada(personaje.CoordenadaX, personaje.CoordenadaY, numero_pasos));
                            nodos.Add(new Nodo("", personaje.CoordenadaX, personaje.CoordenadaY, 0, true, false));
                            nodos.Last().visitas.Add(numero_pasos);


                            MessageBox.Show("Coordenada Inicial Seleccionada!");
                            panelMapa.Refresh();
                            btnCelda_Inicial.Enabled = false;
                        }
                    }
                }

                btnCelda_Final.Enabled = true;
            }
        }   //Btn para escoger la coordenada inicial

        private void btnCelda_Final_Click(object sender, EventArgs e)
        {
            string nombre = cmbPersonaje.Text;

            if (coordenadaActual.X == coordenada_InicialXY.X && coordenadaActual.Y == coordenada_InicialXY.Y)
            {
                MessageBox.Show("No puedes asignar la coordenada Final en la Inicial!");
            }
            else
            {
                Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == nombre);

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
                            jugando = true;
                            panelMapa.Refresh();
                            btnCelda_Final.Enabled = false;
                            btnRegresar.Enabled = false;
                        }

                    }
                }

            }
            panelMapa.Focus();
        }   ////Btn para escoger la coordenada final

        private void Laberinto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }   //Salir de la aplicacion

        private void btnElegir_Click(object sender, EventArgs e)
        {
            cmbPersonaje.Enabled = false;
            btnElegir.Enabled = false;

            btnCelda_Inicial.Enabled = true;
        }   //Desbloqueo los otros botones después de elegir un personaje

        private void moverPersonajeArriba()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("arriba", personaje))
            {
                personaje.CoordenadaY -= 1; 
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo();
                panelMapa.Refresh();
            }       
        }

        private void moverPersonajeDerecha()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("derecha", personaje))
            { 
                personaje.CoordenadaX += 1;
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo();
                panelMapa.Refresh();

            }
        }

        private void moverPersonajeAbajo()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("abajo", personaje))
            {
                personaje.CoordenadaY += 1;
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo();
                panelMapa.Refresh();
            }
        }

        private void moverPersonajeIzquierda()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("izquierda", personaje))
            {
                personaje.CoordenadaX -= 1;
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo();
                panelMapa.Refresh();
            }
        }

        private void Laberinto_KeyDown(object sender, KeyEventArgs e)
        {
            reproductorSonido();
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
                Arbol arbol = new Arbol(nodos);
                arbol.ShowDialog();
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
        }   //Eevento para cuando se presionan las teclas

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmConfiguracion.Show();
            //this.Close();
        }   //BETA

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmConfiguracion.Show();
            this.Hide();
        }

        private void desenmascarar()
        {
            string nombre = cmbPersonaje.Text;

            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == nombre);

            if (nombre == personaje.Nombre)
            {
                foreach (Coordenada coordenada in lista_pasos)
                {

                    int cordX = coordenada.CoordenadaX;
                    int cordY = coordenada.CoordenadaY;

                    Terreno terrenoC = obtenerTerreno(int.Parse(datos[cordY][cordX]));
                    graficosImg.DrawImage(terrenoC.Imagen, cordX * CELL_WIDTH, cordY * CELL_WIDTH, CELL_WIDTH, CELL_WIDTH);


                    if (cordX + 1 < datos[0].Length)
                    {
                        Terreno terrenoD = obtenerTerreno(int.Parse(datos[cordY][cordX + 1]));
                        graficosImg.DrawImage(terrenoD.Imagen, (cordX + 1) * CELL_WIDTH, cordY * CELL_WIDTH, CELL_WIDTH, CELL_WIDTH);
                    }
                    if (cordX - 1 >= 0) //izquierda
                    {
                        Terreno terrenoI = obtenerTerreno(int.Parse(datos[cordY][cordX - 1]));
                        graficosImg.DrawImage(terrenoI.Imagen, (cordX - 1) * CELL_WIDTH, cordY * CELL_WIDTH, CELL_WIDTH, CELL_WIDTH);
                    }
                    if (cordY + 1 < datos.Length)
                    {
                        Terreno terrenoAb = obtenerTerreno(int.Parse(datos[cordY + 1][cordX]));
                        graficosImg.DrawImage(terrenoAb.Imagen, cordX * CELL_WIDTH, (cordY + 1) * CELL_WIDTH, CELL_WIDTH, CELL_WIDTH);

                    }
                    if (cordY - 1 >= 0) //arriba
                    {
                        Terreno terrenoAr = obtenerTerreno(int.Parse(datos[cordY - 1][cordX]));
                        graficosImg.DrawImage(terrenoAr.Imagen, cordX * CELL_WIDTH, (cordY - 1) * CELL_WIDTH, CELL_WIDTH, CELL_WIDTH);
                    }

                }
            
            }
        }

        private void agregarHijos(string padre)
        {
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == cmbPersonaje.Text);
            Nodo nodoActual = nodos.Last();
            int cX = nodoActual.cX;
            int cY = nodoActual.cY;

            if (cX + 1 < datos[0].Length)//derecha
            {
                if (personaje.Costos[obtenerCosto(int.Parse(datos[cY][cX + 1]))] != -1)
                {
                    if (generarNombre((cX + 1), cY) != padre)
                    {
                        nodos.Last().hijos.Add(generarNombre((cX + 1), cY));
                        nodos.Last().hijosVisitados.Add(false);
                    }
                }   
            }

            if (cY + 1 < datos.Length)//abajo
            {
                if (personaje.Costos[obtenerCosto(int.Parse(datos[cY + 1][cX]))] != -1) 
                {
                    if (generarNombre(cX, (cY + 1)) != padre)
                    {
                        nodos.Last().hijos.Add(generarNombre(cX, (cY + 1)));
                        nodos.Last().hijosVisitados.Add(false);
                    }
                }                
            }

            if (cX - 1 >= 0) //izquierda
            {
                if (personaje.Costos[obtenerCosto(int.Parse(datos[cY][cX - 1]))] != -1) 
                {
                    if (generarNombre((cX-1), cY) != padre)
                    {
                        nodos.Last().hijos.Add(generarNombre((cX - 1), cY));
                        nodos.Last().hijosVisitados.Add(false);
                    }
                }  
            }

            if (cY - 1 >= 0) //arriba
            {        
                if (personaje.Costos[obtenerCosto(int.Parse(datos[cY - 1][cX]))] != -1)
                {
                    if (generarNombre(cX, (cY - 1)) != padre)
                    {
                        nodos.Last().hijos.Add(generarNombre(cX, (cY - 1)));
                        nodos.Last().hijosVisitados.Add(false);
                    }
                }
            }   
        }

        private string generarNombre(int cX, int cY)
        {
            string coord = "";
            char col = 'A';

            col += (char)cX;
            coord = col + (cY + 1).ToString();
            return coord;
        }

        private void agregarVisitas()
        {
            string nombre = nodos.Last().nombre;

            foreach (Nodo nodo in nodos)
            {
                if (nodo.nombre == nombre)
                {
                    nodo.visitas.Add(numero_pasos);
                    return;
                }
            }
        }

        private void agregarNodo()
        {
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == cmbPersonaje.Text);
            int cordx = personaje.CoordenadaX;
            int cordy = personaje.CoordenadaY;

            if (nodos.Count == 1)
            {
                agregarHijos("");
            }
            else
            {
                agregarHijos(nodos[nodos.Count - 2].nombre);
            }

            if (seLlegoAlFinal())
            {
                nodos.Add(new Nodo(nodos.Last().nombre, personaje.CoordenadaX, personaje.CoordenadaY, personaje.Costos[obtenerCosto(int.Parse(datos[cordy][cordx]))], false, true));
                agregarVisitas();
            }
            else
            {
                nodos.Add(new Nodo(nodos.Last().nombre, personaje.CoordenadaX, personaje.CoordenadaY, personaje.Costos[obtenerCosto(int.Parse(datos[cordy][cordx]))], false, false));
                agregarVisitas();
            }

        }

        /*private void reproductor(string accion)
        {
            switch (accion)
            {
                case "playMusic":
                    sound.Play();
                    break;

                case "stopMusic":
                    sound.Stop();
                    break;
            }
        }*/

        private void reproductorSonido()
        {
            soundMove.Play();
        }

    }
}
