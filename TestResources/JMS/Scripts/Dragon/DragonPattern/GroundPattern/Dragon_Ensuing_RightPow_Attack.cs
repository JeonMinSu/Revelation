using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Ensuing_RightPow_Attack : ActionTask
{
    public override bool Run()
    {
        bool IsRightPowAttack = BlackBoard.Instance.IsRightPowAttack;

        if (!IsRightPowAttack)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreEnsuingAttackTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterEnsuingAttackTime;

            CoroutineManager.DoCoroutine(RightPowAttack(preTime, afterTime));
        }

        return false;
    }

    IEnumerator RightPowAttack(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsRightPowAttack = true;
        //선딜 모션 넣는 곳
        yield return new WaitForSeconds(preTime);

        float CurTime = 0.0f;
        float RunTime = BlackBoard.Instance.GetGroundTime().RunEnsuingAttackTime;

        //공격 모션
        while (CurTime < RunTime)
        {
            Debug.Log("Right_Attack");
            CurTime += Time.deltaTime;
            yield return CoroutineManager.EndOfFrame;
        }

        //후딜 모션 넣는 곳
        yield return new WaitForSeconds(afterTime);

        bool isPatternChk = BlackBoard.Instance.IsRushPattern;

        BlackBoard.Instance.IsRightPowAttack = false;
        BlackBoard.Instance.IsEnsuingAttack = false;
        BlackBoard.Instance.IsGroundPatternAct = false;

    }

}
