using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeWeaponShotgun : LongRangeWeapon
{
    [SerializeField] private int numberBulletsFire;

    public override void SetData()
    {
        base.SetData();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    public override bool Attack()
    {
        if (timeCount < reloadT)
        {
            return false;
        }
        for (int i = 0; i < numberBulletsFire; i++)
        {
            Bullet newBullet;
            PoolManager.instance.bulletPool.GetObject(out newBullet);
            Quaternion rotation = Quaternion.Lerp(transform.rotation * Quaternion.Euler(0, -15, 0),
                transform.rotation * Quaternion.Euler(0, 15, 0), 1 / numberBulletsFire * i);
            newBullet.transform.position = fireTr.transform.position;
            newBullet.transform.rotation = rotation;
        }
        timeCount = 0;
        return true;
    }
}
