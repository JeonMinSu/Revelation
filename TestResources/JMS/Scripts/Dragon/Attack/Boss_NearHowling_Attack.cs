using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_NearHowling_Attack : ActionTask
{
    public override bool Run()
    {
        bool isNearHowlingAttacking = BlackBoard.Instance.IsNearHowlingAttacking;

        if (!isNearHowlingAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreNearHowlingTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().SecondAttackAfterTime;

            CoroutineManager.DoCoroutine(NearHowlingCor(preTime, afterTime));

        }

        return true;
    }

    IEnumerator NearHowlingCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsNearHowlingAttacking = true;

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunNearHowlingTime;

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(runTime));

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float WalkDistance = BlackBoard.Instance.RushDistance;

        BlackBoard.Instance.IsWalk = 
            !UtilityManager.DistanceCalc(Dragon, Player, WalkDistance);

        BlackBoard.Instance.GetGroundTime().CurWalkTime =
            (BlackBoard.Instance.IsWalk) ? 0.0f : BlackBoard.Instance.GetGroundTime().MaxWalkTime;

        WeakPointManager.Instance.CurrentPatternCount++;

    }

}
