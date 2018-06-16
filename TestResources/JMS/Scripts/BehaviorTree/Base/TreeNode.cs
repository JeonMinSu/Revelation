using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TASKSTATE
{
    SUCCESS = 0,
    FAULURE,
    RUNNING
}

public abstract class TreeNode : MonoBehaviour {

    protected TASKSTATE _nodeState;
    public TASKSTATE NodeState { set { _nodeState = value; } get { return _nodeState; } }

    private List<TreeNode> _childNodes = new List<TreeNode>();
    public List<TreeNode> ChildNodes { get { return _childNodes; } }

    public virtual void ChildAdd(TreeNode Node)
    {
        ChildNodes.Add(Node);
    }

    public virtual void OnStart()
    {
        NodeState = TASKSTATE.RUNNING;
    }
    public abstract bool Run();
    public virtual void OnEnd()
    {
        NodeState = TASKSTATE.FAULURE;
    }

}
