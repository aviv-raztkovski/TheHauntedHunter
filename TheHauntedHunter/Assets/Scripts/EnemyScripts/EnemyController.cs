using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float damage = 5f;
    public Transform attackHitBox;

    Transform player;
    NavMeshAgent agent;
    EntityHealthScript playerHealth;

    float stoppingDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        stoppingDistance = agent.stoppingDistance + player.GetComponent<CapsuleCollider>().radius + transform.GetComponent<CapsuleCollider>().radius;

        playerHealth = player.parent.GetComponent<EntityHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            if (distance >= stoppingDistance)
            {
                agent.isStopped = false;
                agent.SetDestination(player.position);
            }
            else
            {
                Attack();
                FaceTarget();
                agent.isStopped = true;
            }
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Attack()
    {
        playerHealth.takeDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
