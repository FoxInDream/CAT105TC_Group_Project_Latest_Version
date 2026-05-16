using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ExploderExplosion : BulletExplosion
{
    public float explosionRadius;

    protected override void Update()
    {
        ExplosionAnimation();
        DetectExplosionTargets();
    }






    private void DetectExplosionTargets()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D col in colliders)
        {
          
            if (col.CompareTag("Enemy")|| col.CompareTag("Exploder") ||col.CompareTag("Static Enemy"))
            {
                if (col.GetComponent<Goblin>().isLive)
                {
                    col.GetComponent<Goblin>().isLive = false;
                    col.GetComponent<Goblin>().gameObject.layer = LayerMask.NameToLayer("DeadEnemy");


                    if(col.CompareTag("Enemy") || col.CompareTag("Exploder"))
                    col.GetComponent<Goblin>().rb.velocity = Vector2.zero;

                    if (col.CompareTag("Enemy"))
                        col.GetComponent<Goblin>().animator.SetTrigger("Dead");


                    if (col.CompareTag("Exploder"))
                        col.GetComponent<Goblin>().Dead();

                    col.GetComponent<Goblin>().SpawnExpLoot();
                    GameManager.instance.kill++;
                }
            }



            if (col.CompareTag("Player"))
            {
                if (GameManager.instance.player.isLive)
                {
                    if (!GameManager.instance.player.isHurt)
                    {


                        if (GameManager.instance.player.currentHP > 0)
                        {
                            GameManager.instance.player.currentHP--;
                            GameManager.instance.player.isHurt = true;
                            GameManager.instance.player.animator.SetTrigger("Hurt");

                        }
                        else if (GameManager.instance.player.currentHP <= 0)
                        {
                            GameManager.instance.player.currentHP = 0;
                            GameManager.instance.player.isLive = false;
                        }
                        GameManager.instance.player.impulseSource.GenerateImpulse();
                        GameManager.instance.player.KnockbackNearbyEnemies();
                    }
                }


            }

        }
    }

    private void OnDrawGizmosSelected() //Draw Area Range
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
