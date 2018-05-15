using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_OverLapEnsuing_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsEnsuingAttack = BlackBoard.Instance.IsEnsuingAttack;

        if (IsEnsuingAttack)
        {
            Debug.Log("Ensuing_OverLap_Decorator");
            return ChildNode.Run();
        }
        return false;
    }

}
