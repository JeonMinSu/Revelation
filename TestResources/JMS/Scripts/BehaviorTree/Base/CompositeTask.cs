using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeTask : TreeNode
{

    public override void OnStart()
    {
        NodeState = TASKSTATE.RUNNING;
        base.OnStart();
    }

    public override void ChildAdd(TreeNode node)
    {
        ChildNodes.Add(node);
    }

    public override void OnEnd()
    {
        NodeState = TASKSTATE.FAULURE;
        base.OnEnd();
    }

}
