using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    [SerializeField] private GameObject bulletBasePlayer;
    [SerializeField] private GameObject bulletBaseDragon;
    [SerializeField] private GameObject bulletHomingDragon;

    public void CreateDragonBaseBullet(Vector3 _position, Vector3 _dir)
    {
        Quaternion rot = Quaternion.LookRotation(_dir, Vector3.up);
        Instantiate(bulletBaseDragon, _position, rot);
    }
    public void CreateDragonBaseBullet(Transform _firePos)
    {
        Instantiate(bulletBaseDragon, _firePos);
    }

    public void CreateDragonHomingBullet(Vector3 _position, Vector3 _dir)
    {
        Quaternion rot = Quaternion.LookRotation(_dir, Vector3.up);
        Instantiate(bulletHomingDragon, _position, rot);
    }

    public void CreateDragonHomingBullet(Transform _firepos)
    {
        Instantiate(bulletHomingDragon, _firepos);
    }

    public void CreatePlayerBaseBullet(Vector3 _position, Vector3 _dir)
    {
        Quaternion rot = Quaternion.LookRotation(_dir, Vector3.up);
        Instantiate(bulletBasePlayer, _position, rot);
    }

    public void CreatePlayerBaseBullet(Transform _firepos)
    {
        Instantiate(bulletBasePlayer, _firepos);
    }

}
