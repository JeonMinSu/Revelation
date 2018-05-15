using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Attack_Decorator : DecoratorTask
{
    public override bool Run()
    {
        bool isAttack = BlackBoard.Instance.IsAttack;

        if (isAttack)
        {
            return ChildNode.Run();
        }
        return false;
    }

}
