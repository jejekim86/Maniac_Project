using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    // ������Ʈ Ǯ ����
    public ObjectPool<MonoBehaviour> objectPool;

    // ���� ��ġ�� ���� ���� ����
    [SerializeField] private Vector3 spawnAreaMin;
    [SerializeField] private Vector3 spawnAreaMax;

    // ���� ����
    [SerializeField] private float spawnInterval = 2f;

    // Start�� ��ũ��Ʈ ���� �� ù ������ ���� ȣ��˴ϴ�.
    void Start()
    {
        // ������Ʈ Ǯ �ʱ�ȭ
        objectPool.Initialize();

        // �ֱ������� ������Ʈ�� �����ϵ��� ����
        InvokeRepeating(nameof(SpawnRandomObject), 0f, spawnInterval);
    }

    // ������Ʈ�� ���� ��ġ�� �����ϴ� �޼���
    void SpawnRandomObject()
    {
        if (objectPool.GetObject(out MonoBehaviour item))
        {
            // ���ǵ� ���� ������ ��ġ�� ����ȭ
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            // ������Ʈ�� ��ġ ����
            item.transform.position = randomPosition;

            // ������Ʈ Ȱ��ȭ
            item.gameObject.SetActive(true);
        }
    }

    // ���� ������ ������ �ð�ȭ
    void OnDrawGizmos()
    {
        // ����� ���� ����
        Gizmos.color = Color.red;

        // spawnAreaMin�� spawnAreaMax�� ����Ͽ� ���� �ڽ��� �׸�
        Vector3 center = (spawnAreaMin + spawnAreaMax) * 0.5f;
        Vector3 size = spawnAreaMax - spawnAreaMin;
        Gizmos.DrawWireCube(center, size);
    }
}
