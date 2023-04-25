using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla.Menu
{
    public class DropdownMenu : ContextMenuStrip
    {
        // Variables
        private bool isMainMenu; // ¿Es un menú principal?
        private int menuItemHeight = 25; // Altura del elemento de menú
        private Color menuItemTextColor = Color.Empty; // Color de texto del elemento de menú (No color, El color por defecto se establece en la clase MenuRenderer)
        private Color primaryColor = Color.Empty; // Color primario del menú (No color, El color por defecto se establece en la clase MenuRenderer)

        private Bitmap menuItemHeaderSize; // Mapa de bits para establecer el ancho y el alto de la cabecera de los elementos del menú

        // Constructor
        public DropdownMenu(IContainer container)
            : base(container)
        {

        }

        // Propiedades
        [Browsable(false)]
        public bool IsMainMenu
        {
            get { return isMainMenu; }
            set { isMainMenu = value; }
        }

        [Browsable(false)]
        public int MenuItemHeight
        {
            get { return menuItemHeight; }
            set { menuItemHeight = value; }
        }

        [Browsable(false)]
        public Color MenuItemTextColor
        {
            get { return menuItemTextColor; }
            set { menuItemTextColor = value; }
        }

        [Browsable(false)]
        public Color PrimaryColor
        {
            get { return primaryColor; }
            set { primaryColor = value; }
        }

        // Métodos privados
        private void LoadMenuItemHeight()
        {
            if (isMainMenu)
            {
                menuItemHeaderSize = new Bitmap(25, 45);
            }
            else
            {
                menuItemHeaderSize = new Bitmap(20, menuItemHeight);
            }

            foreach (ToolStripMenuItem menuItemL1 in this.Items) // Nivel 1 de subelementos del menú desplegable
            {
                menuItemL1.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItemL1.Image == null)
                {
                    menuItemL1.Image = menuItemHeaderSize;
                }

                foreach (ToolStripMenuItem menuItemL2 in menuItemL1.DropDownItems) // Nivel 2 de subelementos del menú desplegable
                {
                    menuItemL2.ImageScaling = ToolStripItemImageScaling.None;
                    if (menuItemL2.Image == null)
                    {
                        menuItemL2.Image = menuItemHeaderSize;
                    }

                    foreach (ToolStripMenuItem menuItemL3 in menuItemL2.DropDownItems) // Nivel 3 de subelementos del menú desplegable
                    {
                        menuItemL3.ImageScaling = ToolStripItemImageScaling.None;
                        if (menuItemL3.Image == null)
                        {
                            menuItemL3.Image = menuItemHeaderSize;
                        }

                        foreach (ToolStripMenuItem menuItemL4 in menuItemL3.DropDownItems) // Nivel 4 de subelementos del menú desplegable
                        {
                            menuItemL4.ImageScaling = ToolStripItemImageScaling.None;
                            if (menuItemL4.Image == null)
                            {
                                menuItemL4.Image = menuItemHeaderSize;
                            }

                        }
                    }
                }
            }
        }

        // Redefinición de métodos
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode == false)
            {
                this.Renderer = new MenuRenderer(isMainMenu, primaryColor, menuItemTextColor);
                LoadMenuItemHeight();
            }
        }
    }
}
