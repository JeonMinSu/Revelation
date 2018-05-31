using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class AnimStateEventCollection : BaseAnimStateEventsCollection
{

    protected override void Awake()
    {
        base.Awake();
        AddAnimTimeEventFunc(_animTimeEventFunc, Boss_Rush_AttackRun_StartJump_Evn, "Boss_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Boss_Rush_AttackRun_Jamp_Evn, "Boss_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Boss_RushAttack_Land_Evn, "Boss_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Boss_RushAttack_Sliding_Evn, "Boss_Rush_Run");

    }


    private void Boss_Rush_AttackRun_StartJump_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;

        Transform Dragon = UtilityManager.Instance.DragonTransform();

        Vector3 MoveDir = (Dragon.forward + Vector3.up).normalized;


        r.AddForce(Dragon.forward * 575.0f, ForceMode.Impulse);

        Debug.Log("StartMove");
    }


    private void Boss_Rush_AttackRun_Jamp_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward + Vector3.up * 0.5f).normalized;

        r.AddForce(MoveDir * 120.0f, ForceMode.Impulse);
        //r.AddForce(Dragon.forward * 100.0f, ForceMode.Force);

        Debug.Log("Jamp");

    }

    private void Boss_RushAttack_Land_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();

        Vector3 MoveDir = (Dragon.forward + Vector3.down * 3.0f).normalized;
        r.AddForce(MoveDir * 500.0f, ForceMode.Impulse);
        Debug.Log("Landing");

    }

    private void Boss_RushAttack_Sliding_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();

        Vector3 MoveDir = (Dragon.forward).normalized;
        r.AddForce(MoveDir * 110.0f, ForceMode.Impulse);
        Debug.Log("Sliding");

    }
}
