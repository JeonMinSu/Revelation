﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Dead_Action : ActionTask
{

    public override bool Run()
    {
        Debug.Log("Dead.Action");
        return false;
    }
}
