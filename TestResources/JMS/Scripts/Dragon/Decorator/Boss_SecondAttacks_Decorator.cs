using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_SecondAttacks_Decorator : DecoratorTask
{
    public override bool Run()
    {
        bool IsSecondAttack = BlackBoard.Instance.IsSecondAttack;

        if (IsSecondAttack)
        {
            //Debug.Log("Second_Attack_Decorator");
            return ChildNode.Run();
        }

        return true;
    }

}
