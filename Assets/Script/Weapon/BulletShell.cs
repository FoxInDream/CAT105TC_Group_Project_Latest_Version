using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    public float ariSpeed; //Proportional to the air time.
    public float stopTime =0.5f;
    public float fadeSpeed = 0.01f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        

    }
    private void OnEnable()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
        rb.gravityScale = 3;
        rb.velocity = Vector2.up * ariSpeed;
        StartCoroutine(Stop());
       
    }

    // Update is called once per frame


    IEnumerator Stop() {
        yield return new WaitForSeconds(stopTime);
        rb.velocity= Vector2.zero;
        rb.gravityScale = 0;
        while(spriteRenderer.color.a>0)
        {
            spriteRenderer.color=new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a-fadeSpeed);
            yield return new WaitForFixedUpdate();
        }
       gameObject.SetActive(false);
     }
}
