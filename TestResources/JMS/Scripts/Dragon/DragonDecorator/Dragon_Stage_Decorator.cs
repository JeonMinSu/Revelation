using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Stage_Decorator : DecoratorTask {

    public override bool Run()
    {
        bool isStage = BlackBoard.Instance.IsStage;

        float CurHP = DragonManager.Stat.HP;
        float MaxHP = DragonManager.Stat.MaxHP;

        if (isStage || CurHP == MaxHP)
        {
            return ChildNode.Run();
        }
        return true;
    }
}
