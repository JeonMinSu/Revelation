using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_BulletBreath_Attack : ActionTask
{
    public override bool Run()
    {
        bool IsBulletBreathAttacking = BlackBoard.Instance.IsBulletBreathAttacking;

        if (!IsBulletBreathAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreBulletBreathTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterBulletBreathTime;

            CoroutineManager.DoCoroutine(BulletBreathCor(preTime, afterTime));

        }

        return false;
    }

    IEnumerator BulletBreathCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsBulletBreathAttacking = true;

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunBulletBreathTime;
        
        //선딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        while (curTime < runTime)
        {
            Debug.Log("BulletBreath");
            curTime += Time.fixedDeltaTime;
            yield return CoroutineManager.FiexdUpdate;
        }

        //후딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float RoarDistanceLimit = BlackBoard.Instance.HowlingDistance;

        BlackBoard.Instance.IsOverLapAttack =
            (UtilityManager.DistanceCalc(Dragon, Player, RoarDistanceLimit)) ? true : false;

        BlackBoard.Instance.IsGroundAttacking = false;
        BlackBoard.Instance.IsBulletBreathAttacking = false;
    }

}
