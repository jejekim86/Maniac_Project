using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponData w_data;
    [SerializeField] Bullet bullet;
    [SerializeField] Transform fireTr;

    public void SetData()
    {
        //TODO DBDATA가져와야함
    }

    public void LongRangeAttack(Transform targettr)
    {
        Instantiate(bullet, fireTr.position, targettr.rotation);
        //bullet.SetData(fireTr.position);


    }
    public void ShortRangeAttack()
    {

    }

    public IEnumerator Fire()
    {
        Instantiate(bullet);
        yield return new WaitForSeconds(1f);
        //yield return new WaitForSeconds(w_data.reloadTime);
    }
}
