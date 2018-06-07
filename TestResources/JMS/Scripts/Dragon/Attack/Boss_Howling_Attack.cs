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

        DragonAniManager.SwicthAnimation("Walk");
        while (Vector3.Dot(Dragon.forward, forward) < 0.99f)
        {
            Dragon.rotation =
                Quaternion.Slerp(
                    Dragon.rotation,
                    Quaternion.LookRotation(forward),
                    0.05f
                    );

            yield return CoroutineManager.FiexdUpdate;
        }

        //선딜
        DragonManager.Instance.HowlingEffect.SetActive(true);
        DragonAniManager.SwicthAnimation("Howling_Atk_Pre");

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        //런 타임
        DragonAniManager.SwicthAnimation("Howling_Atk_Run");
        FMODSoundManager.Instance.PlayBossHowling(Dragon.transform.position);

        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward + Vector3.up * 3).normalized);
        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward + mouth.right * 10.0f + Vector3.up * 3).normalized);
        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward + mouth.right * 5.0f + Vector3.up * 4).normalized);

        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward - mouth.right * 10.0f + Vector3.up * 3).normalized);
        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward - mouth.right * 5.0f + Vector3.up * 4).normalized);

        UtilityManager.Instance.ShakePlayerHowling();

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(runTime));

        //후딜 
        DragonAniManager.SwicthAnimation("Howling_Atk_After");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));
        DragonManager.Instance.HowlingEffect.SetActive(false);

        DragonAniManager.SwicthAnimation("Idle");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(1.5f));

        BlackBoard.Instance.IsRoarAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;

        float RushDistance = BlackBoard.Instance.RushDistance;

        float Distance = BlackBoard.Instance.RushDistance;

        BlackBoard.Instance.WalkDistance = Distance;

        BlackBoard.Instance.GetGroundTime().CurWalkTime = 0.0f;
        BlackBoard.Instance.IsWalk = 
            !UtilityManager.DistanceCalc(Dragon, Player, RushDistance);

    }
}
