using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRange;

    EnemyManager managerEnemy;

    PlayerController player;
    private float lastTimeShoot;
    public void Shoot(Vector2 direction)
    {
        GameObject closeEnemy = FindNearestEnemy();
        if (closeEnemy)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = gameObject.transform.position;
            bullet.SetUpDirection(direction);
        }
       
    }

    public GameObject FindNearestEnemy()
    {
        GameObject closestEnemy = null;
        float minDist = fireRange;

        foreach (var enemy in managerEnemy.enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                closestEnemy = enemy.gameObject;
            }

        }
        return closestEnemy;
    }

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
        managerEnemy = FindAnyObjectByType<EnemyManager>();
    }
    private void Update()
    {
        if (Time.time - lastTimeShoot > fireRate&&!player.isDeath)
        {
            lastTimeShoot = Time.time;
            Shoot(player.lastDirection);

        }
    }
}
