using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReload : MonoBehaviour
{
    private float coolTime = 5.0f;
    private float currentTime = 0.0f;

    private void Update()
    {
        if (currentTime >= 0) currentTime -= Time.deltaTime; 
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentTime > 0) return;
        if(other.gameObject.tag == "Gun")
        {
            other.gameObject.GetComponent<Gun>().Reload();
            SoundManager.Instance.PlayAudio("Reload", transform.position, AudioPlayType.SOUND3D);
            currentTime = coolTime;
        }
    }

}
