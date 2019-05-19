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
        bool finalAlg;
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
        string rutaMovimiento = "";
        string rutaMusicaLink = "";
        string rutaFinal = "";
        string rutaMusicaKirby = "";
        string rutaMarco = "";
        string rutaMario = "";
        string rutaPikachu = "";
        string rutaYoshi = "";
        List<string> ordenDeExp = new List<string>();
        List<Nodo> nodosCerrados = new List<Nodo>();
        List<Nodo> listaAbierta = new List<Nodo>();


        Point coordenadaActual;
        Point coordenada_InicialXY;
        Point coordenada_FinalXY;
        SoundPlayer sounds;

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
            rutaMusicaLink = Path.Combine(Application.StartupPath, @"..\..\Sonidos\song_link.wav");
            rutaMovimiento = Path.Combine(Application.StartupPath, @"..\..\Sonidos\movimiento.wav");
            rutaMusicaKirby = Path.Combine(Application.StartupPath, @"..\..\Sonidos\song_kirby.wav");
            rutaMarco = Path.Combine(Application.StartupPath, @"..\..\Sonidos\marco.wav");
            rutaMario = Path.Combine(Application.StartupPath, @"..\..\Sonidos\mario.wav");
            rutaPikachu = Path.Combine(Application.StartupPath, @"..\..\Sonidos\pikachu.wav");
            rutaYoshi = Path.Combine(Application.StartupPath, @"..\..\Sonidos\yoshi.wav");
            rutaFinal = Path.Combine(Application.StartupPath, @"..\..\Sonidos\final.wav");

            banderaIni = Image.FromFile(rutaI);
            banderaFin = Image.FromFile(rutaF);
            niebla = Image.FromFile(rutaNiebla);
            lista_pasos = new List<Coordenada>();
            nodos = new List<Nodo>();
            numero_pasos = 1;
            jugando = false;
            finalAlg = false;

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

                            btnArriba.Enabled = true;
                            btnAbajo.Enabled = true;
                            cbAS.Checked = false;
                            cbBT.Checked = false;

                            cmbPersonaje.Enabled = true;
                            lista_pasos.Clear();
                            nodos.Clear();
                            numero_pasos = 1;
                            jugando = false;
                            ordenDeExp.Clear();
                            nodosCerrados.Clear();
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
                            panelMapa.Refresh();
                            btnCelda_Final.Enabled = false;
                            btnRegresar.Enabled = false;
                            cbBT.Enabled = true;
                            cbAS.Enabled = true;

                        }
                    }
                }

            }
            //panelMapa.Focus();
        }   ////Btn para escoger la coordenada final

        private void Laberinto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }   //Salir de la aplicacion

        private void btnElegir_Click(object sender, EventArgs e)
        {
            reproductor(pbPersonaje.Image.Tag.ToString());
            cmbPersonaje.Enabled = false;
            btnElegir.Enabled = false;
            btnCelda_Inicial.Enabled = true;

        }   //Desbloqueo los otros botones después de elegir un personaje

        private bool moverPersonajeArriba()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("arriba", personaje))
            {
                string padre = generarNombre(personaje.CoordenadaX, personaje.CoordenadaY);

                personaje.CoordenadaY -= 1; 
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo(padre);
                panelMapa.Refresh();
                return true;
            }
            return false;
        }

        private bool moverPersonajeDerecha()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("derecha", personaje))
            {
                string padre = generarNombre(personaje.CoordenadaX, personaje.CoordenadaY);
                personaje.CoordenadaX += 1;
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo(padre);
                panelMapa.Refresh();
                return true;

            }
            return false;
        }

        private bool moverPersonajeAbajo()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("abajo", personaje))
            {
                string padre = generarNombre(personaje.CoordenadaX, personaje.CoordenadaY);

                personaje.CoordenadaY += 1;
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo(padre);
                panelMapa.Refresh();
                return true;
            }
            return false;
        }

        private bool moverPersonajeIzquierda()
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            if (validaMovimiento("izquierda", personaje))
            {
                string padre = generarNombre(personaje.CoordenadaX, personaje.CoordenadaY);

                personaje.CoordenadaX -= 1;
                numero_pasos++;
                agrearPasos(personaje);
                agregarNodo(padre);
                panelMapa.Refresh();
                return true;
            }
            return false;
        }

        private void Laberinto_KeyDown(object sender, KeyEventArgs e)
        {
            string nombre = "";

            nombre = pbPersonaje.Image.Tag.ToString();
            
            if(nombre != "kirby" && nombre != "link")
            {
                reproductor("playMovimiento");
            }

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
                reproductor("final");
                MessageBox.Show("Llegaste a la meta");
                Arbol arbol = new Arbol(nodos, nodosCerrados);
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

            for (int i = 0; i < ordenDeExp.Count; i++)
            {
                string opc = ordenDeExp[i];
                switch (opc)
                {
                    case "Arriba":
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
                        break;
                    case "Derecha":
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
                        break;
                    case "Abajo":
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
                        break;
                    case "Izquierda":

                        if (cX - 1 >= 0) //izquierda
                        {
                            if (personaje.Costos[obtenerCosto(int.Parse(datos[cY][cX - 1]))] != -1)
                            {
                                if (generarNombre((cX - 1), cY) != padre)
                                {
                                    nodos.Last().hijos.Add(generarNombre((cX - 1), cY));
                                    nodos.Last().hijosVisitados.Add(false);
                                }
                            }
                        }
                        break;
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

        private void agregarNodo(string padreNombre)
        {
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == cmbPersonaje.Text);
            int cordx = personaje.CoordenadaX;
            int cordy = personaje.CoordenadaY;

            if (seLlegoAlFinal())
            {
                nodos.Add(new Nodo(padreNombre, personaje.CoordenadaX, personaje.CoordenadaY, personaje.Costos[obtenerCosto(int.Parse(datos[cordy][cordx]))], false, true));
                agregarVisitas();
            }
            else
            {
                nodos.Add(new Nodo(padreNombre, personaje.CoordenadaX, personaje.CoordenadaY, personaje.Costos[obtenerCosto(int.Parse(datos[cordy][cordx]))], false, false));
                agregarHijos(padreNombre);
                agregarVisitas();
            }
        }

        private void reproductor(string accion)
        {
            switch (accion)
            {
                case "link":
                    sounds = new SoundPlayer(rutaMusicaLink);
                    sounds.Play();
                    break;

                case "stopMusic":
                    sounds.Stop();
                    break;

                case "kirby":
                    sounds = new SoundPlayer(rutaMusicaKirby);
                    sounds.Play();
                    break;

                case "marco":
                    sounds = new SoundPlayer(rutaMarco);
                    sounds.Play();
                    break;

                case "mario":
                    sounds = new SoundPlayer(rutaMario);
                    sounds.Play();
                    break;

                case "pikachu":
                    sounds = new SoundPlayer(rutaPikachu);
                    sounds.Play();
                    break;

                case "yoshi":
                    sounds = new SoundPlayer(rutaYoshi);
                    sounds.Play();
                    break;

                case "playMovimiento":
                    sounds = new SoundPlayer(rutaMovimiento);
                    sounds.Play();
                    break;

                case "final":
                    sounds = new SoundPlayer(rutaFinal);
                    sounds.Play();
                    break;
            }
        }

        private void btnArriba_Click(object sender, EventArgs e)
        {
            if (listBoxOrdenExpansion.SelectedItem == null || listBoxOrdenExpansion.SelectedIndex < 0)
                return; 

            int newIndex = listBoxOrdenExpansion.SelectedIndex - 1;

            if (newIndex < 0 || newIndex >= listBoxOrdenExpansion.Items.Count)
                return; 

            object selected = listBoxOrdenExpansion.SelectedItem;

            listBoxOrdenExpansion.Items.Remove(selected);
            listBoxOrdenExpansion.Items.Insert(newIndex, selected);
            listBoxOrdenExpansion.SetSelected(newIndex, true);
        }

        private void btnAbajo_Click(object sender, EventArgs e)
        {
            
            if (listBoxOrdenExpansion.SelectedItem == null || listBoxOrdenExpansion.SelectedIndex < 0)
                return; 

            int newIndex = listBoxOrdenExpansion.SelectedIndex + 1;

            if (newIndex < 0 || newIndex >= listBoxOrdenExpansion.Items.Count)
                return; 

            object selected = listBoxOrdenExpansion.SelectedItem;

            listBoxOrdenExpansion.Items.Remove(selected);
            listBoxOrdenExpansion.Items.Insert(newIndex, selected);
            listBoxOrdenExpansion.SetSelected(newIndex, true);
        }

        private void backTracking()
        {
            Thread.Sleep(500);
            finalAlg = false;

            backTracking(nodos[0]);
        }

        private void backTracking(Nodo nodoActual)
        {
            Nodo aux = nodoActual;

            if (seLlegoAlFinal())
            {
                finalAlg = true;
                reproductor("final");
                MessageBox.Show("Llegaste a la meta");
                Arbol arbol = new Arbol(nodos, nodosCerrados);
                arbol.ShowDialog();
                DialogResult opc = MessageBox.Show("¿Quieres volver a jugar?", "Juego terminado.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                arbol.Close();
                if (opc == DialogResult.Yes)
                {
                    reiniciar(0);
                }
                else
                {
                    reiniciar(1);
                }
                return;
            }
            else
            {
                for (int i = 0; i < ordenDeExp.Count; i++)
                {
                    if (finalAlg) { return; }

                    string personajeNombre = cmbPersonaje.Text;
                    Personaje p = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

                    string opc = ordenDeExp[i];

                    switch (opc)
                    {
                        case "Arriba":
                            if (esHijoValido(nodoActual, generarNombre(nodoActual.cX, nodoActual.cY - 1)) == true)
                            {
                                if (estaCerrado(generarNombre(nodoActual.cX, nodoActual.cY - 1)) == false)
                                {
                                        if (moverPersonajeArriba())
                                    {
                                        Thread.Sleep(500);

                                        nodoActual = nodos.Last();
                                        backTracking(nodoActual);
                                        if (finalAlg) { return; }

                                        regresar(nodoActual.cX, (nodoActual.cY + 1));
                                        nodoActual = aux;
                                        Thread.Sleep(500);
                                    }

                                }
                            }

                            break;
                        case "Derecha":
                            if (esHijoValido(nodoActual, generarNombre(nodoActual.cX + 1, nodoActual.cY)) == true)
                            {
                                if (estaCerrado(generarNombre(nodoActual.cX + 1, nodoActual.cY)) == false)
                                {
                                    if (moverPersonajeDerecha())
                                    {
                                        Thread.Sleep(500);

                                        nodoActual = nodos.Last();
                                        backTracking(nodoActual);
                                        if (finalAlg) { return; }

                                        regresar((nodoActual.cX - 1), nodoActual.cY);
                                        nodoActual = aux;

                                        Thread.Sleep(500);
                                    }

                                }
                            }

                            break;
                        case "Abajo":
                            if (esHijoValido(nodoActual, generarNombre(nodoActual.cX, nodoActual.cY + 1)) == true)
                            {
                                if (estaCerrado(generarNombre(nodoActual.cX, nodoActual.cY + 1)) == false)

                                {
                                    if (moverPersonajeAbajo())
                                    {
                                        Thread.Sleep(500);

                                        nodoActual = nodos.Last();

                                        backTracking(nodoActual);
                                        if (finalAlg) { return; }

                                        regresar(nodoActual.cX, (nodoActual.cY - 1));
                                        nodoActual = aux;
                                        Thread.Sleep(500);
                                    }

                                }
                            }
                            break;
                        case "Izquierda":
                            if (esHijoValido(nodoActual, generarNombre(nodoActual.cX - 1, nodoActual.cY)) == true)
                            {
                                if (estaCerrado(generarNombre(nodoActual.cX - 1, nodoActual.cY)) == false)
                                {
                                    if (moverPersonajeIzquierda())
                                    {

                                        Thread.Sleep(500);

                                        nodoActual = nodos.Last();
                                        backTracking(nodoActual);
                                        if (finalAlg) { return; }

                                        regresar((nodoActual.cX + 1), nodoActual.cY);
                                        nodoActual = aux;
                                        Thread.Sleep(500);
                                    }

                                }
                            }

                            break;
                    }
                }
                nodosCerrados.Add(nodoActual);
            }

        }

        private bool estaCerrado(string nombre)
        {
            foreach (Nodo nodo in nodosCerrados)
            {
                if (nodo.nombre == nombre)
                {
                    return true;
                }
            }
            return false;
        }

        private bool esHijoValido(Nodo nodoActual, string mov)
        {
            foreach (string hijo in nodoActual.hijos)
            {
                if (hijo == mov)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            for (int l = 0; l < listBoxOrdenExpansion.Items.Count; l++)
            {
                ordenDeExp.Add(listBoxOrdenExpansion.Items[l].ToString());
            }

            string nombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == nombre);

            lista_pasos.Add(new Coordenada(personaje.CoordenadaX, personaje.CoordenadaY, numero_pasos));
            nodos.Add(new Nodo("", personaje.CoordenadaX, personaje.CoordenadaY, 0, true, false));
            agregarHijos("");

            nodos.Last().visitas.Add(numero_pasos);

            btnArriba.Enabled = false;
            btnAbajo.Enabled = false;
            btnJugar.Enabled = false;
            cbBT.Enabled = false;
            cbAS.Enabled = false;
            jugando = true;

            if (cbBT.Checked == true)
            {
                backTracking();
            }
            else
            {
                //A estrella
            }

        }

        private void regresar(int x, int y)
        {
            string personajeNombre = cmbPersonaje.Text;
            Personaje personaje = personajes.Find(personaje_x => personaje_x.Nombre == personajeNombre);

            personaje.CoordenadaX = x;
            personaje.CoordenadaY = y;
            numero_pasos++;
            agrearPasos(personaje);
            panelMapa.Refresh();
        }

        private void cbBT_Click(object sender, EventArgs e)
        {
            btnJugar.Enabled = true;

            if (cbAS.Checked == true)
            {
                cbAS.Checked = false;
            }
            else
            {

                cbBT.Checked = true;
            }
        }

        private void cbAS_Click(object sender, EventArgs e)
        {
            btnJugar.Enabled = true;

            if (cbBT.Checked == true)
            {
                cbBT.Checked = false;
            }
            else
            {
                cbAS.Checked = true;
            }
        }

        private int distanciaManhatan (int x1, int x2, int y1, int y2)
        {
            int distancia = 0;

            distancia = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
            return distancia;
        }

        private string selectBestFn ()
        {
            decimal fn = 0;
            decimal gn = 0;
            decimal hn = 0;


            
        }
        

        private void Astar()
        {
            Nodo nodoActual = nodos.First();

            if (nodoActual.final == true)
            {
                return;
            }
            else
            {

            }
        }

        private int charToInt(string coor)
        {
            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for(int i=0; i<abc.Count(); i++)
            {
                if(abc[i].ToString() == coor)
                {
                    return i;
                }
            }
            return -1;
        }
    }


}
