using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Third_Decorator : DecoratorTask {

    public override bool Run()
    {
        float CurHP = DragonManager.Stat.HP;
        float MaxHP = DragonManager.Stat.MaxHP;
        float ThirdPhaseHP = DragonManager.Stat.ThirdPhaseHpPercent;

        if (CurHP < MaxHP * ThirdPhaseHP)
        {
            Debug.Log("ThridPhaseDecorator");
            return ChildNode.Run();
        }
        return true;
    }

}
