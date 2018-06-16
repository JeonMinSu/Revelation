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
        if (ChildNode.GetComponent<ActionTask>())
        {

            ChildNode.NodeState = TASKSTATE.RUNNING;
            ChildNode.OnStart();
        }
        base.OnStart();
    }

    public override void OnEnd()
    {
        if (ChildNode.GetComponent<ActionTask>())
        {
            ChildNode.NodeState = TASKSTATE.FAULURE;
            ChildNode.OnEnd();
        }
        base.OnEnd();
    }

}
