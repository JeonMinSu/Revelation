using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Landing_Action : ActionTask
{
    public override bool Run()
    {

        int MoveIndex = (int)MoveManagers.Landing;

        float CurHP = DragonManager.Stat.HP;

        bool IsLanding = BlackBoard.Instance.IsLanding;
        bool IsLandingReady = BlackBoard.Instance.IsMoveReady(MoveIndex);
        bool IsLandEnd = BlackBoard.Instance.GetNodeManager(MoveIndex).IsMoveEnd;

        if (IsLanding && !IsLandEnd)
        {
            DragonManager.Instance.SwicthAnimation("Landing");
            if (!IsLandingReady)
                BlackBoard.Instance.MovementReady(MoveIndex);
            else
            {
                if (!BlackBoard.Instance.IsLandingAct)
                    CoroutineManager.DoCoroutine(LandingStartCor(MoveIndex));
                BlackBoard.Instance.IsStage = true;
            }
            return false;
        }
        return true;
    }

    IEnumerator LandingStartCor(int Index)
    {
        BlackBoard.Instance.IsLandingAct = true;
        BlackBoard.Instance.Clocks.InitFlyingTime();

        while (!BlackBoard.Instance.GetNodeManager(Index).IsMoveEnd)
        {
            BlackBoard.Instance.FlyingMovement(Index);
            yield return CoroutineManager.EndOfFrame;
        }
        DragonManager.Stat.ChangedHP = DragonManager.Stat.HP;
        BlackBoard.Instance.IsLanding = false;
        BlackBoard.Instance.IsLandingAct = false;
        BlackBoard.Instance.IsHovering = false;
        BlackBoard.Instance.IsFlying = false;
        BlackBoard.Instance.GetNodeManager(Index).IsMoveEnd = false;

    }

}
