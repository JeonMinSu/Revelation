using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Ensuing_Tail_Attack : ActionTask
{

    public override bool Run()
    {
        bool IsTailAttack = BlackBoard.Instance.IsTailAttack;

        if (!IsTailAttack)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreEnsuingAttackTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterEnsuingAttackTime;

            CoroutineManager.DoCoroutine(TailAttack(preTime, afterTime));
        }


        return false;
    }
    IEnumerator TailAttack(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsTailAttack = true;

        //선딜 모션 넣는 곳
        yield return new WaitForSeconds(preTime);

        float CurTime = 0.0f;
        float RunTime = BlackBoard.Instance.GetGroundTime().RunEnsuingAttackTime;

        //공격 모션
        while (CurTime < RunTime)
        {
            Debug.Log("Tail_Attack");
            CurTime += Time.deltaTime;
            yield return CoroutineManager.EndOfFrame;
        }

        yield return CoroutineManager.EndOfFrame;
        BlackBoard.Instance.IsTailAttack = false;
        BlackBoard.Instance.IsEnsuingAttack = false;
        BlackBoard.Instance.IsGroundPatternAct = false;
    }
}
