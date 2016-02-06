using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class Circle : Shape
    {
        #region Private members
        private float _Radius;
        #endregion

        #region Constrctor
        public Circle(string name, Point center, float radius)
        {
            this._Position = center;
            this._Radius = radius;
            this._Name = name;
        }
        #endregion

        #region Inherited methods
        public override bool Intersects(Point point)
        {
            return ((point.X - this._Position.X) * (point.X - this._Position.X))
                + ((point.Y - this._Position.Y) * (point.Y - this._Position.Y)) < this._Radius * this._Radius;
        }
        #endregion

        #region Public properties
        public float Radius
        {
            get
            {
                return this._Radius;
            }
            set
            {
                this._Radius = value;
            }
        }

        public override Point OutherPoint
        {
            get
            {
                return new Point(this._Position.X + this._Radius, this._Position.Y);
            }
        }

        public override Point BottomPoint
        {
            get
            {
                return new Point(this._Position.X, this._Position.Y - this._Radius);
            }
        }
        #endregion
    }
}
