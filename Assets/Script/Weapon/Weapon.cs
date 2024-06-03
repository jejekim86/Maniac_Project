using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected WeaponData w_data;

    protected float timeCount;
    public float reloadT = 1.0f; // �ӽ� �� ���Ŀ� w_data.reloadTime ���� ��ü

    virtual protected void Start()
    {
        timeCount = 100;
    }

    virtual protected void Update()
    {
        timeCount += Time.deltaTime;
    }

    virtual public void SetData()
    {
        //TODO DBDATA�����;���
    }

    virtual public bool Attack()
    {
        return false;
    }
}