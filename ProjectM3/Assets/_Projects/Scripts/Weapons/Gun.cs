using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] private float fireRate;

    PlayerController directionShoot;
    private float lastTimeShoot;
    public void Shoot(Vector2 direction)
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.transform.position = gameObject.transform.position;
        bullet.SetUpDirection(direction);
    }

    private void Awake()
    {

        directionShoot=GetComponentInParent<PlayerController>();
    }
    private void Update()
    {
        if (Time.time - lastTimeShoot > fireRate)
        {
            Shoot(directionShoot.Direction);
            lastTimeShoot = Time.time;
        }
    }
}
