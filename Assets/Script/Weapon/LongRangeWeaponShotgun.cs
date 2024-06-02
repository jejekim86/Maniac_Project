using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
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
        Quaternion startAngle = fireTr.rotation * Quaternion.Euler(0, -15, 0);
        Quaternion endAngle = fireTr.rotation * Quaternion.Euler(0, 15, 0);

        ShootBulletJob shootBulletJob;

        var rotation = new NativeArray<Quaternion>(numberBulletsFire, Allocator.TempJob);
        shootBulletJob.startAngle = startAngle;
        shootBulletJob.endAngle = endAngle;
        shootBulletJob.numberBulletsFire = numberBulletsFire;
        shootBulletJob.rot = rotation;

        JobHandle jobHandle = shootBulletJob.Schedule(numberBulletsFire, numberBulletsFire / 3);

        jobHandle.Complete();

        Bullet newBullet;
        for (int i = 0; i < numberBulletsFire; i++)
        {
            PoolManager.instance.bulletPool.GetObject(out newBullet);
            newBullet.transform.position = fireTr.position;
            newBullet.transform.rotation = rotation[i];
        }

        timeCount = 0;
        return true;
    }

    struct ShootBulletJob : IJobParallelFor
    {
        public Quaternion startAngle;
        public Quaternion endAngle;
        public int numberBulletsFire;

        public NativeArray<Quaternion> rot;

        public void Execute(int index)
        {
            Quaternion rotation = Quaternion.Lerp(startAngle, endAngle, (float)1 / numberBulletsFire * index);
            rot[index] = rotation;
        }
    }
}
