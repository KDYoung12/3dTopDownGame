using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : LivingEntity
{
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;
    protected override void Start()
    {
        base.Start(); // ��� �޾��� �� ����Ŭ���� (LivingEntity)
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }
    void Update()
    {
    }
    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if (!dead) //���� enemy�� dead ���°� ���� ��� �� �̻� pathfinding�� ���� �ʵ��� ���� (�׷��� ������ ���� �߻� ���ɼ� ����)
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}