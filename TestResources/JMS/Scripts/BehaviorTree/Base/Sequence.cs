using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : CompositeTask
{

    public override bool Run()
    {
        foreach (TreeNode child in ChildNodes)
        {
            if (!child.Run())
            {
                if (NodeState != TASKSTATE.RUNNING)
                    NodeState = TASKSTATE.RUNNING;
                return false;
            }
        }
        if (NodeState != TASKSTATE.FAULURE)
            NodeState = TASKSTATE.FAULURE;
        return true;
    }


}
