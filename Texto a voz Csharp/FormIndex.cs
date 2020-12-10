using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.Diagnostics;

namespace Texto_a_voz_Csharp
{
    public partial class FormIndex : Form
    {
        //variables---------------------------------//
                                                    //
            /*Esta variable es la que controla si   //
            se le da click a la ventana para        //
            poder moverla con libertad*/            //
            bool seLeHizoClick = false;             //
                                                    //
        //fin de variables--------------------------//

        public FormIndex()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //inicializando las cosas

            /*esta linea indica que el titulo de el formulario (el texto que esta en el panel de arriba)
            su texto sera el texto del formulario de inicio, el cual se llama "FormIndex"*/        
            applicationName.Text = Text;

            seLeHizoClick = false;

            entradaRitchText.Focus();
        }

        //---------------------------OBJETOS---------------------------
        private void exitButton_Click(object sender, EventArgs e)
        {
            //preguntar si desea salir de la aplicacion
            DialogResult = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Esta saliendo de la aplicación!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
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
        
        private void playButton_Click(object sender, EventArgs e)
        {
            Thread tarea = new Thread(new ParameterizedThreadStart(Hablar));
            tarea.Start(entradaRitchText.Text);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Thread _tarea = new Thread(new ParameterizedThreadStart(Hablar));
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            _tarea.Suspend();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/MaxwellRafael.TavaresRocha.7/");
        }


        //-----------------------COMPORTAMIENTOS-----------------------
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

        public void Hablar(object texto)
        {
            SpeechSynthesizer voz = new SpeechSynthesizer();
            voz.SetOutputToDefaultAudioDevice();
            voz.Speak(texto.ToString());
        }
        
        private void volumenSlider_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip _volumenToolTip = new ToolTip();
            _volumenToolTip.AutoPopDelay = 5000;
            _volumenToolTip.InitialDelay = 1000;
            _volumenToolTip.ReshowDelay = 500;
            _volumenToolTip.ShowAlways = true;
            _volumenToolTip.SetToolTip(pictureBox1, "Click para dirigirte a mi facebook: Maxwell Tavares!");
            _volumenToolTip.SetToolTip(volumenSlider, "Obsoleto por el momento, pero le da un toque bonito al programa");
        }
    }
}
