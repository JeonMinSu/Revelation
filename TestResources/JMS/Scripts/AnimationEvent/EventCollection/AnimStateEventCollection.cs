using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class AnimStateEventCollection : BaseAnimStateEventsCollection
{

    protected override void Awake()
    {
        base.Awake();
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_Rush_AttackRun_StartJump_Evn, "Dragon_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_Rush_AttackRun_Jamp_Evn, "Dragon_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_RushAttack_Land_Evn, "Dragon_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_RushAttack_Sliding_Evn, "Dragon_Rush_Run");

    }


    private void Dragon_Rush_AttackRun_StartJump_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward + Vector3.up).normalized;

        float RushMoveSpeed = evnData.FloatParam;

        r.AddForce(Dragon.forward * RushMoveSpeed, ForceMode.Impulse);
    }

    private void Dragon_Rush_AttackRun_Jamp_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward + Vector3.up * 0.5f).normalized;


        float RushMoveSpeed = evnData.FloatParam;
        r.AddForce(MoveDir * RushMoveSpeed, ForceMode.Impulse);
    }

    private void Dragon_RushAttack_Land_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward + Vector3.down * 3.0f).normalized;

        float RushMoveSpeed = evnData.FloatParam;

        r.AddForce(MoveDir * RushMoveSpeed, ForceMode.Impulse);
    }

    private void Dragon_RushAttack_Sliding_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward).normalized;

        float RushMoveSpeed = evnData.FloatParam;

        r.AddForce(MoveDir * RushMoveSpeed, ForceMode.Impulse);
    }




}
