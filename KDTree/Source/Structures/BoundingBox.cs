using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class BoundingBox
    {
        #region Private variables
        private List<Shape> _Shapes;
        private Point _Position;
        private float _Width;
        private float _Hight;
        #endregion

        #region Constructor
        public BoundingBox(Point position, float width, float height)
        {
            this._Position = position;
            this._Width = width;
            this._Hight = height;
        }
        #endregion

        #region Public methods
        public void Split(float splitCoordinate, SplitDirection direction, out BoundingBox boundingBox1, out BoundingBox boundingBox2)
        {
            if ((splitCoordinate <= 0) || (splitCoordinate >= 1))
            {
                throw new ArgumentException("The argument splitCoordinate must be between 0 and 1, excluding both.");
            }

            if (direction == SplitDirection.X)
            {
                boundingBox1 = new BoundingBox(this._Position, this._Width * splitCoordinate, this._Hight);
                boundingBox2 = new BoundingBox(new Point(this._Position.X + (splitCoordinate * this._Width), this._Position.Y), this._Width - (this._Width * splitCoordinate), this._Hight);
                foreach (Shape singleShape in this._Shapes)
                {
                    if (singleShape.Position.X < this._Position.X + (splitCoordinate * this._Width))
                    {
                        boundingBox1.Shapes.Add(singleShape);

                        if (singleShape.OutherPoint.X > this._Position.X + (splitCoordinate * this._Width))
                        {
                            boundingBox2.Shapes.Add(singleShape);
                        }
                    }
                    else
                    {
                        boundingBox2.Shapes.Add(singleShape);
                    }
                }
            }
            else
            {
                boundingBox1 = new BoundingBox(this._Position, this._Width, this._Hight * splitCoordinate);
                boundingBox2 = new BoundingBox(new Point(this._Position.X, this._Position.Y - (this._Hight * splitCoordinate)), this._Width, this._Hight - (this._Hight - (this._Hight * splitCoordinate)));
                foreach (Shape singleShape in this._Shapes)
                {
                    if (singleShape.Position.Y > this._Position.Y - (splitCoordinate * this._Hight))
                    {
                        boundingBox1.Shapes.Add(singleShape);

                        if (singleShape.BottomPoint.Y < this._Position.Y - (splitCoordinate * this._Hight))
                        {
                            boundingBox2.Shapes.Add(singleShape);
                        }
                    }
                    else
                    {
                        boundingBox2.Shapes.Add(singleShape);
                    }
                }
            }
        }

        public bool Intersects(Point point)
        {
            return (((point.X >= this._Position.X) && (point.X <= (this._Position.X + this._Width))) && ((point.Y <= this._Position.Y) && (point.Y >= (this._Position.Y - this._Hight))));
        }
        #endregion

        #region Public properties
        public List<Shape> Shapes
        {
            get
            {
                if (_Shapes == null)
                {
                    _Shapes = new List<Shape>();
                }
                return _Shapes;
            }

            set
            {
                _Shapes = value;
            }
        } 

        public Point Position
        {
            get
            {
                return this._Position;
            }
            set
            {
                this._Position = value;
            }
        }

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
        public float Hight
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
        #endregion
    }     
}
