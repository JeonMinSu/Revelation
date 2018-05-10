using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_HomingBullet_Pattern : ActionTask
{

    public override bool Run()
    {
        bool IsHoveringAct = BlackBoard.Instance.IsHoveringPatternAct;

        float preTime = BlackBoard.Instance.GetFlyingTime().PreMissileTime;
        float afterTime = BlackBoard.Instance.GetFlyingTime().AfterMissileTime;

        if (!IsHoveringAct)
            CoroutineManager.DoCoroutine(HomingBulletShot(preTime, afterTime));

        Debug.Log("HomingBulletShot_Pattern");

        return false;
    }

    IEnumerator HomingBulletShot(float preTime, float afterTime)
    {
        Transform Mouth = BlackBoard.Instance.DragonMouth;
        BlackBoard.Instance.IsHoveringPatternAct = true;

        //용 유도탄 선딜 애니메이션 넣는 곳
        yield return new WaitForSeconds(preTime);

        //용 유도탄 실행 애니메이션 넣는 곳
        /*
        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward + Mouth.right * 5 + Vector3.up * 1).normalized);//우
        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward - Mouth.right * 5 + Vector3.up * 1).normalized);//좌
            
        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward + Mouth.right * 1.5f - Vector3.up).normalized);//아 우
        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward - Mouth.right * 1.5f - Vector3.up).normalized);//아 좌

        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward + Mouth.right * 1.0f + Vector3.up * 1).normalized);//위 우
        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward - Mouth.right * 1.0f + Vector3.up * 1).normalized);//위 좌

        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward + Mouth.right * 0.5f - Vector3.up).normalized);//아 우
        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward - Mouth.right * 0.5f - Vector3.up).normalized);//아 좌

        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward + Vector3.up * 2).normalized);//위
        BlackBoard.Instance.BulletManager.DragonHomingBulletFire(Mouth.position, (Mouth.forward - Vector3.up).normalized);//아래
        */
        yield return new WaitForSeconds(1.5f);

        //용 유도탄 후딜 애니메이션 넣는 곳
        yield return new WaitForSeconds(afterTime);
        BlackBoard.Instance.IsHoveringPatternAct = false;
        BlackBoard.Instance.IsFlying = true;
        //BlackBoard.Instance.IsHovering = false;
    }




}