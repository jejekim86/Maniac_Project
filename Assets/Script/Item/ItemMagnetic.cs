using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagnetic : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float range = 5f;

    private void Update()
    {
        // �÷��̾�� ���� ������ ��ġ�� ������� �Ÿ� ���
        Vector3 relativePos = target.position - transform.position;

        // �÷��̾�� ���ϴ� ���� ���
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;

        // �÷��̾���� �Ÿ��� ���� ���� ���� ���� ���� �̵�
        if (relativePos.magnitude <= range)
        {
            // �÷��̾�� �ε巴�� �̵�
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}