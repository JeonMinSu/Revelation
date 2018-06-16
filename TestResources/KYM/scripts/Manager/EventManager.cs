using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonController;


public class EventManager : Singleton<EventManager>
{
    public delegate bool WeakPointHitFunc(Collider col, out float damage);
    public WeakPointHitFunc IsWeakPointHit;

    public void DragonHit(Collider col, float damage)
    {
        if (col.tag == "WeakPoint")
        {
            if (IsWeakPointHit != null)
            {
                float WeakPointDamage;
                bool IsHit = IsWeakPointHit(col, out WeakPointDamage);
                if (IsHit)
                {
                    damage = WeakPointDamage;
                    BlackBoard.Instance.IsNearHowlingAttacking = true;
                }
            }
        }
        DragonManager.Instance.Hit(damage);
    }

}