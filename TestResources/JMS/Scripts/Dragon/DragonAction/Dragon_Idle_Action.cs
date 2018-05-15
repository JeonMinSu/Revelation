using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Idle_Action : ActionTask {

    public override bool Run()
    {
        DragonManager.Instance.SwicthAnimation("Idle");
        BlackBoard.Instance.GetGroundTime().CurIdleTime += Time.deltaTime;
        return false;
    }
}
