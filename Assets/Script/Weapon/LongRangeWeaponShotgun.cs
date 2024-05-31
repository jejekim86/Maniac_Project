using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeWeaponShotgun : LongRangeWeapon
{
    [SerializeField] private int numberBulletsFire;
    Bullet newBullet;
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

            //float lerpT = 1.0f / numberBulletsFire * i;
            //PoolManager.instance.bulletPool.GetObject(out newBullet);
            //Quaternion rotation = Quaternion.Lerp(fireTr.rotation * Quaternion.Euler(0, -20, 0),
            //    fireTr.rotation * Quaternion.Euler(0, 20, 0), lerpT);
            //newBullet.transform.position = fireTr.transform.position;
            //newBullet.transform.rotation = rotation;
        }
        StartCoroutine(FireBullet());
        timeCount = 0;
        return true;
    }

    IEnumerator FireBullet()
    {
        int num = numberBulletsFire;
        while (num >= 0)
        {
            if (num > 500)
            {
                for (int i = 0; i < 500; i++)
                {
                    float lerpT = 1.0f / num * i;
                    PoolManager.instance.bulletPool.GetObject(out newBullet);
                    Quaternion rotation = Quaternion.Lerp(fireTr.rotation * Quaternion.Euler(0, -20, 0),
                        fireTr.rotation * Quaternion.Euler(0, 20, 0), lerpT);
                    newBullet.transform.position = fireTr.transform.position;
                    newBullet.transform.rotation = rotation;
                }
                num -= 500;
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    float lerpT = 1.0f / num * i;
                    PoolManager.instance.bulletPool.GetObject(out newBullet);
                    Quaternion rotation = Quaternion.Lerp(fireTr.rotation * Quaternion.Euler(0, -20, 0),
                        fireTr.rotation * Quaternion.Euler(0, 20, 0), lerpT);
                    newBullet.transform.position = fireTr.transform.position;
                    newBullet.transform.rotation = rotation;
                }
                num = 0;
            }
            yield return null;
        }
    }
}
