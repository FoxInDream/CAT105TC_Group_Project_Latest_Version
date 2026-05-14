using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLoot : MonoBehaviour
{
    private float disapperTimer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    //Dropped Experience Script
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        DisapperTimer();
    }

    private void OnEnable()
    {
        disapperTimer = 0;
    }
    private void DisapperTimer() //Countdown, trigger experience fade animation on timeout
    {
        disapperTimer += Time.deltaTime;
        animator.SetFloat("Disapper Time", disapperTimer);
    }

    public void Disapper() // Attach the disappear method to the last frame of the experience orb's disappearance animation
    {
        gameObject.SetActive(false);
        spriteRenderer.color = new Color(1, 1, 1, 1);

    }
}
