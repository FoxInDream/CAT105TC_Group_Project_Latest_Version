using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    [Header("Knockback Parameter")]
    public bool isKnockedBack;
    private float knockbackTimer;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        KnockBackTimer();
    }
    public void KnockBackTrigger(Vector2 knockbackDirection, float knockbackForce)
    {
        knockbackTimer = 0.1f;
        isKnockedBack = true;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
    public void KnockBackTimer()
    {
        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0)
            {
                isKnockedBack = false;
            }
        }
    }
}
