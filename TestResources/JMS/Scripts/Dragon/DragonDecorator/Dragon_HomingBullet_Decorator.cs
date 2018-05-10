using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_HomingBullet_Decorator : DecoratorTask
{

    public override bool Run()
    {
        bool IsHovering = BlackBoard.Instance.IsHovering;

        float PlayerHP = BlackBoard.Instance.CurPlayerHP;
        float PlayerMaxHp = BlackBoard.Instance.PlayerMaxHP;

        int MaxCrystal = BlackBoard.Instance.MissileCrystalNum;
        int CurCrystal = BlackBoard.Instance.CurIceCrystalNum;


        if (IsHovering &&
            PlayerHP >= PlayerMaxHp * 0.5f &&
            CurCrystal < MaxCrystal)
        {
            Debug.Log("HomingBullet");
            return ChildNode.Run();
        }
        return true;
    }


}
