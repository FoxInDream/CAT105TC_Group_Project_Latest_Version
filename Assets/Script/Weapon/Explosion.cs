using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        ExplosionAnimation();
    }

    private void ExplosionAnimation()
    {
       
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime>= 1)
        {
            gameObject.SetActive(false);
        }
    }
}


