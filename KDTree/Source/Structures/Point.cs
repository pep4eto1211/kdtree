using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class Point
    {
        #region Private members
        private float _X;
        private float _Y;
        #endregion

        #region Constructor
        public Point(float x, float y)
        {
            this._X = x;
            this._Y = y;
        }
        #endregion

        #region Public properties
        public float X
        {
            get
            {
                return this._X;
            }
            set
            {
                this._X = value;
            }
        }

        public float Y
        {
            get
            {
                return this._Y;
            }
            set
            {
                this._Y = value;
            }
        }
        #endregion
    }
}
