using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] private int maxBullet;
    [SerializeField] private float fireDelay;
    [SerializeField] private float reloadDelay;
    [SerializeField] private string fireSound;
    [SerializeField] private Transform firePos;

    private int currentBullet;
    private float fireCoolTime;
    private float reloadCoolTime;

    // Use this for initialization
    void Start ()
    {
        currentBullet = maxBullet;
        fireCoolTime = 0.0f;
        reloadCoolTime = 0.0f;
	}
	
	// Update is called once per  frame
	void Update ()
    {
	    if(fireCoolTime > 0.0f)
            fireCoolTime -= Time.deltaTime;

        if (reloadCoolTime > 0.0f)
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
        if(reloadCoolTime > 0.0f)
        {
            return;
        }
        if (currentBullet <= 0)
        {
            Reload();
            return;
        }

        BulletManager.Instance.CreatePlayerBaseBullet(firePos);
        fireCoolTime = fireDelay;
        currentBullet -= 1;
    }

    void Reload()
    {
        reloadCoolTime = reloadDelay;
        currentBullet = maxBullet;
    }

}