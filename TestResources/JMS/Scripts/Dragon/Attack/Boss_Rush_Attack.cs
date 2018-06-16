using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rush_Attack : ActionTask
{

    public override bool Run()
    {
        bool IsRushAttacking = BlackBoard.Instance.IsRushAttacking;

        if (!IsRushAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreRushTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterRushTime;

            CoroutineManager.DoCoroutine(RushAttackCor(preTime, afterTime));
        }

        return false;
    }

    IEnumerator RushAttackCor(float preTime, float afterTime)
    {
        
        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsRushAttacking = true;

        float runTime = BlackBoard.Instance.GetGroundTime().RunRushTime;

        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        Vector3 DragonPos = Dragon.position;
        Vector3 PlayerPos = Player.position;

        DragonPos.y = 0.0f;
        PlayerPos.y = 0.0f;

        Vector3 forward = (PlayerPos - DragonPos).normalized;

        float Distance = BlackBoard.Instance.RushMoveDistance;

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
        BlackBoard.Instance.IsGroundAttacking = (BlackBoard.Instance.IsSecondAttack) ? true : false;
        BlackBoard.Instance.IsRushAttacking = false;
        
        WeakPointManager.Instance.CurrentPatternCount++;

    }

}
