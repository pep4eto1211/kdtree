using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class Rectangle : Shape
    {
        #region Private members
        private float _Width;
        private float _Hight;
        #endregion

        #region Constructor
        public Rectangle(string name, Point position, float width, float hight)
        {
            this._Position = position;
            this._Width = width;
            this._Hight = hight;
            this._Name = name;
        }
        #endregion

        #region Inherited methods
        public override bool Intersects(Point point)
        {
            return (((point.X >= this._Position.X) && (point.X <= (this._Position.X + this._Width))) && ((point.Y <= this._Position.Y) && (point.Y >= (this._Position.Y - this._Hight))));
        }
        #endregion

        #region Public properties
        public float Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this._Width = value;
            }
        }

        public float Height
        {
            get
            {
                return this._Hight;
            }
            set
            {
                this._Hight = value;
            }
        }

        public override Point OutherPoint
        {
            get
            {
                return new Point(this._Position.X + this._Width, this._Position.Y);
            }
        }

        public override Point BottomPoint
        {
            get
            {
                return new Point(this._Position.X, this._Position.Y - this._Hight);
            }
        }
        #endregion
    }
}
