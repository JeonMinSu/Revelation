using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class AnimStateEventCollection : BaseAnimStateEventsCollection
{

    protected override void Awake()
    {
        //AddAnimEnterEventFunc(_animEnterEventFunc, RightPow_Atk_Evn, "RightPow");
        //AddAnimEnterEventFunc(_animEnterEventFunc, RightPow_Atk_Evn, "RightPow");
        //AddAnimEnterEventFunc(_animEnterEventFunc, Boss_Rush_Attack_Run_Evn, "Rush");
        base.Awake();
        AddAnimTimeEventFunc(_animTimeEventFunc, Boss_Rush_Attack_Run_Evn, "Boss_Rush_Run");

    }

    private void Boss_Rush_Attack_Run_Evn(EvnData evnData)
    {
        //Rigidbody rg = Manager.DragonRigidBody;
        Debug.Log(Manager.DragonRigidBody);

    }
}
