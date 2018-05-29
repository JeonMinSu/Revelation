using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Dead_Decorator : DecoratorTask
{
    public override bool Run()
    {
        float CurHP = DragonManager.Stat.HP;

        if (CurHP <= 0.0f)
        {   
            return ChildNode.Run();
        }
        return true;
    }

}
