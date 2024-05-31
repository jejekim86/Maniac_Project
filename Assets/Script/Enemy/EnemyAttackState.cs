using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : MonoBehaviour, State
{
    public Transform target;
    public GameObject Weapon;

    [Header("�� ���� ����")]
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

        ani.SetBool("isAttack", true);
        EnemyAttack enemyAttack = GetComponent<EnemyAttack>();
        enemyAttack.Attack();
        Weapon.SetActive(true);

    }

    public void UpdateState()
    {
        if (!isAttack)
        {
            isAttack = true;

            // ���ݽ� �÷��̾� �ٶ󺸱�
            transform.LookAt(target);

            // ���ݽ� ��ġ ����
            EnemyAgent.SetDestination(transform.position);

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
        ani.SetBool("isAttack", false);
        Weapon.SetActive(false);
    }
}