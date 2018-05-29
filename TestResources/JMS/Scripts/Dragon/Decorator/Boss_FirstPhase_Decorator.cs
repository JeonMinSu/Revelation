﻿
using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FirstPhase_Decorator : DecoratorTask
{
    public override bool Run()
    {
        float CurHP = DragonManager.Stat.HP;
        float MaxHP = DragonManager.Stat.MaxHP;
        float PhasePercent = DragonManager.Stat.FirstPhaseHpPercent;

        if (CurHP <= MaxHP * PhasePercent)
        {
            return ChildNode.Run();
        }
        return false;
    }

}
