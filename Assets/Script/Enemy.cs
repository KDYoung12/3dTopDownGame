using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : LivingEntity
{
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;
    protected override void Start()
    {
        base.Start(); // 상속 받았을 때 상위클래스 (LivingEntity)
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
            if (!dead) //만약 enemy가 dead 상태가 됐을 경우 더 이상 pathfinding을 하지 않도록 제어 (그렇지 않으면 에러 발생 가능성 있음)
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}