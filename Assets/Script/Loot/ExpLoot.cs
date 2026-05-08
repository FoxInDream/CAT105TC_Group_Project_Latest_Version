using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLoot : MonoBehaviour
{
    private float disapperTimer;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
    }
}
