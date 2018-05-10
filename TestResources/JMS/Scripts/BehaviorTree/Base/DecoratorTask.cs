using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorTask : TreeNode
{
    private TreeNode _childNode;
    public TreeNode ChildNode { get { return _childNode; } }

    public override void ChildAdd(TreeNode Node)
    {
        _childNode = Node;
    }

}
