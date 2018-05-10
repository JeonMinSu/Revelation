using DragonController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Breath_Pattern : ActionTask
{

    public override bool Run()
    {
        bool HoveringAct = BlackBoard.Instance.HoveringAct;

        float preTime = BlackBoard.Instance.GetFlyingTime().PreBreathTime;
        float afterTime = BlackBoard.Instance.GetFlyingTime().AfterBreathTime;

        if (!HoveringAct)
            CoroutineManager.DoCoroutine(BreathShot(preTime, afterTime));

        Debug.Log("Berath_Pattern");

        return false;
    }

    IEnumerator BreathShot(float preTime, float afterTime)
    {
        //Transform Player = BlackBoard.Instance.Manager.Player;
        //Transform Dragon = BlackBoard.Instance.Manager.transform;

        Transform Player = DragonManager.Instance.Player;
        Transform Dragon = DragonManager.Instance.transform;

        Transform Mouth = BlackBoard.Instance.DragonMouth;
        BlackBoard.Instance.HoveringAct = true;

        Vector3 forward = (Player.position - Mouth.position).normalized;

        float RunTime = BlackBoard.Instance.GetFlyingTime().RunBreathTime;

        //용 브레스 선딜 애니메이션 넣는 곳
        yield return new WaitForSeconds(preTime);


        //용 브레스 실행 애니메이션 넣는 곳
        //BlackBoard.Instance.Manager.Ani.ResetTrigger("Hovering");
        //BlackBoard.Instance.Manager.Ani.SetTrigger("Breath");
        DragonManager.Instance.SwicthAnimation("Breath");

        //BlackBoard.Instance.BulletManager.DragonBreathOn(Mouth.position, forward);
        //BlackBoard.Instance.BulletManager.DragonBreathOn(Mouth);
        yield return new WaitForSeconds(RunTime);
        //BlackBoard.Instance.BulletManager.DragonBreathOff();

        //용 브레스 후딜 애니메이션 넣는 곳
        yield return new WaitForSeconds(afterTime);
        BlackBoard.Instance.HoveringAct = false;
        BlackBoard.Instance.IsFlying = true;
        //BlackBoard.Instance.IsHovering = false;
    }
}
