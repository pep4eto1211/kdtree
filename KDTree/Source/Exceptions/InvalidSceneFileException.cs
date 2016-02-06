using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class InvalidSceneFileException : Exception
    {
        #region Privte members
        private string _Message;
        #endregion

        #region Constructor
        public InvalidSceneFileException(string message)
        {
            this._Message = message;
        }
        #endregion

        #region Public properties
        public override string Message
        {
            get
            {
                return this._Message;
            }
        } 
        #endregion
    }
}
