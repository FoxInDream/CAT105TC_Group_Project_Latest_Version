using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class Goblin : MonoBehaviour
{
    //Goblin Monster System

    [Header("Move Parameter")]
    public Vector2 moveDirection;

    [Header("State Parameter")]
    public int damage;
    protected float speed;
    public float currenthealth;
    protected bool isLive;
    [Header("Transform")]
    protected Transform target;
    [Header("Components")]
    protected Animator animator;
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
        gameObject.layer = LayerMask.NameToLayer("GroundEnemy");
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
                Vector3 playerPosition = GameManager.instance.player.transform.position;
                Vector2 knockbackDirection = (transform.position - playerPosition).normalized;
                knockBack.KnockBackTrigger(knockbackDirection,1);
            }
            else
            {
                isLive = false;
                gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
                rb.velocity = Vector2.zero;
                animator.SetTrigger("Dead");
                SpawnExpOrbs();
                GameManager.instance.kill++;
            }
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





    public void Init(float maxHealth,float speed,int damage)
    {
        currenthealth = maxHealth;
        this.speed = speed;
        this.damage = damage;
    }
    public void Dead()
    {
        spriteRenderer.color = Color.white;
        gameObject.SetActive(false);
    }
    protected void SpawnExpOrbs()
    {
        GameObject lootExp = GameManager.instance.poolManager.Get(4);
        lootExp.transform.position= transform.position;
    }
        
    }
