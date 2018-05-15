using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Ensuing_LeftPow_Decorator : DecoratorTask
{

    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        Vector3 Target = (Player.position - Dragon.position).normalized;

        float Dot = Vector3.Dot(Dragon.forward, Target);

        if (Dot >= Mathf.Cos(Mathf.Deg2Rad * 180.0f * 0.5f))
        {
            Vector3 cross = Vector3.Cross(Dragon.forward, Target);
            float result = Vector3.Dot(cross, Vector3.up);

            bool IsLeftPowAttack = BlackBoard.Instance.IsLeftPowAttack;
            bool IsRightPowAttack = BlackBoard.Instance.IsRightPowAttack;
            bool IsTailAttack = BlackBoard.Instance.IsTailAttack;

            if ((result < 0.0f && !IsRightPowAttack && !IsTailAttack) || IsLeftPowAttack) 
            {
                Debug.Log("Left_Pow_Decorator");
                return ChildNode.Run();
            }
        }
        return true;
    }


}
