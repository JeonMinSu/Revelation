using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Tail_Attack_Decorator : DecoratorTask
{

    public override bool Run()
    {
            
        return false;
    }

    //public override bool Run()
    //{

    //    bool IsSecondAttacking = BlackBoard.Instance.IsSecondAttacking;

    //    if (!IsSecondAttacking)
    //    {
    //        float preTime = BlackBoard.Instance.GetGroundTime().SecondAttackPreTime;
    //        float afterTime = BlackBoard.Instance.GetGroundTime().SecondAttackAfterTime;

    //        CoroutineManager.DoCoroutine(TailAttackCor(preTime, afterTime));

    //    }

    //    return true;
    //}


    //IEnumerator TailAttackCor(float preTime, float afterTime)
    //{
    //    BlackBoard.Instance.IsSecondAttacking = true;
    //    BlackBoard.Instance.IsTailAttacking = true;

    //    float curTime = 0.0f;
    //    float runTime = BlackBoard.Instance.GetGroundTime().SecondAttackRunTime;

    //    yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));


    //    while (curTime < runTime)
    //    {
    //        Debug.Log("TailAttack");
    //        yield return CoroutineManager.FiexdUpdate;
    //        curTime += Time.fixedDeltaTime;

    //    }

    //    yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));
    //    BlackBoard.Instance.IsTailAttacking = false;
    //    BlackBoard.Instance.IsSecondAttack = false;
    //    BlackBoard.Instance.IsSecondAttacking = false;
    //    BlackBoard.Instance.IsGroundAttacking = false;
    //}


}
