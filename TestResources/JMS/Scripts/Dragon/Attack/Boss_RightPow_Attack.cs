using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_RightPow_Attack : ActionTask
{

    public override bool Run()
    {

        bool IsSecondAttacking = BlackBoard.Instance.IsSecondAttacking;
        if (!IsSecondAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().SecondAttackPreTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().SecondAttackAfterTime;

            CoroutineManager.DoCoroutine(RightPowAttackCor(preTime, afterTime));
        }
        
        Debug.Log("RightPowAttack");
        return false;
    }

    IEnumerator RightPowAttackCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsSecondAttacking = true;
        BlackBoard.Instance.IsRightPowAttacking = true;

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().SecondAttackRunTime;

        //선딜 애니메이션
        DragonAniManager.SwicthAnimation("RightPow_Atk_Pre");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));


        //런 애니메이션
        DragonAniManager.SwicthAnimation("RightPow_Atk_Run");
        while (curTime < runTime)
        {
            curTime += Time.fixedDeltaTime;
            BlackBoard.Instance.GetGroundTime().SecondAttackCurTime = curTime;
            yield return CoroutineManager.FiexdUpdate;
        }

        //후딜 애니메이션
        DragonAniManager.SwicthAnimation("RightRow_Atk_After");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        BlackBoard.Instance.IsRightPowAttacking = false;
        BlackBoard.Instance.IsSecondAttacking = false;

    }

}
