using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class ConsoleUserMessaging : UserMessaging
    {
        #region User messaging members
        public override void SendMessage(string message)
        {
            Console.WriteLine("Intersection found with object: " + message);
        }
        #endregion
    }
}
