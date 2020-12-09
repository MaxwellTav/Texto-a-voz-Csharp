using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texto_a_voz_Csharp
{
    public partial class FormIndex : Form
    {
        //variables
        bool seLeHizoClick = false;

        public FormIndex()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido al sistema de texto a voz!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //inicializando las cosas
            applicationName.Text = Text;
            seLeHizoClick = false;

            //imagenes
            /*
            try
            {
                exitButton.BackgroundImage = Image.FromFile(@"..\Propierties/Resources/exitIco.png");
                minimizeButton.BackgroundImage = Image.FromFile(@"..\Resources/minimizeIco.png");
                if (WindowState == FormWindowState.Maximized)
                {
                    maximizeButton.BackgroundImage = Image.FromFile(@"..\Resources/maximizeIco.png");
                }
                else
                {
                    maximizeButton.BackgroundImage = Image.FromFile(@"..\Resources/normalIco.png");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Error 0x7092001 al cargar las texturas", "Error no tan grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //preguntar si desea salir de la aplicacion
            DialogResult = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Esta saliendo de la aplicación!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        //Movimiento del form por el panel
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            seLeHizoClick = true;
        }
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            seLeHizoClick = false;
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (seLeHizoClick)
            {
                WindowState = FormWindowState.Normal;
                Location = Cursor.Position;
            }
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //fin del movimiento del mouse


    }
}
