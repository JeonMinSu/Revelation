using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Rush_Pattern : ActionTask {

    public override bool Run()
    {

        Transform Dragon = DragonManager.Instance.transform;
        Transform Player = DragonManager.Instance.Player;

        float preTime = BlackBoard.Instance.GetStageTime().PreRushTime;
        float afterTime = BlackBoard.Instance.GetStageTime().AfterRushTime;

        bool IsGround = BlackBoard.Instance.IsGround;
        bool IsStageAct = BlackBoard.Instance.IsGroundPatternAct;

        if (!IsStageAct)
           CoroutineManager.DoCoroutine(DragonRushStart(preTime, afterTime));

        Debug.Log("Rush Running");

        return false;

    }
    IEnumerator DragonRushStart(float _preTime, float _afterTime)
    {
        float Curtime = 0;
        float RunTime = BlackBoard.Instance.GetStageTime().RushRunTime;

        BlackBoard.Instance.IsGroundPatternAct = true;

        DragonManager.Instance.SwicthAnimation("Idle");
        yield return new WaitForSeconds(_preTime);
        while (Curtime < RunTime)
        {
            Debug.Log("RushRunning");
            Curtime += Time.fixedDeltaTime;
            yield return CoroutineManager.EndOfFrame;
        }

        yield return new WaitForSeconds(_afterTime);
        BlackBoard.Instance.GetStageTime().InitTime();
        BlackBoard.Instance.IsGroundPatternAct = false;

    }



}
