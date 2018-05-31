using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CompositeTask {
    
    public override bool Run()
    {
        foreach (TreeNode child in ChildNodes)
        {
            if (child.Run())
            {
                if (NodeState != TASKSTATE.SUCCESS)
                    NodeState = TASKSTATE.SUCCESS;
                return true;
            }
        }
        if (NodeState != TASKSTATE.FAULURE)
            NodeState = TASKSTATE.FAULURE;
        return false; 
    }
}
