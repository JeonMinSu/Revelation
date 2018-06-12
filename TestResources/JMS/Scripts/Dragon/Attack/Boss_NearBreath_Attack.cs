using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_NearBreath_Attack : ActionTask
{
    public override bool Run()
    {
        bool IsBulletBreathAttacking = BlackBoard.Instance.IsNearBreathAttacking;

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
        BlackBoard.Instance.IsNearBreathAttacking = true;

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

        float OverLapDistance = BlackBoard.Instance.RushDistance;

        BlackBoard.Instance.IsOverLapAttack =
            (UtilityManager.DistanceCalc(Dragon, Player, OverLapDistance)) ? false : true;

        BlackBoard.Instance.IsGroundAttacking = false;
        BlackBoard.Instance.IsNearBreathAttacking = false;
    }

}
