using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    static public PoolManager instance { get; private set; }

    public ObjectPool<Bullet> bulletPool { get; private set; }

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        bulletPool.Initialize();
    }
}
