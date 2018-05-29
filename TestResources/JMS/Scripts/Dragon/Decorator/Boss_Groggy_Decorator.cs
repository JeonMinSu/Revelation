using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Groggy_Decorator : DecoratorTask
{
    public override bool Run()
    {
        float CurHP = DragonManager.Stat.HP;
        float MaxHP = DragonManager.Stat.MaxHP;
        float GroggyHP = MaxHP * DragonManager.Stat.GroggyHpPercent;

        if (CurHP <= GroggyHP)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
