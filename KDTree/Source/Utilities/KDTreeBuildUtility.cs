using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace KDTree
{
    public class KDTreeBuildUtility
    {
        public static KDTreeNode BuildKdTree(BoundingBox boundingBox, int treeLevel)
        {
            treeLevel++;
            if ((boundingBox.Shapes.Count <= int.Parse(ConfigurationManager.AppSettings["maxBoundingBoxObjects"])) || (treeLevel >= int.Parse(ConfigurationManager.AppSettings["maxTreeDepth"])))
            {
                return new KDTreeNode(boundingBox);
            }
            else
            {
                SplitDirection splitDirection;

                if (boundingBox.Width > boundingBox.Hight)
                {
                    splitDirection = SplitDirection.X;
                }
                else
                {
                    splitDirection = SplitDirection.Y;
                }

                BoundingBox leftBox = null;
                BoundingBox rightBox = null;

                boundingBox.Split(0.5f, splitDirection, out leftBox, out rightBox);

                KDTreeNode root = new KDTreeNode(boundingBox);

                root.LeftChild = BuildKdTree(leftBox, treeLevel);
                root.RightChild = BuildKdTree(rightBox, treeLevel);

                return root;
            }
        }
    }
}
