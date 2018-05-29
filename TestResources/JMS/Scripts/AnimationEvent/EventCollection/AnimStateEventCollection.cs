using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class AnimStateEventCollection : BaseAnimStateEventsCollection
{

    private void Awake()
    { 
        //AddAnimEnterEventFunc(_animEnterEventFunc, RightPow_Atk_Evn, "RightPow");
        //AddAnimEnterEventFunc(_animEnterEventFunc, RightPow_Atk_Evn, "RightPow");

        AddAnimEnterEventFunc(_animEnterEventFunc, Boss_Rush_Attack_Evn, "Rush");

    }

    private void RightPow_Atk_Evn(EvnData evnData)
    {

    }

    private void Boss_Rush_Attack_Evn(EvnData evnData)
    {
        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float curTime = BlackBoard.Instance.GetGroundTime().SecondAttackCurTime;
        float MaxTime = BlackBoard.Instance.GetGroundTime().SecondAttackRunTime;

        Boss.position =
            Vector3.Lerp(
                Boss.position,
                Boss.position + Boss.forward * 3.0f,
                curTime / MaxTime * 0.1f);
    }
}
