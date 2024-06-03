using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : MonoBehaviour, State
{
    [Header("�� ��ġ ����")]
    [SerializeField] private GameObject[] walkPoints;
    private int curEnemyPos = 0;
    private float walkingPointRadius = 2;

    private Animator ani;
    private NavMeshAgent enemyAgent;
    private Enemy enemy;

    public void EnterState()
    {
        if (ani == null || enemyAgent == null || enemy == null)
        {
            ani = GetComponent<Animator>();
            enemyAgent = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Enemy>();
        }

        ani.SetBool("isWalking", true);
    }

    public void UpdateState()
    {
        // ���� ��ġ�� ���� ���� ��ġ ���� �Ÿ� Ȯ��
        if (Vector3.Distance(walkPoints[curEnemyPos].transform.position, transform.position) < walkingPointRadius)
        {
            // ���� �湮 ���� �������� ����
            curEnemyPos = Random.Range(0, walkPoints.Length);

            // �迭 �ʰ��� �ε��� �ʱ�ȭ
            if (curEnemyPos >= walkPoints.Length)
            {
                curEnemyPos = 0;
            }
        }
        
        // �̵� ���
        enemyAgent.SetDestination(walkPoints[curEnemyPos].transform.position);

    }

    public void ExitState()
    {
        ani.SetBool("isWalking", false);
    }
}
