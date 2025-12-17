using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float lifespan;

    private Vector2 directionBullet;

    private Rigidbody2D _rb;

    public void SetUpDirection(Vector2 direction)
    {
        directionBullet = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.lifeEnemy.TakeDamage(damage);
            if (!enemy.lifeEnemy.IsAlive())
            {
                enemy.DieEnemy();
            }
          
        }
        Destroy(gameObject); 
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            _rb = gameObject.AddComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
        }
    }

    private void Start()
    {
        Destroy(gameObject,lifespan);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + directionBullet * (speed * Time.fixedDeltaTime));
    }
}
