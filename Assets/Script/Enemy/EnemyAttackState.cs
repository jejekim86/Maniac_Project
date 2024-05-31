using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : MonoBehaviour, State
{
    public Transform target;

    [Header("적 공격 정보")]
    public float coolTime;
    public float damage = 5;
    public float attackRange;
    private bool isAttack;

    private Animator ani;
    private NavMeshAgent EnemyAgent;
    private Enemy enemy;

    public void EnterState()
    {
        if (ani == null || EnemyAgent == null || enemy == null)
        {
            ani = GetComponent<Animator>();
            EnemyAgent = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Enemy>();
        }

        ani.SetBool("isKicking", true);
    }

    public void UpdateState()
    {
        if (!isAttack)
        {
            isAttack = true;

            // 공격시 위치 고정
            EnemyAgent.SetDestination(transform.position);

            // 공격시 플레이어 바라보기
            transform.LookAt(target);

            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(coolTime);
        isAttack = false;
    }

    public void ExitState()
    {
        ani.SetBool("isKicking", false);
    }
}