using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class FramTest : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10000;

    private Queue<GameObject> objectPool = new Queue<GameObject>();
    private object poolLock = new object();

    void Start()
    {
        ThreadPool.QueueUserWorkItem(InitializePool);
    }

    void InitializePool(object state)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);

            lock (poolLock)
            {
                objectPool.Enqueue(obj);
            }

            // ���� �����忡�� �����ϱ� ������ ���� ��������� �浹�� ����
            if (i % 100 == 0)
            {
                Thread.Sleep(1); // �ӽ÷� ������ �־� ���� �������� ���ϸ� ����
            }
        }
    }
    void Update()
    {
        // ���� �����忡�� Ǯ���� ������Ʈ�� ������ Ȱ��ȭ
        lock (poolLock)
        {
            if (objectPool.Count > 0)
            {
                GameObject obj = objectPool.Dequeue();
                obj.SetActive(true);
                // ������Ʈ�� Ȱ��ȭ �� �ʿ��� �߰� �۾��� ����
            }
        }
    }

    public GameObject GetObject()
    {
        lock (poolLock)
        {
            if (objectPool.Count > 0)
            {
                return objectPool.Dequeue();
            }
            else
            {
                // Ǯ�� ������Ʈ�� ���� �� �߰��� �����ϰų� ó��
                return null;
            }
        }
    }

    public void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        lock (poolLock)
        {
            objectPool.Enqueue(obj);
        }
    }
}
