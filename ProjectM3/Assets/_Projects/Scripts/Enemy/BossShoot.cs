using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField] BulletBoss bulletPrefab;
    public void Shoot(Vector2 direction, PlayerController player)
    {
        if (player)
        {
            direction = direction.normalized;
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = gameObject.transform.position;
            bullet.SetUpDirection(direction);
        }

    }
}
