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

            // 서브 스레드에서 수행하기 때문에 메인 스레드와의 충돌을 방지
            if (i % 100 == 0)
            {
                Thread.Sleep(1); // 임시로 슬립을 넣어 메인 스레드의 부하를 줄임
            }
        }
    }
    void Update()
    {
        // 메인 스레드에서 풀에서 오브젝트를 가져와 활성화
        lock (poolLock)
        {
            if (objectPool.Count > 0)
            {
                GameObject obj = objectPool.Dequeue();
                obj.SetActive(true);
                // 오브젝트를 활성화 후 필요한 추가 작업을 수행
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
                // 풀에 오브젝트가 없을 때 추가로 생성하거나 처리
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
