using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_FanShapeBreath_Attack : ActionTask
{

    public override bool Run()
    {
        bool isFanShapeBreathAttacking = BlackBoard.Instance.IsFanShapeBreathAttacking;

        if (!isFanShapeBreathAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreFanShapeBreathTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterFanShapeBreathTime;

            CoroutineManager.DoCoroutine(FanShapeBreathCor(preTime, afterTime));
        }
        return false;
    }

    IEnumerator FanShapeBreathCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsFanShapeBreathAttacking = true;

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunFanShapeBreathTime;

        //선딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        while (curTime < runTime)
        {
            Debug.Log("FanShapeBreath");
            curTime += Time.fixedDeltaTime;
            yield return CoroutineManager.FiexdUpdate;
        }

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float OverLapDistance = BlackBoard.Instance.RushDistance;

        BlackBoard.Instance.IsOverLapAttack =
            (UtilityManager.DistanceCalc(Dragon, Player, OverLapDistance)) ? false : true;

        BlackBoard.Instance.IsGroundAttacking = false;
        BlackBoard.Instance.IsFanShapeBreathAttacking = false;

        WeakPointManager.Instance.CurrentPatternCount++;

    }

}
