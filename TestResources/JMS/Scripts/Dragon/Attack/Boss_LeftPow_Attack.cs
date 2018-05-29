using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //선딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        //런 애니메이션
        while (curTime <= runTime)
        {

            Debug.Log("LeftPowAttack");
            yield return CoroutineManager.FiexdUpdate;
            curTime += Time.fixedDeltaTime;
        }

        //후딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));
        BlackBoard.Instance.IsLeftPowAttacking = false;
        BlackBoard.Instance.IsSecondAttack = false;
        BlackBoard.Instance.IsSecondAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;

    }


}
