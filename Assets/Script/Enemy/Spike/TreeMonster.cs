using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMonster: Goblin
{
    public float timer = 0;
    
    public override void FixedUpdate()
    {
    }


    public  void Update()
    {
        RevealItself();
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
                GameManager.instance.spawner.treeMonsterCount--;
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

    private void RevealItself()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            animator.SetTrigger("Reveal");
            timer= 0;
        }
    }
}
