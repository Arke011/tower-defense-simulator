using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public Transform partToRotate;
    private float turnSpeed = 10;
    private float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab; // Change the variable name to bulletPrefab
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("LockOnTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletYAY = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Use bulletPrefab here
        Bullet bullet = bulletYAY.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void LockOnTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= range)
        {
            target = closestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
