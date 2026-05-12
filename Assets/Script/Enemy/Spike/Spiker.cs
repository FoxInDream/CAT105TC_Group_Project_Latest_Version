using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiker : Goblin
{
    public override void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        moveDirection = (target.position - transform.position).normalized;
        if (moveDirection.x > 0)
            spriteRenderer.flipX = true;
        if (moveDirection.x < 0)
            spriteRenderer.flipX = false;
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            currenthealth -= collision.GetComponent<Bullet>().damage; //damage detection
            if (currenthealth > 0)
            {
                animator.SetTrigger("Hurt");
                Vector3 playerPosition = GameManager.instance.player.transform.position;
                Vector2 knockbackDirection = (transform.position - playerPosition).normalized;
            }
            else
            {
                isLive = false;
                gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
                animator.SetTrigger("Dead");
                SpawnExpLoot();
                GameManager.instance.spawner.spikerCount--;
                GameManager.instance.kill++;
            }
            GameObject damageNumber = PoolManager.instance.Get(9);
            damageNumber.transform.SetParent(transform);
            damageNumber.transform.position = transform.position;
            damageNumber.GetComponent<HUD>().damageNumber = collision.GetComponent<Bullet>().damage;

        }
        if (collision.CompareTag("Explosion"))
        {
            GameObject damageNumber = PoolManager.instance.Get(9);
            damageNumber.transform.SetParent(transform);
            damageNumber.transform.position = transform.position;
            damageNumber.GetComponent<HUD>().damageNumber = 999;
        }
    }

}
