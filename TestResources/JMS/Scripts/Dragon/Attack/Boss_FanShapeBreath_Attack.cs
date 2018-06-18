using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_FanShapeBreath_Attack : ActionTask
{

    public override void OnStart()
    {
        float preTime = BlackBoard.Instance.GetGroundTime().PreRushTime;
        float runTime = BlackBoard.Instance.GetGroundTime().RunRushTime;
        float afterTime = BlackBoard.Instance.GetGroundTime().AfterRushTime;

        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsFanShapeBreathAttacking = true;

        ActionCor = FanShapeBreathCor(preTime, runTime, afterTime);

        base.OnStart();
    }

    public override bool Run()
    {
        return false;
    }

    public override void OnEnd()
    {
        base.OnEnd();

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float OverLapDistance = BlackBoard.Instance.RushDistance;

        BlackBoard.Instance.IsFanShapeBreathAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;

        BlackBoard.Instance.IsOverLapAttack =
            (UtilityManager.DistanceCalc(Dragon, Player, OverLapDistance)) ? false : true;

        WeakPointManager.Instance.CurrentPatternCount++;

    }


    IEnumerator FanShapeBreathCor(float preTime, float runTime, float afterTime)
    {
        Transform DragonMouth = BlackBoard.Instance.DragonMouth;

        DragonAniManager.SwicthAnimation("FanShape_Atk");

        yield return CoroutineManager.GetWaitForSeconds(runTime);

        OnEnd();

    }

}
