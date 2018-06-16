using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_LeftPow_Attack : ActionTask
{

    public override void OnStart()
    {
        Debug.Log(this.gameObject.name + " : OnStart");

        float preTime = BlackBoard.Instance.GetGroundTime().SecondAttackPreTime;
        float runTime = BlackBoard.Instance.GetGroundTime().SecondAttackRunTime;
        float afterTime = BlackBoard.Instance.GetGroundTime().SecondAttackAfterTime;

        BlackBoard.Instance.IsSecondAttacking = true;
        BlackBoard.Instance.IsLeftPowAttacking = true;

        CoroutineManager.DoCoroutine(LefrPowAttackCor(preTime, runTime ,afterTime));
        base.OnStart();
    }

    public override bool Run()
    {

        return false;
    }

    public override void OnEnd()
    {
        BlackBoard.Instance.IsSecondAttacking = false;
        BlackBoard.Instance.IsSecondAttack = false;
        BlackBoard.Instance.IsGroundAttacking = false;

        WeakPointManager.Instance.CurrentPatternCount++;

        Debug.Log(this.gameObject.name + " : OnEnd");
        base.OnEnd();
    }

    IEnumerator LefrPowAttackCor(float preTime, float runTime ,float afterTime)
    {

        //선딜
        ParticleManager.Instance.PoolParticleEffectOn("LeftPow");
        DragonAniManager.SwicthAnimation("LeftPow_Atk_Pre");
        yield return new WaitForSeconds(preTime);

        //런 애니메이션
        DragonAniManager.SwicthAnimation("LeftPow_Atk_Run");
        yield return new WaitForSeconds(runTime);

        //후딜
        DragonAniManager.SwicthAnimation("LeftPow_Atk_After");
        yield return new WaitForSeconds(afterTime);
        ParticleManager.Instance.PoolParticleEffectOff("LeftPow");

        BlackBoard.Instance.IsLeftPowAttacking = false;

    }


}
