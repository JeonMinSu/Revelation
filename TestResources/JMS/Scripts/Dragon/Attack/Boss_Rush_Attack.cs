using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Rush_Attack : ActionTask
{

    public override bool Run()
    {
        bool IsRushAttacking = BlackBoard.Instance.IsRushAttacking;

        Debug.Log(IsRushAttacking);

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
        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsRushAttacking = true;

        float curTime  = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunRushTime;

        Vector3 forward = (Player.position - Boss.position).normalized;

        float Distance = BlackBoard.Instance.RushMoveDistance;

        while (!Quaternion.Equals(Boss.rotation, Quaternion.LookRotation(forward)))
        {
            Boss.rotation =
                Quaternion.RotateTowards(
                    Boss.rotation,
                    Quaternion.LookRotation(forward),
                    180.0f * Time.deltaTime
                    );

            yield return CoroutineManager.FiexdUpdate;
        }

        //선딜 애니메이션
        DragonAniManager.SwicthAnimation("Rush_Atk_Pre");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        DragonAniManager.SwicthAnimation("Rush_Atk_Run");
        while (curTime < runTime)
        {
            Boss.Translate(Vector3.forward * Distance * Time.deltaTime);
            Debug.Log("Rush_Attack_Cor");
            curTime += Time.fixedDeltaTime;
            yield return CoroutineManager.FiexdUpdate;
        }


        //후딜 애니메이션
        DragonAniManager.SwicthAnimation("Rush_Atk_After");
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        float SecondAttackDistance = BlackBoard.Instance.SecondAttackDistance;

        BlackBoard.Instance.IsSecondAttack = UtilityManager.DistanceCalc(Boss, Player, SecondAttackDistance);
        BlackBoard.Instance.IsGroundAttacking = (BlackBoard.Instance.IsSecondAttack) ? true : false;
        BlackBoard.Instance.IsRushAttacking = false;

    }

}
