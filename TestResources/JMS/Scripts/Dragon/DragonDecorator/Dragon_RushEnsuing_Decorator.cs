using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_RushEnsuing_Decorator : DecoratorTask
{
    public override bool Run()
    {
        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;
       
        bool IsEnsuingAttack = BlackBoard.Instance.IsEnsuingAttack;

        if (IsEnsuingAttack)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
