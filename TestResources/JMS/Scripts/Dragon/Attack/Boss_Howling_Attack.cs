using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Howling_Attack : ActionTask
{
    public override bool Run()
    {
        bool IsRoarAttacking = BlackBoard.Instance.IsRoarAttacking;

        if (!IsRoarAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreRoarTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterRoarTime;

            CoroutineManager.DoCoroutine(RoarAttackCor(preTime, afterTime));

        }

        return false;
    }

    IEnumerator RoarAttackCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsRoarAttacking = true;

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunRoarTime;

        //선딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        while (curTime< runTime)
        {
            Debug.Log("RoarAttack");
            yield return CoroutineManager.FiexdUpdate;
            curTime += Time.fixedDeltaTime;
        }


        yield return CoroutineManager.FiexdUpdate;

        //후딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        BlackBoard.Instance.IsRoarAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;


    }


}
