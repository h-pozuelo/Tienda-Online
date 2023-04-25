using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla.Menu
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        // Variables
        private Color primaryColor; // Color primario del menú
        private Color textColor; // Color del texto
        private int arrowThickness; // Grosor del icono flecha de un elemento desplegable

        // Constructor
        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            this.primaryColor = primaryColor;
            if (isMainMenu)
            {
                arrowThickness = 3;
                if (textColor == Color.Empty) // Establecer color por defecto
                {
                    this.textColor = Color.Gainsboro;
                }
                else // Establecer color personalizado
                {
                    this.textColor = textColor;
                }
            }
            else
            {
                arrowThickness = 2;
                if (textColor == Color.Empty) // Establecer color por defecto
                {
                    this.textColor = Color.DimGray;
                }
                else // Establecer color personalizado
                {
                    this.textColor = textColor;
                }
            }
        }

        // Redefinición de métodos
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : textColor;
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // Variables
            var graph = e.Graphics; // Objeto de gráficos
            var arrowSize = new Size(5, 12); // Tamaño del icono flecha
            var arrowColor = e.Item.Selected ? Color.White : primaryColor; // Color del icono flecha
            var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2,
                arrowSize.Width, arrowSize.Height); // Rectángulo para la ubicación y el tamaño del icono flecha
            using (GraphicsPath path = new GraphicsPath()) // Objeto para la ruta de gráficos de la flecha
            using (Pen pen = new Pen(arrowColor, arrowThickness)) // Objeto bolígrafo para dibujar la flecha
            {
                // Dibujado
                graph.SmoothingMode = SmoothingMode.AntiAlias; // Establecemos el modo de suavizado del objeto de gráficos en AntiAlias
                path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2); // Agregamos una línea empezando en la parte superior izquierda del rectángulo hasta el borde derecho central del rectángulo
                path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height); // Agregamos otra línea empezando del punto final de la línea anterior hasta la parte inferior izquierda
                graph.DrawPath(pen, path); // Dibujamos el icono de flecha con los parámetros establecidos en el objeto bolígrafo y ruta de gráficos
            }
        }

    }
}
