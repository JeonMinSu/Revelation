using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_IceBringUp_Pattern : ActionTask
{
    public override bool Run()
    {
        Debug.Log("IceBringUp_Action");
        return false;
    }

    IEnumerator DragonIceBringUpStart()
    {
        yield return CoroutineManager.EndOfFrame;
    }



}
