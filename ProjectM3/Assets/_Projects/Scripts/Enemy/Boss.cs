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

    private bool isShooting = false;
    [SerializeField]float spread = 0.3f;//di quanto la nuova direzione di sparo si deve aprire


    protected override void Awake()
    {
        base.Awake();
        distanceAttk = GetComponent<BossShoot>();
    }

    private  void Update()
    {
 
        if (player != null && !isDead)
        {
            SetDirAnimation(out dir);        
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance<= _rangeMeleeAttack || distance >= _rangeChasing)
            {
                isShooting = false;
                _anim.StartAnimationShoot(isShooting);
                ChasePlayer();
            }
            else
            {
                isShooting = true;
                _anim.StartAnimationShoot(isShooting);
                if (Time.time - lastTimeShoot > fireRate)
                {
                    lastTimeShoot = Time.time;

                    Vector2 side = new Vector2(-dir.y, dir.x); //è per dare una nuova direzione seguendo quella voluta

                    distanceAttk.Shoot(dir, player);          
                    distanceAttk.Shoot((dir + side * spread), player);
                    distanceAttk.Shoot((dir - side * spread), player);

                }



            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            player.lifePlayer.TakeDamage(_damage);
            Debug.Log("vita player " + player.lifePlayer.Hp);
            if (!player.lifePlayer.IsAlive())
            {
                player.DiePlayer();
            }
            

        }

    }

}
