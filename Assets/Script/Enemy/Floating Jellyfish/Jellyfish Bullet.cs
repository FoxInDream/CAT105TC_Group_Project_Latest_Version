using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class JellyfishBullet : Bullet
{
    //Unlike the parent bullet, this projectile does not interact with enemies. Instead, it will be destroyed together with the player's bullets upon collision.
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) //Disappears on player bullet or player collision.
        {
            gameObject.SetActive(false);
        }
    }


    public override void FarToDestory() 
    {
        float distanceX = Mathf.Abs(GameManager.instance.player.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(GameManager.instance.player.transform.position.y - transform.position.y);
        if (distanceX > 10 || distanceY > 10)
        {
            gameObject.SetActive(false);
        }

    }
}
