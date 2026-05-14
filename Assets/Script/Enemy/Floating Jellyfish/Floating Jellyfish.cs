using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingJellyfish : Goblin
{
    //Unlike the parent class, this enemy stops within a certain range around the player and fires bullets toward them.

    public float stopDistance;

    public float FireRate;
    private float interval;



    public override void OnEnable()
    {
        base.OnEnable();
        interval = FireRate;

    }
    public override void Move()
    {

        float differentDistance = Vector2.Distance(transform.position, target.position);
        moveDirection = (target.position - transform.position).normalized;


        if (differentDistance > stopDistance)
        {
            rb.velocity = moveDirection * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            FireBullet();
        }


        if (moveDirection.x > 0)
            spriteRenderer.flipX = true;
        if (moveDirection.x < 0)
            spriteRenderer.flipX = false;
    }

    void FireBullet()
    {
        Vector2 targetDirection = (GameManager.instance.player.transform.position - transform.position).normalized;
        interval -= Time.deltaTime;
        if (interval <= 0)
        {
            interval = FireRate;
            GameObject jellyfishBullet = PoolManager.instance.Get(8);
            jellyfishBullet.transform.position = transform.position;
            jellyfishBullet.GetComponent<JellyfishBullet>().SetSpeed(targetDirection);
        }
    }
}