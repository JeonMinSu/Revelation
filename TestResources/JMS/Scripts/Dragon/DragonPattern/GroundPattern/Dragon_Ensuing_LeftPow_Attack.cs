using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Ensuing_LeftPow_Attack : ActionTask
{

    public override bool Run()
    {
        bool IsLeftPowAttack = BlackBoard.Instance.IsLeftPowAttack;

        if (!IsLeftPowAttack)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreEnsuingAttackTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterEnsuingAttackTime;

            CoroutineManager.DoCoroutine(LeftPowAttack(preTime, afterTime));
        }

        return false;
    }

    IEnumerator LeftPowAttack(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsLeftPowAttack = true;
        //선딜 모션 넣는 곳
        yield return new WaitForSeconds(preTime);
        
        float CurTime = 0.0f;
        float RunTime = BlackBoard.Instance.GetGroundTime().RunEnsuingAttackTime;

        //공격 모션
        while (CurTime < RunTime)
        {
            Debug.Log("LeftPow_Attack");
            CurTime += Time.deltaTime;
            yield return CoroutineManager.EndOfFrame;
        }

        //후딜 모션 넣는 곳
        yield return new WaitForSeconds(afterTime);
        BlackBoard.Instance.IsLeftPowAttack = false;
        BlackBoard.Instance.IsEnsuingAttack = false;
        BlackBoard.Instance.IsGroundPatternAct = false;

    }

    
}
