using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_OverLap_Pattern : ActionTask {

    public override bool Run()
    {
        float preTime = BlackBoard.Instance.GetStageTime().PreOverLapTime;
        float afterTime = BlackBoard.Instance.GetStageTime().AfterOverLapTime;

        bool IsStageAct = BlackBoard.Instance.IsStageAct;

        if (!IsStageAct)
            CoroutineManager.DoCoroutine(OverLapCor(preTime, afterTime));
        
        return false;
    } 

    IEnumerator OverLapCor(float preTime, float afterTime)
    {
        float Curtime = 0;
        float RunTime = BlackBoard.Instance.GetStageTime().OverLapRunTime;
        
        BlackBoard.Instance.IsStageAct = true;

        DragonManager.Instance.SwicthAnimation("Idle");
        yield return new WaitForSeconds(preTime);

        while (Curtime < RunTime)
        {
            Debug.Log("OverLapRunning");
            Curtime += Time.fixedDeltaTime;
            yield return CoroutineManager.EndOfFrame;
        }

        yield return new WaitForSeconds(afterTime);
        BlackBoard.Instance.GetStageTime().InitTime();
        BlackBoard.Instance.IsStageAct = false;

    }

}
