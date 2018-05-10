using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Flying_Action : ActionTask
{
    public override bool Run()
    {
        int MoveIndex = (int)MoveManagers.FlyingCircle;

        bool IsFlying = BlackBoard.Instance.IsFlying;
        bool IsFlyingReady = BlackBoard.Instance.IsMoveReady(MoveIndex);
        bool IsFlyingEnd = BlackBoard.Instance.GetNodeManager(MoveIndex).IsMoveEnd;

        if (!IsFlyingReady)
        { 
            BlackBoard.Instance.MovementReady(MoveIndex);
            DragonManager.Instance.SwicthAnimation("Flying");
        }
        else
        { 
            if (!BlackBoard.Instance.FlyingAct)
            {
                BlackBoard.Instance.IsHovering = false;
                CoroutineManager.DoCoroutine(FlyingStartCor(MoveIndex));
            }
        }
        return false;
    }

    IEnumerator FlyingStartCor(int Index)
    {
        float curTime = 0.0f;
        float fireTime = 0.0f;
        float MaxTime = BlackBoard.Instance.GetFlyingTime().FlyTime;

        Transform Player = DragonManager.Instance.Player;
        Transform Dragon = DragonManager.Instance.transform;

        BlackBoard.Instance.FlyingAct = true;

        while (curTime < MaxTime)
        {
            BlackBoard.Instance.FlyingMovement(Index);
            curTime += Time.deltaTime;
            fireTime -= Time.deltaTime;

            Vector3 firePos = Dragon.position + Dragon.up * Random.Range(0,5) * 5;
            if(fireTime <= 0.0f)
            {
                //BlackBoard.Instance.BulletManager.DragonBaseBulletFire(firePos, (
                //    (Player.position + new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f,20.0f))) - firePos).normalized);
                fireTime = 0.15f;
            }
            yield return CoroutineManager.EndOfFrame;
        }
        if (!BlackBoard.Instance.FlyingPatternAct)
            BlackBoard.Instance.HoveringPatternChk();

        BlackBoard.Instance.HoveringPatternChk();
    }

}
