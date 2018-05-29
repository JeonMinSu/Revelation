using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stun_Action : ActionTask
{

    public override bool Run()
    {
        Debug.Log("Stun");
        return false;
    }

}