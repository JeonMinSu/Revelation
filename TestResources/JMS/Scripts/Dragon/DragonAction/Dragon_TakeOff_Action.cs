﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_TakeOff_Action : ActionTask
{

    public override bool Run()
    {

        bool IsTakeOffAct = BlackBoard.Instance.IsTakeOffAct;

        if (!IsTakeOffAct)
        {
            float RunTime = 10.0f;
            BlackBoard.Instance.IsTakeOffAct = true;
            CoroutineManager.DoCoroutine(TakeOffAction(RunTime));
        }
        Debug.Log("TakeOff_Action");
        
        return false;
    }

    IEnumerator TakeOffAction(float RunTime)
    {
        float Curtime = 0.0f;

        while (Curtime < RunTime)
        {
            Curtime += Time.deltaTime;
            yield return CoroutineManager.EndOfFrame;
        }
        BlackBoard.Instance.IsTakeOffEnd = true;
        BlackBoard.Instance.IsGround = false;
        BlackBoard.Instance.IsTakeOffAct = false;
    }

}
