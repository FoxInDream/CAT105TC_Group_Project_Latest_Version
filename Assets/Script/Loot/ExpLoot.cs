using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLoot : MonoBehaviour
{
    private float disapperTimer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

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
    private void DisapperTimer()
    {
        disapperTimer += Time.deltaTime;
        animator.SetFloat("Disapper Time", disapperTimer);
    }

    public void Disapper()
    {
        gameObject.SetActive(false);
        spriteRenderer.color = new Color(1, 1, 1, 1);

    }
}
