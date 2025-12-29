using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public LifeController lifeEnemy;
    [SerializeField] protected int _hp;
    protected bool isDead = false;

    [SerializeField] private float _speed;
    [SerializeField] protected int _damage;

    [SerializeField] public  PlayerController player;

    protected EnemyManager managerEnemy;

    protected AnimationHandler _anim;
    protected Rigidbody2D _rb;

    protected Vector2 dir;

    public void ChasePlayer()
    {
        _rb.MovePosition(Vector2.MoveTowards(_rb.position, player.transform.position, _speed * Time.fixedDeltaTime));

    }

    protected void SetDirAnimation(out Vector2 direction)
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();
        _anim.SetDirectionAnimation(direction);
    }
    public virtual void DieEnemy()
    {
        isDead = true;
        _anim.StartAnimationDeath(isDead);
        GetComponent<Collider2D>().enabled = false;
        managerEnemy.RemoveEnemy(this);
        Destroy(gameObject, 5f);
        Debug.Log("nemico morto");
    }

    protected virtual void Awake()
    {
        _anim = GetComponentInChildren<AnimationHandler>();
        _rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = FindAnyObjectByType<PlayerController>();
        }
        lifeEnemy = GetComponent<LifeController>();
        if (lifeEnemy == null)
        {
            lifeEnemy = gameObject.AddComponent<LifeController>();
        }
        lifeEnemy.Hp = _hp;

        managerEnemy = FindAnyObjectByType<EnemyManager>();
        managerEnemy.AddEnemy(this);
    }

    private void Update()
    {
        if (player != null&&isDead==false)
        {
            SetDirAnimation(out dir);
            ChasePlayer();
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
            DieEnemy();

        }
        
    }

}
