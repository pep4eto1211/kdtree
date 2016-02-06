using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public abstract class UserMessaging
    {
        #region Public methods
        public virtual void SendMessage(string message)
        {
            return;
        }
        #endregion
    }
}
