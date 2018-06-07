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
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_Rush_AttackRun_Jamping_Evn, "Dragon_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_Rush_AttackRun_Jamp_Evn, "Dragon_Rush_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_RushAttack_Sliding_Evn, "Dragon_Rush_Run");

        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_RightPow_AttackRun_Evn, "RightPow_Attack_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_RightPow_AttackRun_Evn, "LeftPow_Attack_Run");

        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_RightPow_Attack_Shake_Evn, "RightPow_Attack_Run");
        AddAnimTimeEventFunc(_animTimeEventFunc, Dragon_LeftPow_Attack_Shake_Evn, "LeftPow_Attack_Run");

    }

    private void Dragon_Rush_AttackRun_StartJump_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward + Vector3.up * 3.5f).normalized;

        float RushMoveSpeed = evnData.FloatParam;

        r.AddForce(Dragon.forward * RushMoveSpeed, ForceMode.Impulse);

        Debug.Log("Start_Jump");
    }

    private void Dragon_Rush_AttackRun_Jamping_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward).normalized;


        float RushMoveSpeed = evnData.FloatParam;
        r.AddForce(MoveDir * RushMoveSpeed, ForceMode.Impulse);

        //Debug.Log("Run_Jamp");
    }

    private void Dragon_Rush_AttackRun_Jamp_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward + Vector3.down * 3.5f).normalized;

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

    private void Dragon_RightPow_AttackRun_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward).normalized;

        float RightPowMoveSpeed = evnData.FloatParam;

        r.AddForce(MoveDir * RightPowMoveSpeed, ForceMode.Impulse);

    }

    private void Dragon_LeftPow_AttackRun_Evn(EvnData evnData)
    {
        Rigidbody r = DragonManager.Instance.DragonRigidBody;
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Vector3 MoveDir = (Dragon.forward).normalized;

        float RightPowMoveSpeed = evnData.FloatParam;

        r.AddForce(MoveDir * RightPowMoveSpeed, ForceMode.Impulse);

    }

    private void Dragon_RightPow_Attack_Shake_Evn(EvnData evnData)
    {
        UtilityManager.Instance.ShakePlayerDistance();
        Debug.Log("RightRow_Attack_Exit_Evn");
    }
    
    private void Dragon_LeftPow_Attack_Shake_Evn(EvnData evnData)
    {
        UtilityManager.Instance.ShakePlayerDistance();
        Debug.Log("LeftRow_Attack_Exit_Evn");
    }






}
