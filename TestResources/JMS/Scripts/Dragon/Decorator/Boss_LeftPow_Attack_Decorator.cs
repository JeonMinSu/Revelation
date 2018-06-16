using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_LeftPow_Attack_Decorator : DecoratorTask
{

    public override void OnStart()
    {
        Debug.Log(this.gameObject.name + " : OnStart");
        base.OnStart();
    }

    public override bool Run()
    {
        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        Vector3 toTarget = (Player.position - Boss.position).normalized;

        float Dot = Vector3.Dot(Boss.forward, toTarget);

        bool IsLeftPowAttacking = BlackBoard.Instance.IsLeftPowAttacking;
        bool IsSecondAttacking = BlackBoard.Instance.IsSecondAttacking;
        
        //if (IsLeftPowAttacking)
        //{
        //    if (NodeState != TASKSTATE.RUNNING)
        //        OnStart();
        //    return ChildNode.Run();
        //}



        if (!IsSecondAttacking || IsLeftPowAttacking)
        { 
            if (Dot >= Mathf.Cos(Mathf.Deg2Rad * 180.0f * 0.5f))
            {
                Vector3 Cross = Vector3.Cross(Boss.forward, toTarget);

                float Result = Vector3.Dot(Cross, Vector3.up);

                if (Result < 0.0f || IsLeftPowAttacking)
                {
                    if (NodeState != TASKSTATE.RUNNING)
                        OnStart();
                    return ChildNode.Run();
                }
            }
        }

        if (NodeState != TASKSTATE.RUNNING)
            OnEnd();

        return true;
    }

    public override void OnEnd()
    {
        Debug.Log(this.gameObject.name + ": OnEnd");
        base.OnEnd();
    }

}
