using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : CompositeTask
{

    public override void OnStart()
    {
        base.OnStart();
    }

    public override bool Run()
    {
        foreach (TreeNode child in ChildNodes)
        {
            if (!child.Run())
            {
                if (child.NodeState != TASKSTATE.RUNNING)
                {
                    if (child.GetComponent<ActionTask>())
                    {
                        child.NodeState = TASKSTATE.RUNNING;
                        child.OnStart();
                    }
                }
                if (NodeState != TASKSTATE.RUNNING)
                    OnStart();

                return false;
            }
            if (child.NodeState != TASKSTATE.FAULURE)
            {
                Debug.Log(child);
                if (child.GetComponent <ActionTask>())
                {
                    child.NodeState = TASKSTATE.FAULURE;
                    child.OnEnd();
                }
            }
        }
        if (NodeState != TASKSTATE.FAULURE)
        {
            OnEnd();
        }
        return true;
    }

    public override void OnEnd()
    {
        base.OnEnd();
    }
}
