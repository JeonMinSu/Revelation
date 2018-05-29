using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rush_Attack : ActionTask
{

    public override bool Run()
    {
        bool IsRushAttacking = BlackBoard.Instance.IsRushAttacking;

        if (!IsRushAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreRushTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterRushTime;

            CoroutineManager.DoCoroutine(RushAttackCor(preTime, afterTime));
        }

        return false;
    }

    IEnumerator RushAttackCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsRushAttacking = true;

        float curTime  = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunRushTime;

        //선딜 애니메이션
        DragonAniManager.SwicthAnimation("Rush_Atk_Pre");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        DragonAniManager.SwicthAnimation("Rush_Atk_Run");
        while (curTime < runTime)
        {
            Debug.Log("RushAttack");
            curTime += Time.fixedDeltaTime;
            yield return CoroutineManager.FiexdUpdate;
        }


        //후딜 애니메이션
        DragonAniManager.SwicthAnimation("Rush_Atk_After");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float SecondAttackDistance = BlackBoard.Instance.SecondAttackDistance;

        BlackBoard.Instance.IsSecondAttack = UtilityManager.DistanceCalc(Boss, Player, SecondAttackDistance);
        BlackBoard.Instance.IsRushAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = (BlackBoard.Instance.IsSecondAttack) ? true : false;

    }

}
