using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        float curTime = 0.0f;
        float runTime = BlackBoard.Instance.GetGroundTime().RunOverLapTime;

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        while (curTime < runTime)
        {

            Debug.Log("OverLapAttack");
            curTime += Time.fixedDeltaTime;
            yield return CoroutineManager.FiexdUpdate;
        }

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        Transform Boss = UtilityManager.Instance.DragonTransform();
        Transform Player = UtilityManager.Instance.PlayerTransform();

        float SecondAttackDistance = BlackBoard.Instance.SecondAttackDistance;

        BlackBoard.Instance.IsSecondAttack = UtilityManager.DistanceCalc(Boss, Player, SecondAttackDistance);
        BlackBoard.Instance.IsOverLapAttack = false;
        BlackBoard.Instance.IsOverLapAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = (BlackBoard.Instance.IsSecondAttack) ? true : false;


    }



}
