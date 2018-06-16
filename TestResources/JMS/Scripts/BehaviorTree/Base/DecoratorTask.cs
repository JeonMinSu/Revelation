using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorTask : TreeNode
{
    private bool _isEndOn;

    private TreeNode _childNode;
    public TreeNode ChildNode { get { return _childNode; } }

    public override void ChildAdd(TreeNode Node)
    {
        _childNode = Node;
    }

    public override void OnStart()
    {
        NodeState = TASKSTATE.RUNNING;
        base.OnStart();
    }

    public override void OnEnd()
    {
        NodeState = TASKSTATE.FAULURE;
        base.OnEnd();
    }

}
