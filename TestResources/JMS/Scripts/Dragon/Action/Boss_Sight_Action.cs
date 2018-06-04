using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sight_Action : ActionTask
{
    public override bool Run()
    {
        Transform DragonHead = BlackBoard.Instance.DragonHead;

        Vector3 DragonHeadPos = DragonHead.position;
        Vector3 PlayerPos = UtilityManager.Instance.PlayerPosition();

        Vector3 toTarget = (PlayerPos - DragonHeadPos).normalized;

        DragonHeadPos.y = 0.0f;
        PlayerPos.y = 0.0f;

        float dot = Vector3.Dot(DragonHead.forward, toTarget);


        if (dot >= Mathf.Cos(Mathf.Deg2Rad * 180.0f * 0.5f))
        {

            float x = Mathf.Acos(dot) * Mathf.Rad2Deg;

            //Vector3 cross = Vector3.Cross(DragonHead.forward, toTarget);
            //float Result = Vector3.Dot(cross, Vector3.up);
            //if (Result >= 0)
            //{
            //    Debug.Log("left");
            //}
            //else
            //{
            //    Debug.Log("right");
            //}

        }

        return false;
    }
}
