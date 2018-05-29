using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_Idle_Action : ActionTask
{

    public override bool Run()
    {
        DragonAniManager.SwicthAnimation("Idle");
        BlackBoard.Instance.GetGroundTime().CurIdleTime += Time.deltaTime;
        return true;
    }

}
