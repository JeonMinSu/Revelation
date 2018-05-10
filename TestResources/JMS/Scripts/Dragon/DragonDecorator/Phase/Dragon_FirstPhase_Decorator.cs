using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_FirstPhase_Decorator : DecoratorTask {

    public override bool Run()
    {
        float CurHP = DragonManager.Stat.HP;
        float MaxHP = DragonManager.Stat.MaxHP;
        float SecondPhaseHP = DragonManager.Stat.SecondPhaseHpPercent;

        if (CurHP >= MaxHP * SecondPhaseHP)
        {
            Debug.Log("FirstPhaseDecorator");
            return ChildNode.Run();
        }
        return false;
    }
}
