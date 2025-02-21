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

namespace pruebabotones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FlowLayoutPanel opciones = new FlowLayoutPanel
            {
                Location = new Point(0, this.ClientSize.Height),
                Size = new Size(this.ClientSize.Width, 150),
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = false,
                WrapContents = false,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            BotonDown botonDown = new BotonDown
            {
                Size = new Size(20, 20),
                Margin = new Padding(10),
                Anchor = AnchorStyles.None
            };

            FlowLayoutPanel botones = new FlowLayoutPanel
            {
                Location = new Point(0, (this.ClientSize.Height / 2) + 200),
                Size = new Size(this.ClientSize.Width, 200), 
                FlowDirection = FlowDirection.LeftToRight, 
                AutoSize = false,
                Padding = new Padding(65, 0, 0, 0),
                WrapContents = false, 
                BackColor = Color.Transparent, 
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                
            };

            
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

            botones.Controls.Add(botonBack);
            botones.Controls.Add(botonPlay); 
            botones.Controls.Add(botonNext);
            opciones.Controls.Add(botonDown);
            
            this.Controls.Add(botones);
            this.Controls.Add(opciones);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
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
