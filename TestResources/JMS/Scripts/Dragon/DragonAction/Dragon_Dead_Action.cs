﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Dead_Action : ActionTask {

    public override bool Run()
    {
        Debug.Log("Dead_Action");
        return false;
    }

}
