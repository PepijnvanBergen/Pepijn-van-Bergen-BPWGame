using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target;
    public float range = 20f;
    public string playerTag = "Player";

    public GameObject enemyBulletPrefab;
    public Transform turretRotate;
    public Transform muzzle;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }

        }
        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        if (shortestDistance < range)
        {
            shoot();
        }
        
    }
    void Update()
    {
        
        if (target == null) { return; }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = lookRotation.eulerAngles;
        turretRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


    }
    void shoot()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
