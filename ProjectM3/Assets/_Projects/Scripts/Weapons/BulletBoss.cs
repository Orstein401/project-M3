using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : Bullet
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var player))
        {
            player.lifePlayer.TakeDamage(damage);
            Debug.Log("vita player " + player.lifePlayer.Hp);

            if (!player.lifePlayer.IsAlive())
            {
                player.DiePlayer();
            }

        }
        Destroy(gameObject);
    }
}
