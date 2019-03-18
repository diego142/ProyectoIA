using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_IA
{
    public partial class Configuracion : Form
    {
        Inicio inicio;
        List<Terreno> terrenos = new List<Terreno>();
        List<Personaje> personajes = new List<Personaje>();
        string[][] datos;

        public Configuracion(Inicio init)
        {
            InitializeComponent();
            inicio = init;
            panel1.Hide();
            panel2.Hide();
        }

        private void limpiarPaneles()
        {
            terrenos.Clear();
            personajes.Clear();

            dgvPersonaje.Rows.Clear();
            cmbCodigo.Items.Clear();
            pbPersonaje.Image = null;
            lblListo.Hide();
            lblListo2.Hide();
            panel2.Hide();
            btnAgregarPersonaje.Enabled = true;
            btnSelPersonaje.Enabled = true;
            btnSiguiente.Enabled = false;
            txtNombre.Enabled = true;
        }

        private bool terrenosListos()
        {
            foreach (Terreno terreno in terrenos)
            {
                if (terreno.Codigo == -1 || terreno.Nombre == "")
                {
                    return false;
                }

                if (terreno.Color == Color.Transparent && terreno.Imagen == null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool personajesListos()
        {
            if (pbPersonaje.Image == null )
            {
                MessageBox.Show("Escoje una imagen para el personaje.");
                return false;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Escoje un nombre para el personaje.");
                return false;
            }

            int tam = terrenos.Count;

            for (int i = 0; i < tam; i++)
            {
                if (dgvPersonaje.Rows[i].Cells[3].Value == null)
                {
                    MessageBox.Show("Hace falta el costo para el terreno: " + terrenos[i].Nombre);
                    return false;
                }
            }
            return true;
        }

        private bool validarDatos(int fil, int col)
        {
            int cod = 0;

            for (int i = 0; i < fil; i++)
            {
                if (col != datos[i].Length)
                {
                    MessageBox.Show("Error: No todas las filas tienen el mismo numero de columnas");
                    return false;
                }
            }

            for (int i = 0; i < fil; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    try
                    {
                        cod = int.Parse(datos[i][j]);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: El codigo del terreno tiene un formato invalido. \n" +
                                        "Verifique fila: " + (i + 1) + ", columna: " + (j + 1));
                        return false;
                    }

                }
            }
            return true;
        }

        private bool existeTerrenoEnLista(int codigo)
        {
            foreach (Terreno terreno in terrenos)
            {
                if (terreno.Codigo == codigo)
                {
                    return true;
                }
            }
            return false;
        }

        private void agregarTerrenos(string texto)
        {

            int fil = 0;
            int col = 0;
            int cod = 0;

            string[] filas = texto.Split('\n');

            if (filas[filas.Length-1].ToString() == "") //No hay nada en la ultima fila
            {
                Array.Resize(ref filas, filas.Length - 1); //Se elimina
            }
    
            fil = filas.Length;

            datos = new string[fil][];

            for (int i = 0; i < fil; i++)
            {
                datos[i] = filas[i].Split(',');    
            }
            col = datos[0].Length;


            if (validarDatos(fil, col))
            {
                for (int i = 0; i < fil; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        cod = int.Parse(datos[i][j]);

                        if (!existeTerrenoEnLista(cod)) //Si no existe en la lista se agrega
                        {
                            Terreno terreno = new Terreno();
                            terreno.Codigo = cod;
                            terrenos.Add(terreno);
                        }
                    }
                }

                foreach (Terreno terreno in terrenos) { //Se agregan terrenos al combobox
                    cmbCodigo.Items.Add(terreno.Codigo);
                }
                cmbCodigo.SelectedIndex = 0;            //Poner indice del combobox en el primer item
                cmbNombre.SelectedIndex = 0;
                panel1.Show();                          //Se muestran los paneles
            }
        }

        private void agregarADataGrid()
        {
            dgvPersonaje.Rows.Clear();
            int cont = 0;

            foreach (Terreno terreno in terrenos)
            {
                dgvPersonaje.Rows.Add(terreno.Imagen, null, terreno.Nombre);
                dgvPersonaje.Rows[cont].Cells[1].Style.BackColor = terreno.Color;

                cont++;
            }

            List<string> lista = new List<string>();
            lista.Add("N/A");
            for (decimal i = 0; i < 100;)
            {
                lista.Add(i.ToString());
                i = i + 0.01m;
            }

            DataGridViewComboBoxColumn cmb = dgvPersonaje.Columns[3] as DataGridViewComboBoxColumn;
            cmb.DataSource = lista;
        }

        private void leerTxt(string ruta)
        {
            StreamReader fichero;
            fichero = File.OpenText(ruta);

            try
            {
                string texto = fichero.ReadToEnd();

                fichero.Close();
                agregarTerrenos(texto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            string ruta = "";
            string path = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files (*.txt)|*.txt*|All Files (*.*)|*.*"; //Para filtrar los archivos
            openFile.AutoUpgradeEnabled = false; //Para que funque la ruta predeterminada

            path = Path.Combine(Application.StartupPath, @"..\..\Recursos");

            openFile.InitialDirectory = path;

            if (openFile.ShowDialog() == DialogResult.OK)
            {

                limpiarPaneles();

                ruta = openFile.FileName;
                leerTxt(ruta);
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog.Color;
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {

            if (cmbNombre.SelectedItem == null)
            {
                MessageBox.Show("Agregar un nombre de terreno.");

            } else if (btnColor.BackColor == Color.Transparent && picBox.Image == null)
            {
                MessageBox.Show("Escoge un color o una imagen.");
            }
            else
            {
 
                terrenos[cmbCodigo.SelectedIndex].Nombre = cmbNombre.SelectedItem.ToString();
                terrenos[cmbCodigo.SelectedIndex].Color = btnColor.BackColor;
                terrenos[cmbCodigo.SelectedIndex].Imagen = picBox.Image;

                if (cmbNombre.SelectedIndex + 1 < cmbNombre.Items.Count)
                {
                    cmbNombre.SelectedIndex += 1;
                }
                else
                {
                    cmbNombre.SelectedIndex = 0;
                }

                if (cmbCodigo.SelectedIndex + 1 < cmbCodigo.Items.Count)
                {
                    cmbCodigo.SelectedIndex += 1;
                }
                else
                {
                    cmbCodigo.SelectedIndex = 0;
                }

                cmbCodigo_SelectedIndexChanged(sender, e);
            }

        }

        private void cmbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (terrenos[cmbCodigo.SelectedIndex].Nombre != null)
            {
                cmbNombre.SelectedItem = terrenos[cmbCodigo.SelectedIndex].Nombre;
            }

            btnColor.BackColor = terrenos[cmbCodigo.SelectedIndex].Color;
            picBox.Image = terrenos[cmbCodigo.SelectedIndex].Imagen;

            if ( terrenosListos() )
            {
                lblListo.Show();
                panel2.Show();
                agregarADataGrid();
            }
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            string ruta = "";
            string path = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images Files (*.png;*.jpg;)|*.png;*.jpg*|All Files (*.*)|*.*";
            openFile.AutoUpgradeEnabled = false;
            path = Path.Combine(Application.StartupPath, @"..\..\Terrenos");

            openFile.InitialDirectory = path;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ruta = openFile.FileName;
                picBox.Image = Image.FromFile(ruta);
            }
        }

        private void btnSelPersonaje_Click(object sender, EventArgs e)
        {
            string path = "";
            string ruta = "";
            string nombre = "";

            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Images Files (*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif*|All Files (*.*)|*.*";
            openFile.AutoUpgradeEnabled = false;
            path = Path.Combine(Application.StartupPath, @"..\..\Personajes");
    
            openFile.InitialDirectory = path;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ruta = openFile.FileName;
                nombre = Path.GetFileNameWithoutExtension(openFile.SafeFileName);

                pbPersonaje.Image = Image.FromFile(ruta);
                txtNombre.Text = nombre;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Laberinto lab = new Laberinto(terrenos, personajes, datos, this);
            lab.Show();
            this.Hide();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            inicio.Show();
            this.Close();
        }

        private void btnAgregarPersonaje_Click(object sender, EventArgs e)
        {

            if (personajesListos())
            {
                Personaje personaje = new Personaje();
                int cont = terrenos.Count;

                personaje.Nombre = txtNombre.Text;
                personaje.Imagen = pbPersonaje.Image;


                for (int i= 0; i < cont; i++)
                {
                    personaje.Terrenos[i] = terrenos[i].Codigo;
                    if (dgvPersonaje.Rows[i].Cells[3].Value.ToString() == "N/A")
                    {
                        personaje.Costos[i] = -1;
                    }
                    else
                    {
                       personaje.Costos[i] = decimal.Parse(dgvPersonaje.Rows[i].Cells[3].Value.ToString());
                    }
                    dgvPersonaje.Rows[i].Cells[3].Value = null;

                }

                personajes.Add(personaje);

                pbPersonaje.Image = null;
                txtNombre.Text = "";

                int num = personajes.Count;
                if (num == 4)
                {
                    lblListo2.Show();
                    txtNombre.Enabled = false;
                    btnAgregarPersonaje.Enabled = false;
                    btnSelPersonaje.Enabled = false;
                }
                btnSiguiente.Enabled = true;
            }

        }
    }
}
