using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class KDTreeIntersectionUtility
    {
        public static void IntersectTree(KDTreeNode node, Point point, UserMessaging messagingAgent)
        {
            if (node.IsNodeLeaf)
            {
                foreach (Shape shape in node.NodeBox.Shapes)
                {
                    if (shape.Intersects(point))
                    {
                        messagingAgent.SendMessage(shape.Name);
                    }
                }
            }
            else
            {
                if (node.LeftChild.NodeBox.Intersects(point))
                {
                    IntersectTree(node.LeftChild, point, messagingAgent);
                }
                else
                {
                    IntersectTree(node.RightChild, point, messagingAgent);
                }
            }
        }
    }
}
