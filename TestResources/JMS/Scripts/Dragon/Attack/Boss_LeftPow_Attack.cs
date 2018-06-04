using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_LeftPow_Attack : ActionTask
{

    public override bool Run()
    {
        bool IsSecondAttacking = BlackBoard.Instance.IsSecondAttacking;

        if (!IsSecondAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().SecondAttackPreTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().SecondAttackAfterTime;

            CoroutineManager.DoCoroutine(LefrPowAttackCor(preTime, afterTime));
        }


        return false;
    }

    IEnumerator LefrPowAttackCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsSecondAttacking = true;
        BlackBoard.Instance.IsLeftPowAttacking = true;

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().SecondAttackRunTime;

        DragonManager.Instance.LeftPowEffect.SetActive(true);
        DragonManager.Instance.LeftClaw.SetActive(true);

        //선딜
        DragonAniManager.SwicthAnimation("LeftPow_Atk_Pre");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        //런 애니메이션
        DragonAniManager.SwicthAnimation("LeftPow_Atk_Run");
        while (curTime <= runTime)
        {
            curTime += Time.fixedDeltaTime;
            BlackBoard.Instance.GetGroundTime().SecondAttackCurTime = curTime;
            yield return CoroutineManager.FiexdUpdate;
        }

        //후딜
        DragonAniManager.SwicthAnimation("LeftPow_Atk_After");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));


        DragonManager.Instance.LeftPowEffect.SetActive(false);
        DragonManager.Instance.LeftClaw.SetActive(false);

        BlackBoard.Instance.IsLeftPowAttacking = false;
        BlackBoard.Instance.IsSecondAttack = false;
        BlackBoard.Instance.IsSecondAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;

    }


}
