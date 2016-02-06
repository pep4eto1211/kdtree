using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KDTree.Source.Graphics.UserControls
{
    /// <summary>
    /// Interaction logic for SceneCanvas.xaml
    /// </summary>
    public partial class SceneCanvas : UserControl
    {
        #region Constructor
        public SceneCanvas()
        {
            InitializeComponent();
        }
        #endregion

        #region Public methods
        public void DrawShapes(List<Shape> shapesToDraw)
        {
            double conversionValue = (double)761 / 1000;

            foreach (Shape shape in shapesToDraw)
            {
                if (shape is Rectangle)
                {
                    System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
                    rect.Width = ((Rectangle)shape).Width * conversionValue;
                    rect.Height = ((Rectangle)shape).Height * conversionValue;
                    rect.Fill = Brushes.Red;
                    Canvas.SetBottom(rect, shape.Position.Y * conversionValue);
                    Canvas.SetLeft(rect, shape.Position.X * conversionValue);

                    this.drawingCanvas.Children.Add(rect);
                }
                else
                {
                    System.Windows.Shapes.Ellipse rect = new System.Windows.Shapes.Ellipse();
                    rect.Width = ((Circle)shape).Radius * conversionValue;
                    rect.Height = ((Circle)shape).Radius * conversionValue;
                    rect.Fill = Brushes.Green;
                    Canvas.SetBottom(rect, shape.Position.Y * conversionValue);
                    Canvas.SetLeft(rect, shape.Position.X * conversionValue);

                    this.drawingCanvas.Children.Add(rect);
                }
            }
        }
        #endregion
    }
}
