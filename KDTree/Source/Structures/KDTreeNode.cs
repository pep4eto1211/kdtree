using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDTree
{
    public class KDTreeNode
    {
        #region Private members
        private KDTreeNode _LeftChild;
        private KDTreeNode _RightChild;
        private BoundingBox _NodeBox;
        #endregion

        public KDTreeNode(BoundingBox nodeBox)
        {
            this._NodeBox = nodeBox;
        }

        #region Public properties
        public BoundingBox NodeBox
        {
            get
            {
                return _NodeBox;
            }

            set
            {
                _NodeBox = value;
            }
        }

        public KDTreeNode RightChild
        {
            get
            {
                return _RightChild;
            }

            set
            {
                _RightChild = value;
            }
        }

        public KDTreeNode LeftChild
        {
            get
            {
                return _LeftChild;
            }

            set
            {
                _LeftChild = value;
            }
        } 

        public bool IsNodeLeaf
        {
            get
            {
                return ((LeftChild == null) && (RightChild == null));
            }
        }
        #endregion
    }
}
