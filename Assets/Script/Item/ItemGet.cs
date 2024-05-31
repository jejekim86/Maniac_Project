using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // ������ ������

    public void ItemGet_Gun(GameObject target)
    {        
        // Item �������� ���� ������Ʈ ��ġ�� ����. �⺻ ȸ�� ��(Quaternion.identity) ���
        GameObject newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);

        // ������ ������ ������Ʈ�� �÷��̾� �ڽ����� ����
        newItem.transform.SetParent(gameObject.transform);

        // ������ �������� ��ġ�� �÷��̾� ��ġ�� �������� (Vector3(-0.199000001,1.32799995,0.195999995))���� ����
        newItem.transform.localPosition = new Vector3(-0.199000001f, 1.32799995f, 0.195999995f);

        // ������ �������� �����̼��� Y�� �������� 90�� ȸ������ ����
        newItem.transform.localRotation = Quaternion.Euler(0, 90, 0);

        // �÷��̾� Controller�� �Ҵ�
        Controller controller = target.GetComponent<Controller>();
        if (controller != null )
        {
            controller.SetLongRangeWeapon(newItem.GetComponent<Weapon>());
        }
    }
}