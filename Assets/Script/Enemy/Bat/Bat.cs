using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class Bat : Goblin
{
    public override void OnEnable()
    {
        gameObject.layer = LayerMask.NameToLayer("FlyEnemy");
        isLive = true;

    }

    public override void Move()
    {
        rb.velocity = moveDirection * speed;
        if (moveDirection.x > 0)
            spriteRenderer.flipX = false;
        if (moveDirection.x < 0)
            spriteRenderer.flipX = true;
    }

}
