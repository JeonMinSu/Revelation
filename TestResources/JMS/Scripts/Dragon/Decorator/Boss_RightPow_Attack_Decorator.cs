using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_RightPow_Attack_Decorator : DecoratorTask
{

    public override bool Run()
    {

        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        Vector3 toTarget = (Player.position - Boss.position).normalized;

        float Dot = Vector3.Dot(Boss.forward, toTarget);

        bool IsRightPowAttacking = BlackBoard.Instance.IsRightPowAttacking;
        bool IsSecondAttacking = BlackBoard.Instance.IsSecondAttacking;

        if (IsRightPowAttacking)
        {
            Debug.Log("RightPowAttack");
            return ChildNode.Run();
        }

        if (!IsSecondAttacking)
        {
            if (Dot >= Mathf.Cos(Mathf.Deg2Rad * 180.0f * 0.5f))
            {
                Vector3 Cross = Vector3.Cross(Boss.forward, toTarget);

                float Reulst = Vector3.Dot(Cross, Vector3.up);

                if (Reulst >= 0.0f)
                {
                    return ChildNode.Run();
                }
            }
        }
        return true;
    }

}
