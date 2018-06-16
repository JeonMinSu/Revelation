using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CompositeTask
{
    public override void OnStart()
    {
        base.OnStart();
    }


    public override bool Run()
    {
        foreach (TreeNode child in ChildNodes)
        {
            if (child.Run())
            {
            //    if (NodeState != TASKSTATE.RUNNING)
            //        OnStart();
                return true;
            }
        }

        //if (NodeState != TASKSTATE.FAULURE)
        //    OnEnd();

        return false; 
    }

    public override void OnEnd()
    {
        base.OnEnd();
    }


}
