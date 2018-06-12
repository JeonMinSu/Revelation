using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;

public class Boss_HowlingAttack_Decorator : DecoratorTask
{

    public override bool Run()
    {
        float Hp = DragonManager.Stat.HP;
        float MaxHp = DragonManager.Stat.MaxHP;

        float DamageReceiveHpPercent = DragonManager.Stat.DamageReceiveHpPercent;
        float SaveTakeDamage = DragonManager.Stat.SaveTakeDamage;

        bool IsHowling = (MaxHp * DamageReceiveHpPercent <= SaveTakeDamage);

        bool IsHowlingAttacking = BlackBoard.Instance.IsHowlingAttacking;
        bool IsGroundAttacking = BlackBoard.Instance.IsGroundAttacking;

        if ((IsHowling && !IsGroundAttacking) || IsHowlingAttacking)
        {
            return ChildNode.Run();
        }
        return true;
    }

}
