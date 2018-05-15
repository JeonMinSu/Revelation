using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Dead_Decorator : DecoratorTask
{
    public override bool Run()
    {
        if (DragonManager.Stat.HP <= 0)
        {
            return ChildNode.Run();
        }
        return false;
    }

}