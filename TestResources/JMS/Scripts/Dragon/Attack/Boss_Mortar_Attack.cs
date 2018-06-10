using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Mortar_Attack : ActionTask
{

    public override bool Run()
    {

        bool IsMortarAttacking = BlackBoard.Instance.IsMortarAttacking;

        if (!IsMortarAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreMortarTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterMortarTime;

            CoroutineManager.DoCoroutine(MortarAttackCor(preTime, afterTime));
        }

        return false;
    }

    IEnumerator MortarAttackCor(float preTime, float atfetTime)
    {

        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsMortarAttacking = true;

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunMortarTime;

        //선딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        //공격
        while (curTime < runTime)
        {
            Debug.Log("MortarAttack");
            curTime += Time.fixedDeltaTime;
            yield return CoroutineManager.FiexdUpdate;
        }

        //후딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(atfetTime));

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float BulletBreathDistance = BlackBoard.Instance.BulletBreathDistance;

        BlackBoard.Instance.IsOverLapAttack = 
            (!UtilityManager.DistanceCalc(Dragon, Player, BulletBreathDistance)) ? true : false;

        BlackBoard.Instance.IsMortarAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;

    }


}
