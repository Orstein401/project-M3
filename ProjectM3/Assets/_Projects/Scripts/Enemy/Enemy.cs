using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    public LifeController lifeEnemy;
    [SerializeField] private int _hp;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] PlayerController player;

    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
    }

    public void DieEnemy()
    {
        Debug.Log("nemico morto");
        Destroy(gameObject);
    }
    private void Awake()
    {
        lifeEnemy = GetComponent<LifeController>();
        if(lifeEnemy == null)
        {
            lifeEnemy =gameObject.AddComponent<LifeController>();
        }
        lifeEnemy.Hp = _hp;
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
