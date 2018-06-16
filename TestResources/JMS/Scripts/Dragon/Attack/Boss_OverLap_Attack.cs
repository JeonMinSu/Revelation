using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_OverLap_Attack : ActionTask
{
    public override bool Run()
    {
        bool IsOverLapAttacking = BlackBoard.Instance.IsOverLapAttacking;

        if (!IsOverLapAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreOverLapTime;
            float afterTIme = BlackBoard.Instance.GetGroundTime().AfterOverLapTime;

            CoroutineManager.DoCoroutine(OverLapAttackCor(preTime, afterTIme)); 

        }

        return false;
    }

    IEnumerator OverLapAttackCor(float preTime, float afterTime)
    {
        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsOverLapAttacking = true;

        float runTime = BlackBoard.Instance.GetGroundTime().RunOverLapTime;

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        Vector3 DragonPos = Dragon.position;
        Vector3 PlayerPos = Player.position;

        DragonPos.y = 0.0f;
        PlayerPos.y = 0.0f;

        Vector3 forward = (PlayerPos - DragonPos).normalized;

        while (Vector3.Dot(Dragon.forward, forward) < 0.99f)
        {
            Dragon.rotation = Quaternion.Slerp(Dragon.rotation, Quaternion.LookRotation(forward), 0.1f);
            yield return CoroutineManager.FiexdUpdate;
        }

        //선딜 애니메이션
        DragonAniManager.SwicthAnimation("Rush_Atk_Pre");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        //실행 애니메이션
        DragonAniManager.SwicthAnimation("Rush_Atk_Run");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(runTime));

        //후딜 애니메이션
        DragonAniManager.SwicthAnimation("Rush_Atk_After");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        float SecondAttackDistance = BlackBoard.Instance.SecondAttackDistance;

        BlackBoard.Instance.IsSecondAttack = UtilityManager.DistanceCalc(Dragon, Player, SecondAttackDistance);
        BlackBoard.Instance.IsOverLapAttack = false;
        BlackBoard.Instance.IsOverLapAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = (BlackBoard.Instance.IsSecondAttack) ? true : false;

        WeakPointManager.Instance.CurrentPatternCount++;
    }

}
