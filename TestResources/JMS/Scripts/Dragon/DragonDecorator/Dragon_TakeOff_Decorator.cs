using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_TakeOff_Decorator : DecoratorTask
{
    public override bool Run()
    {

        int MoveIndex = (int)MoveManagers.TakeOff;

        float MaxHP = DragonManager.Stat.MaxHP;
        float CurHP = DragonManager.Stat.HP;      //현재HP
        float TakeOffHP = DragonManager.Stat.TakeOffHP; //날기 위한 HP퍼센트

        float ChangedHP = DragonManager.Stat.ChangedHP;

        bool IsFly = BlackBoard.Instance.IsFlying;
        bool IsStage = BlackBoard.Instance.IsStage;

        bool IsStageAct = BlackBoard.Instance.IsStageAct;
        bool IsLandingAct = BlackBoard.Instance.IsLandingAct;

        bool IsTakeOffEnd = BlackBoard.Instance.GetNodeManager(MoveIndex).IsMoveEnd;

        if (ChangedHP - TakeOffHP >= CurHP && !IsLandingAct &&
            !IsStageAct && IsStage && !IsTakeOffEnd && CurHP != MaxHP)
        {
            Debug.Log("TakeOff");
            DragonManager.Instance.SwicthAnimation("TakeOff");
            BlackBoard.Instance.IsTakeOff = true;

            return ChildNode.Run();
        }
        return true;


    }

}
