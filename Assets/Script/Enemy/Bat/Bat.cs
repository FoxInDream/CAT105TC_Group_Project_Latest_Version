using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class Bat : Goblin
{
    public override void OnEnable()
    {
        //The biggest difference from the parent class is that it does not need to continuously track the player¡¯s position. It only flies towards the player¡¯s direction when spawned, instead of chasing the player.
        gameObject.layer = LayerMask.NameToLayer("FlyEnemy");  
        target = GameManager.instance.player.transform;
        moveDirection = (target.position - transform.position).normalized;  
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
