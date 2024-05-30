using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeWeapon : Weapon
{
    [SerializeField] Bullet bullet;
    [SerializeField] Transform fireTr;
    public override bool Attack()
    {
        //if (timeCount >= w_data.reloadTime)
        if (timeCount >= reloadT)
        {
            Bullet newBullet;
            PoolManager.instance.bulletPool.GetObject(out newBullet);
            newBullet.transform.position = fireTr.transform.position;
            newBullet.transform.rotation = fireTr.rotation;

            //Instantiate(bullet, fireTr.position, fireTr.rotation);
            timeCount = 0;
        }
        return true;
    }

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
}
