using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public abstract class Shape
    {
        #region Protected members
        protected Point _Position;
        protected string _Name;
        #endregion

        #region Public methods
        /// <summary>
        /// Checks if a given points lies within the shape
        /// </summary>
        /// <param name="point">The point to be checked</param>
        /// <returns>True if the point lies in the shape</returns>
        public virtual bool Intersects(Point point)
        {
            return false;
        }
        #endregion

        #region Public properties
        public Point Position
        {
            get
            {
                return _Position;
            }

            set
            {
                _Position = value;
            }
        } 

        public virtual Point OutherPoint
        {
            get
            {
                return null;
            }
        }

        public virtual Point BottomPoint
        {
            get
            {
                return null;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }
        #endregion
    }
}
