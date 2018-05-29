using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunAnimation))]
public class Gun : MonoBehaviour {

    [SerializeField] private int maxBullet;
    [SerializeField] private float fireDelay;
    [SerializeField] private string fireSound;
    [SerializeField] private Transform firePos;

    private int currentBullet;
    private float fireCoolTime;

    GunAnimation gunAni;

    // Use this for initialization
    void Start ()
    {
        currentBullet = maxBullet;
        fireCoolTime = 0.0f;
        gunAni = GetComponent<GunAnimation>();
	}
	
	// Update is called once per  frame
	void Update ()
    {
	    if(fireCoolTime > 0.0f)
            fireCoolTime -= Time.deltaTime;

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
        gunAni.MagazieTurn(0.1f,maxBullet);
    }

    public void Reload()
    {
        currentBullet = maxBullet;
    }

}