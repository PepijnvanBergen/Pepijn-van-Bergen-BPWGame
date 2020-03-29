using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

    public Animator anim;
    public GameObject target = null;
    public Transform ttarget;
    public NavMeshAgent agent;

    public float range = 10f;
    public float maxAngle;
    public float seeRadius;
    public float attackRadius;

    private bool isInFov = false;

    private EnemyState currentState;

    public enum EnemyState
    {
        Idle,
        Chasing,
        Attack
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        isInFov = inFOV(transform, ttarget, maxAngle, seeRadius);
        float distance = Vector3.Distance(transform.position, target.transform.position);

        switch (currentState)
        {
            case EnemyState.Chasing:
                {
                    if(distance <= range || distance >= attackRadius)
                    {
                        //Chasing
                        agent.SetDestination(target.transform.position);
                        anim.SetBool("IsRunning", true);

                        currentState = EnemyState.Chasing;
                    }

                    if(distance >= range)
                    {
                        currentState = EnemyState.Idle;
                    }

                    if(distance <= attackRadius)
                    {
                        currentState = EnemyState.Attack;
                    }
                    break;
                }
            case EnemyState.Attack:
                {
                    if (distance <= attackRadius && isInFov)
                    {
                        //Attacking
                        agent.ResetPath();
                        anim.SetBool("IsRunning", false);
                        anim.SetBool("IsAttacking", true);

                        currentState = EnemyState.Attack;
                    }
                    else
                    {
                        anim.SetBool("IsAttacking", false);
                        currentState = EnemyState.Chasing;
                    }
                    break;
                }
            case EnemyState.Idle:
                {
                    if (distance >= range)
                    {
                        //Idle
                        agent.ResetPath();
                        anim.SetBool("IsRunning", false);
                        currentState = EnemyState.Idle;
                    }
                    else
                    {
                        currentState = EnemyState.Chasing;
                    }
                    break;
                }
        }
        //if (distance <= range)
        //{
        //    //Chasing
        //    agent.SetDestination(target.transform.position);
        //    anim.SetBool("IsRunning", true);
        //}
        //else
        //{
        //    //Idle
        //    agent.ResetPath();
        //    anim.SetBool("IsRunning", false);
        //}
        //if (isInFov && distance <= attackRadius)
        //{
        //    //Attacking
        //    agent.ResetPath();
        //    anim.SetBool("IsRunning", false);
        //    anim.SetBool("IsAttacking", true);
        //}
        //else
        //{
        //    //Idle
        //    anim.SetBool("IsAttacking", false);
        //}

    }

    private void OnDrawGizmosSelected()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= attackRadius)
        {
            //for attack
            Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * attackRadius;
            Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * attackRadius;

            if(!isInFov) Gizmos.color = Color.red; else Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, (ttarget.position - transform.position).normalized * attackRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, fovLine1);
            Gizmos.DrawRay(transform.position, fovLine2);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Vector3 directionBetween = (target.position - checkingObject.position).normalized;
        directionBetween.y *= 0;
        RaycastHit hit;
        if (Physics.Raycast(checkingObject.position, (target.position - checkingObject.position).normalized, out hit, maxRadius))
        {
            if (LayerMask.LayerToName(hit.transform.gameObject.layer) == "Player")
            {
                float angle = Vector3.Angle(checkingObject.forward, directionBetween);
                if (angle <= maxAngle)
                {
                    return true;
                }
            }
        }
        return false;
    }
}