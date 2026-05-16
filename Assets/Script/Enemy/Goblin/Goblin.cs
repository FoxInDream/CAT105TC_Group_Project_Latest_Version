using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class Goblin : MonoBehaviour
{
    //Goblin Monster System
    //This script is the parent class for all enemies.

    [Header("Move Parameter")]
    public Vector2 moveDirection;

    [Header("State Parameter")]
    public int damage;
    protected float speed;
    public float currenthealth;
    public bool isLive;
    [Header("Transform")]
    protected Transform target;
    [Header("Components")]
    public Animator animator;
    public Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    protected KnockBack knockBack;

    private void Awake()
    {
        knockBack=GetComponent<KnockBack>();
        animator = GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb=gameObject.GetComponent<Rigidbody2D>();
    }

    public virtual void OnEnable()
    {
        gameObject.layer = LayerMask.NameToLayer("GroundEnemy"); //Reset monster layer on respawn to resume collision and interaction with other objects.
        target = GameManager.instance.player.transform;
        isLive = true;
       
    }

    public virtual void FixedUpdate()
    {
        if (!knockBack.isKnockedBack && isLive)
        Move();
    }




    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            currenthealth -= collision.GetComponent<Bullet>().damage; //damage detection
            if (currenthealth > 0)
            {

                rb.velocity = Vector2.zero;
                animator.SetTrigger("Hurt");
                //Make the enemy receive knockback when attacked by the player.
                Vector3 playerPosition = GameManager.instance.player.transform.position;
                Vector2 knockbackDirection = (transform.position - playerPosition).normalized; 
                knockBack.KnockBackTrigger(knockbackDirection,1);
            }
            else
            {
                isLive = false;
                gameObject.layer = LayerMask.NameToLayer("DeadEnemy"); //Switch to dead enemy layer upon death to avoid collision detection with certain objects.
                rb.velocity = Vector2.zero;
                SpawnExpLoot();
                GameManager.instance.kill++; //Increase player kill count
                animator.SetTrigger("Dead");
            }


            //Display incoming damage value
            GameObject damageNumber = PoolManager.instance.Get(9);
            damageNumber.transform.SetParent(transform);
            damageNumber.transform.position = transform.position;
            damageNumber.GetComponent<HUD>().damageNumber = collision.GetComponent<Bullet>().damage;
        }

        if(collision.CompareTag("Explosion"))//Take explosion damage from explosive enemies, die instantly, and display 999 damage taken.
        {
            GameObject damageNumber = PoolManager.instance.Get(9);
            damageNumber.transform.SetParent(transform);
            damageNumber.transform.position = transform.position;
            damageNumber.GetComponent<HUD>().damageNumber = 999;
        }
    }


    public virtual void Move()
    {
        moveDirection = (target.position - transform.position).normalized;
        rb.velocity = moveDirection * speed;
        if (moveDirection.x > 0)
            spriteRenderer.flipX = false;
        if (moveDirection.x < 0)
            spriteRenderer.flipX = true;
    }





    public void Init(float maxHealth,float speed,int damage)//Initialize the enemy; called when spawning the enemy.
    {
        currenthealth = maxHealth;
        this.speed = speed;
        this.damage = damage;
    }
    public virtual void Dead() //Restore the enemy's color values on death to fix color display bugs when respawning.
    {
        gameObject.SetActive(false);
        spriteRenderer.color = Color.white;
    }


    public void SpawnExpLoot() //Drop EXP
    {
        GameObject lootExp = PoolManager.instance.Get(4);
        lootExp.transform.position= transform.position;
    }
        
    }
