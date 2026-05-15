using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//欢迎来到玩家以及属性控制中心
public class Player : MonoBehaviour
{
    [Header("Camera Setting")]
    public CinemachineImpulseSource impulseSource;

    [Header("Move Parameter")]
    public Vector2 moveDirection;
    public float moveSpeed;
    private float horizontalInput;
    private float verticalInput;
    [Header("Components")]
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    public Texture2D cursorTexture;
    [Header("State Parameter")]
    public float currentExp;
    public float maxExp;
    public int maxHP;
    public int currentHP;
    public int level;
    public bool isLive;
    public bool isHurt;
    [Header("Knockback Area Parameter")]
    public float knockbackRadius;   
    public LayerMask enemyLayer;              

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        impulseSource=GetComponent<CinemachineImpulseSource>();

    }

    public void OnEnable()
    {
        currentHP = maxHP;
    }
    public void Update()
    {
        if (Time.timeScale != 0) //Switch back to default cursor when the game is paused
        {
            FlipByMouse();
            SetCustomCursor();  
        }
        else
        {
            SetDefaultCursor();
        }


        if(currentHP <= 0)
        {
            animator.SetTrigger("Dead");
        }
    }
    private void FixedUpdate()
    {
        Move();
    }



    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy")|| collision.CompareTag("EnemyBullet") || collision.CompareTag("Static Enemy")) //damage detection
        {
            if (!isHurt)
            {
                if (currentHP > 0)
                {

                    if (collision.CompareTag("Enemy"))
                    currentHP -=collision.GetComponent<Goblin>().damage ;

                    if (collision.CompareTag("EnemyBullet"))
                    {
                        currentHP--;
                        collision.gameObject.SetActive(false);
                    }


                    isHurt = true;
                    animator.SetTrigger("Hurt");

                    if (currentHP <= 0)
                    {
                        currentHP = 0;
                        isLive = false;
                    }
                    impulseSource.GenerateImpulse(); //Vibrate When Damaged
                    KnockbackNearbyEnemies(); //Knock Up Surrounding Enemies When Damaged


                }
            }
        }


        if(collision.CompareTag("Exp")) 
        {
            GetExp();
            collision.GetComponent<ExpLoot>().Disapper();
        }

    }

    public void Move()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = moveSpeed * moveDirection;
        animator.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("VelocityY", Mathf.Abs(rb.velocity.y));
    }




    private void FlipByMouse()//Method for player to rotate towards the mouse
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dirX = mousePosition.x - transform.position.x;
        if (dirX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0)
        {
            spriteRenderer.flipX = true;
        }
    }



    private void SetCustomCursor() //Change the cursor in game
    {
        Vector2 mousePoint = new Vector2(201, 201);
        Cursor.SetCursor(cursorTexture, mousePoint, CursorMode.Auto);
    }

    private void SetDefaultCursor()//Set cursor to default
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void GetExp()
    {
        currentExp+=5;
        if (currentExp >= maxExp)
        {
            level++;
            currentExp -= maxExp;
            maxExp += maxExp*0.5f;
            GameManager.instance.levelUpSystem.Show();
        }

    }


    public void KnockbackNearbyEnemies() //Knock back nearby enemies when taking damage
    {
        Collider2D[] nearByEnemies = Physics2D.OverlapCircleAll(transform.position, knockbackRadius, enemyLayer);
        foreach (Collider2D enemyCollider in nearByEnemies)
        {
            Vector2 knockbackDirection = (enemyCollider.transform.position - transform.position).normalized;
            KnockBack enemyknockBack = enemyCollider.GetComponent<KnockBack>();
            if(enemyknockBack != null)
            {
                enemyknockBack.KnockBackTrigger(knockbackDirection,30);
            }
        }
   }



    private void OnDrawGizmosSelected() //Draw Area Range
    {
        Gizmos.DrawWireSphere(transform.position, knockbackRadius);
    }





    public void OnHurtAnimationEnd() //Hurt Animation Event
    {
        isHurt = false;
    }



    public void Dead() //This method is attached to the last frame of the death animation.
    { 
        GameManager.instance.settlement.SetActive(true); //Switch to settlement screen upon death
        GameManager.instance.Stop();
    }
}



