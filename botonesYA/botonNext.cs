using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Svg;
using System.Windows.Forms;

namespace botonesYA
{
    public class BotonNext : Button
    {
        private SvgDocument svgImage;

        public BotonNext()
        {
            this.Size = new Size(75, 75);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.Text = string.Empty;

            
            //Intentar cargar la imagen SVG desde los archivos del programa
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("botonesYA.nextbutton.svg"))
            {
                if (stream != null)
                {
                    svgImage = SvgDocument.Open<SvgDocument>(stream);

                }
                else
                {
                    Console.WriteLine("⚠️ Error: No se encontró el recurso nextbutton.svg");
                }
            }

            this.Invalidate(); // Forzar repintado para que salga por huevos
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Si el SVG se encontró, dibújalo
            if (svgImage != null)
            {
                Bitmap bmp = svgImage.Draw(ClientSize.Width, ClientSize.Height);
                pevent.Graphics.DrawImage(bmp, new Rectangle(0, 0, ClientSize.Width, ClientSize.Height));
            }
        }
    }
}
