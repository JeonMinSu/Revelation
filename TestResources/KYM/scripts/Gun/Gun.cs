using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(GunAnimation))]
public class Gun : MonoBehaviour {

    [SerializeField] private int maxBullet;
    [SerializeField] private float fireDelay;
    [SerializeField] private string fireSound;
    [SerializeField] private Transform firePos;
    [SerializeField] TextMesh bulletUI;

    private int currentBullet;
    private float fireCoolTime;

    GunAnimation gunAni;

    // Use this for initialization
    void Start ()
    {
        currentBullet = maxBullet;
        bulletUI.text = currentBullet.ToString();
        fireCoolTime = 0.0f;
        gunAni = GetComponent<GunAnimation>();
	}
	
	// Update is called once per  frame
	void Update ()
    {
	    if(fireCoolTime > 0.0f)
            fireCoolTime -= Time.unscaledDeltaTime;

	}

    public void Fire()
    {
        if (firePos == null)
        {
            Debug.LogWarning("Not FirePos");
            return;
        }
        if (fireCoolTime > 0.0f)
        {
            return;
        }
        if (currentBullet <= 0)
        {
            return;
        }

        BulletManager.Instance.CreatePlayerBaseBullet(firePos);
        fireCoolTime = fireDelay;
        currentBullet -= 1;
        bulletUI.text = currentBullet.ToString();
        if(gunAni != null)
        {
            gunAni.MagazieTurn(0.1f, maxBullet);
            gunAni.ShakeGun(fireDelay * 0.9f, 10.0f, 0.05f);
            gunAni.FireParticle(firePos.position + firePos.forward * 0.1f);
        }

    }

    public void Reload()
    {
        currentBullet = maxBullet;
        bulletUI.text = currentBullet.ToString();
    }
}