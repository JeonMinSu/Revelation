﻿using System.Collections;
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

        BlackBoard.Instance.IsGroundAttacking = true;
        BlackBoard.Instance.IsRoarAttacking = true;

        float runTime = BlackBoard.Instance.GetGroundTime().RunRoarTime;

        Transform mouth = BlackBoard.Instance.DragonMouth;

        //선딜
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(preTime));

        DragonManager.Instance.HowlingEffect.SetActive(true);

        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward + Vector3.up * 3).normalized);
        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward + mouth.right * 10.0f + Vector3.up * 3).normalized);
        BulletManager.Instance.CreateDragonHomingBullet(mouth.position, (mouth.forward - mouth.right * 10.0f + Vector3.up * 3).normalized);

        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(runTime));

        //후딜 
        yield return CoroutineManager.GetWaitForSeconds(new WaitForSeconds(afterTime));

        DragonManager.Instance.HowlingEffect.SetActive(false);

        BlackBoard.Instance.IsRoarAttacking = false;
        BlackBoard.Instance.IsGroundAttacking = false;


    }


}
