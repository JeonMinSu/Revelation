using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_Howling_Attack : ActionTask
{
    public override bool Run()
    {
        bool IsRoarAttacking = BlackBoard.Instance.IsRoarAttacking;

        if (!IsRoarAttacking)
        {
            float preTime = BlackBoard.Instance.GetGroundTime().PreRoarTime;
            float afterTime = BlackBoard.Instance.GetGroundTime().AfterRoarTime;

            CoroutineManager.DoCoroutine(HowlingAttackCor(preTime, afterTime));

        }

        return false;
    }

    IEnumerator HowlingAttackCor(float preTime, float afterTime)
    {
        Transform Dragon = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        Vector3 DragonPos = UtilityManager.Instance.DragonPosition();
        Vector3 PlayerPos = UtilityManager.Instance.PlayerPosition();

        DragonPos.y = 0.0f;
        PlayerPos.y = 0.0f;

        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsRoarAttacking = true;

        float runTime = BlackBoard.Instance.GetGroundTime().RunRoarTime;

        Transform mouth = BlackBoard.Instance.DragonMouth;

        Vector3 forward = (PlayerPos - DragonPos).normalized;

        while (Vector3.Dot(Dragon.forward, forward) < 0.99f)
        {
            Dragon.rotation =
                Quaternion.Slerp(
                    Dragon.rotation,
                    Quaternion.LookRotation(forward),
                    0.1f
                    );

            yield return CoroutineManager.FiexdUpdate;
        }

        //선딜
        DragonAniManager.SwicthAnimation("Howling_Atk_Pre");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        //런 타임
        DragonAniManager.SwicthAnimation("Howling_Atk_Run");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(runTime));

        //후딜 
        DragonAniManager.SwicthAnimation("Howling_Atk_After");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        BlackBoard.Instance.IsRoarAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;

        float RushDistance = BlackBoard.Instance.RushDistance;

        BlackBoard.Instance.GetGroundTime().CurWalkTime = 0.0f;
        BlackBoard.Instance.IsWalk = 
            !UtilityManager.DistanceCalc(Dragon, Player, RushDistance);

    }
}
