using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KDTree.Source.Graphics.UserControls;

namespace KDTree
{
    public partial class GraphicsWindow : Form
    {
        #region Private variables
        private List<Shape> _ShapesToDraw;
        #endregion

        #region Constructor
        public GraphicsWindow(List<Shape> shapesToDraw)
        {
            InitializeComponent();
            this._ShapesToDraw = shapesToDraw;
        }
        #endregion

        #region Event handlers
        private void GraphicsWindow_Load(object sender, EventArgs e)
        {
            this.sceneCanvas1.DrawShapes(this._ShapesToDraw);
        } 
        #endregion
    }
}
