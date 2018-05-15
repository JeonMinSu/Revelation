using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Ensuing_Tail_Decorator : DecoratorTask
{

    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        Vector3 Target = (Player.position - Dragon.position).normalized;

        float Dot = Vector3.Dot(Dragon.forward, Target);

        bool IsLeftPowAttack = BlackBoard.Instance.IsLeftPowAttack;
        bool IsRightPowAttack = BlackBoard.Instance.IsRightPowAttack;
        bool IsTailAttack = BlackBoard.Instance.IsTailAttack;

        if ((Dot < Mathf.Cos(Mathf.Deg2Rad * 180.0f * 0.5f) &&
            !IsLeftPowAttack && !IsRightPowAttack) || IsTailAttack)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
