using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData w_data;
    [SerializeField] Bullet bullet;
    [SerializeField] Transform fireTr;
    [SerializeField] Collider attackRange;

    float timeCount;
    public float reloadT = 1.0f; // 임시 값 추후에 w_data.reloadTime 으로 교체

    private void Start()
    {
        timeCount = 100;
        if (attackRange != null)
            attackRange.enabled = false;
    }

    private void Update()
    {
        timeCount += Time.deltaTime;
    }

    public void SetData()
    {
        //TODO DBDATA가져와야함
    }

    public void LongRangeAttack()
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

    }
    public bool MeleeAttack()
    {
        if (timeCount >= reloadT)
        {
            StartCoroutine(MeleeRangeCheck());  
            timeCount = 0;
            return true;
        }
        return false;
    }

    IEnumerator MeleeRangeCheck()
    {
        attackRange.enabled = true;
        yield return new WaitForSeconds(0.5f); // 공격 지속 시간
        attackRange.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 근접 공격 적중 시
        if (other.CompareTag("Enemy"))
        {

        }
    }


    public IEnumerator Fire()
    {
        Instantiate(bullet);
        yield return new WaitForSeconds(1f);
        //yield return new WaitForSeconds(w_data.reloadTime);
    }
}