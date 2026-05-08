using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody2D rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        FarToDestory(); //The bullet detonates after traveling a certain distance.
    }

    public void SetSpeed(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBullet"))
        {
            GameObject explosion = GameManager.instance.poolManager.Get(2);
            explosion.transform.position = transform.position;
            gameObject.SetActive(false);
        }
    }


    public virtual void FarToDestory() 
    {
        float distanceX = Mathf.Abs(GameManager.instance.player.transform.position.x - transform.position.x);
        float distanceY = Mathf.Abs(GameManager.instance.player.transform.position.y - transform.position.y);
        if (distanceX > 10 || distanceY > 10)
        {
            GameObject explosion = GameManager.instance.poolManager.Get(2);
            explosion.transform.position = transform.position;
            gameObject.SetActive(false);
        }

    }
}
