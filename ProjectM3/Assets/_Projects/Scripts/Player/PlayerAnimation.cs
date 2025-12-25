using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : AnimationHandler
{
    PlayerController player;
    new private void Awake()
    {
        base.Awake();
        player= GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (player.Direction!=Vector2.zero)
        {
            SetDirectionAnimation(player.Direction);
        }
        
    }
}
