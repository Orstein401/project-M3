using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Boss : Enemy
{

    [SerializeField] private float _rangeMeleeAttack;
    [SerializeField] private float _rangeChasing;

    private BossShoot distanceAttk;
    private float lastTimeShoot;
    [SerializeField] private float fireRate;



    protected override void Awake()
    {
        base.Awake();
        distanceAttk = GetComponent<BossShoot>();
    }

    private  void Update()
    {
        Debug.Log("boss");

        if (player != null && isDead == false)
        {
            SetDirAnimation(out dir);        
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance<= _rangeMeleeAttack || distance >= _rangeChasing)
            {
                Debug.Log("te sto a insegui merdina");
                ChasePlayer();
            }
            else
            {
                if (Time.time - lastTimeShoot > fireRate)
                {
                    lastTimeShoot = Time.time;
                    distanceAttk.Shoot(dir,player);


                }

                Debug.Log("ciccio avvicinati");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            player.lifePlayer.TakeDamage(_damage);
            if (!player.lifePlayer.IsAlive())
            {
                player.DiePlayer();
            }
            

        }

    }

}
