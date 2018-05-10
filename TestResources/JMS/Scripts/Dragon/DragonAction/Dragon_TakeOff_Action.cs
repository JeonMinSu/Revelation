using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_TakeOff_Action : ActionTask {

    public override bool Run()
    {

        int MoveIndex = (int)MoveManagers.TakeOff;

        bool IsTakeOff = BlackBoard.Instance.IsTakeOff;
        bool IsFlyingReady = BlackBoard.Instance.IsMoveReady(MoveIndex);
        bool IsTakeOffEnd = BlackBoard.Instance.GetNodeManager(MoveIndex).IsMoveEnd;

        bool IsTakeOffAct = BlackBoard.Instance.IsTakeOffAct;
        bool IstakeOffReady = BlackBoard.Instance.IsTakeOffReady;

        if (!IsFlyingReady && IstakeOffReady)
        {
            DragonManager.Instance.SwicthAnimation("TakeOff");
            BlackBoard.Instance.MovementReady(MoveIndex);
        }

        else
        {
            if (!IsTakeOffAct && IsFlyingReady)
            { 
                CoroutineManager.DoCoroutine(TakeOffStartCor(MoveIndex));
                BlackBoard.Instance.IsHovering = true;
            }
        }

        return false;
    }

    IEnumerator TakeOffStartCor(int Index)
    {
        BlackBoard.Instance.IsTakeOffAct = true;
        BlackBoard.Instance.Clocks.InitLandTimes();

        while (!BlackBoard.Instance.GetNodeManager(Index).IsMoveEnd)
        {
            BlackBoard.Instance.FlyingMovement(Index);
            yield return CoroutineManager.EndOfFrame;
        }
        DragonManager.Stat.ChangedHP = DragonManager.Stat.HP;
        BlackBoard.Instance.IsTakeOff = false;
        BlackBoard.Instance.IsTakeOffAct = false;
        BlackBoard.Instance.IsStage = false;
        BlackBoard.Instance.IsTakeOffReady = false;
        BlackBoard.Instance.GetNodeManager(Index).IsMoveEnd = false;


    }

}
