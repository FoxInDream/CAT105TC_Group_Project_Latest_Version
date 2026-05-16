using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Exploder : Goblin
{

    //Unlike the parent class, this enemy does not play a death animation. Instead, it creates an explosion upon death.
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            currenthealth -= collision.GetComponent<Bullet>().damage; //damage detection
            if (currenthealth > 0)
            {

                rb.velocity = Vector2.zero;
                animator.SetTrigger("Hurt");
                Vector3 playerPosition = GameManager.instance.player.transform.position;
                Vector2 knockbackDirection = (transform.position - playerPosition).normalized;
                knockBack.KnockBackTrigger(knockbackDirection, 1);
            }
            else
            {
                isLive = false;
                gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
                rb.velocity = Vector2.zero;
                GameManager.instance.kill++; //Increase player kill count
                SpawnExpLoot();
                Dead();
            }
            GameObject damageNumber = PoolManager.instance.Get(9);
            damageNumber.transform.SetParent(transform);
            damageNumber.transform.position = transform.position;
            damageNumber.GetComponent<HUD>().damageNumber = collision.GetComponent<Bullet>().damage;
        }

        if (collision.CompareTag("Player"))
        {
            isLive = false;
            gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
            rb.velocity = Vector2.zero;
            SpawnExpLoot();
            Dead();
        }
    }

    public override void Dead()
    {

        base.Dead();
        GameObject Explosion = PoolManager.instance.Get(10);
        Explosion.transform.position = transform.position;
    }

}
