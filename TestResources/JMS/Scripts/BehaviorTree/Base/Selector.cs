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
                if (NodeState != TASKSTATE.FAULURE)
                    NodeState = TASKSTATE.FAULURE;
                Debug.Log(child.name);
                return true;
            }
        }
        if (NodeState != TASKSTATE.RUNNING)
            NodeState = TASKSTATE.RUNNING;
        return false; 
    }
}
