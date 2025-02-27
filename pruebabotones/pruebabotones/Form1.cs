using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using botonesYA;
using System.Drawing.Text;
using System.Reflection;
using System.IO;

namespace pruebabotones
{
    public partial class Form1 : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();

        private void CargarFuentePersonalizada() //metodo para cargar una fuente externa como un recurso incrustado
        {
            // Obtener el ensamblado actual
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "pruebabotones.Resources.FranieVariableTest-ExtraLight-BF64c31f3ceda28.otf";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    byte[] fontData = new byte[stream.Length];
                    stream.Read(fontData, 0, (int)stream.Length);

                    // Crear un espacio en memoria para la fuente
                    IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                    System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                    // Agregar la fuente a la colección
                    pfc.AddMemoryFont(fontPtr, fontData.Length);

                    // Liberar memoria
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
                }
                else
                {
                    MessageBox.Show("⚠ No se encontró el recurso de la fuente.");
                }
            }
        }


        public Form1()
        {
            InitializeComponent();

            //buenas profe, he basado mi diseño en el de spotify con una de mis canciones favoritas, no creo que sea tu estilo, pero sobre todo es el mensaje de la cancion
            //Iba a tener mas botones y tal que al final he quitado porque no me daba tiempo con las demás practicas y tal que me han quitado tiempo, pero espero que te guste igualmente

            CargarFuentePersonalizada();

            FlowLayoutPanel opciones = new FlowLayoutPanel //contorno para las opciones de arriba
            {
                Location = new Point(0,0),
                Size = new Size(this.ClientSize.Width, 75),
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
            };

            FlowLayoutPanel botones = new FlowLayoutPanel //contorno para los botones
            {
                Location = new Point(0, (this.ClientSize.Height / 2) + 200),
                Size = new Size(this.ClientSize.Width, 110), 
                FlowDirection = FlowDirection.LeftToRight, 
                AutoSize = false,
                Padding = new Padding(65, 0, 0, 0),
                WrapContents = false, 
                BackColor = Color.Transparent, 
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                
            };

            FlowLayoutPanel song = new FlowLayoutPanel //contorno para la informacion de la cancion
            {
                Location = new Point((this.ClientSize.Width / 2) - 220, (this.ClientSize.Height/2)-350),
                Size = new Size(440, 550),
                FlowDirection = FlowDirection.TopDown,
                AutoSize = false,
                WrapContents = false,
                BackColor = Color.Transparent,
                //Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            //objetos opciones
            BotonDown down = new BotonDown
            {
                Size = new Size(50,27),
                Anchor = AnchorStyles.None,
                Margin = new Padding(30,20,0,0)
            };

            BotonOptions opt = new BotonOptions
            {
                Size = new Size(8, 30),
                Anchor = AnchorStyles.None,
                Margin = new Padding(350,20,0,0)
            };

            //objetos song
            PictureBox cover = new PictureBox
            {
                Size = new Size(song.Width, song.Width),
                Image = Properties.Resources.optimist,
                SizeMode = PictureBoxSizeMode.StretchImage,
                
            };
            Label title = new Label 
            {
                Text = "Only A Lifetime",
                Font = new Font("Franie Test",15, FontStyle.Bold),
                Size = new Size(300,30),
                ForeColor = Color.White,
                Margin = new Padding(0)

            };

            Label autor = new Label 
            {
                Text = "FINNEAS",
                Font = new Font(pfc.Families[0],10, FontStyle.Regular),
                Size = new Size(200, 20),
                ForeColor= Color.FromArgb(80,255,255,255),
                Margin = new Padding(0, 0, 0, 0)

            };
            PictureBox line = new PictureBox
            {
                Size = new Size(song.Width, song.Width),
                Image = Properties.Resources.text2,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Margin = new Padding(0, 30, 0, 0),
                Anchor = AnchorStyles.Top,
            };

            //objetos botones
            BotonBack botonBack = new BotonBack
            {
                Size = new Size(45, 45),
                Margin = new Padding(30),
                Anchor = AnchorStyles.None
               
            };

            BotonPlay botonPlay = new BotonPlay
            {
                Size = new Size(80, 80),
                Margin = new Padding(30),
                Anchor = AnchorStyles.None
            };

            BotonNext botonNext = new BotonNext
            {
                Size = new Size(45, 45),
                Margin = new Padding(30),
                Anchor = AnchorStyles.None
            };
            //add botones
            botones.Controls.Add(botonBack);
            botones.Controls.Add(botonPlay); 
            botones.Controls.Add(botonNext);
          
            //add song
            song.Controls.Add(cover);
            song.Controls.Add(title);
            song.Controls.Add(autor);
            song.Controls.Add(line);

            //add opciones
            opciones.Controls.Add(down);
            opciones.Controls.Add(opt);

            //add contornos
            this.Controls.Add(opciones);
            this.Controls.Add(botones);
            this.Controls.Add(song);
        }

        protected override void OnPaintBackground(PaintEventArgs e) //color gradiant del fondo
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                ColorTranslator.FromHtml("#824149"),
                ColorTranslator.FromHtml("#170a0c"),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

    }
}
