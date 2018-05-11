﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_OverLapEnsuing_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsSecondaryOverLap = BlackBoard.Instance.IsSecondaryOverLap;

        if (IsSecondaryOverLap)
        {
            return ChildNode.Run();
        }
        return false;
    }

}
