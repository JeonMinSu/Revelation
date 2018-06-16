using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_LeftPow_Attack : ActionTask
{

    public override void OnStart()
    {
        Debug.Log(this.gameObject.name + " : OnStart");
        base.OnStart();
    }

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

    public override void OnEnd()
    {
        Debug.Log(this.gameObject.name + " : OnEnd");
        base.OnEnd();
    }

    IEnumerator LefrPowAttackCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsSecondAttacking = true;
        BlackBoard.Instance.IsLeftPowAttacking = true;
        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().SecondAttackRunTime;


        //선딜
        ParticleManager.Instance.PoolParticleEffectOn("LeftPow");
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
        ParticleManager.Instance.PoolParticleEffectOff("LeftPow");

        BlackBoard.Instance.IsLeftPowAttacking = false;
        BlackBoard.Instance.IsSecondAttacking = false;
        //BlackBoard.Instance.IsSecondAttack = false;
        //BlackBoard.Instance.IsGroundAttacking = false;

        WeakPointManager.Instance.CurrentPatternCount++;

    }


}
