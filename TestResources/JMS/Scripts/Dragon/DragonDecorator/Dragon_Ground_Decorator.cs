using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Ground_Decorator : DecoratorTask
{
    public override bool Run()
    { 
        bool IsGround = BlackBoard.Instance.IsGround;

        if (IsGround)
        {
            return ChildNode.Run();
        }
        return true;
    }


}
