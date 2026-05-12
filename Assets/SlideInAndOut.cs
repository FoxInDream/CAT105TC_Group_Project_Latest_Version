using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SlideInAndOut : MonoBehaviour
{
    public Animator shadowAnimator1;
    public Animator mainAnimator1;
    public Animator shadowAnimator2;
    public Animator mainAnimator2;
    public Animator shadowAnimator3;
    public Animator mainAnimator3;
    private int slideCount = 0;
    private int slideDirection = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RightButton()
    {
        slideCount++;
        slideDirection = 1;

        switch (slideCount % 3)
        {
            case 1:
                Switch1to2();
                break;
            case 2:
                Switch2to3();
                break;
            case 0:
                Switch3to1();
                break;
        }
    }
    public void LeftButton()
    {
        slideCount--;
        slideDirection = -1;
        switch (slideCount % 3)
        {
            case 1:
                Switch1to3();
                break;
            case 2:
                Switch3to2();
                break;
            case 0:
                Switch2to1();
                break;
        }
    }
    public void Switch1to2()
    {
        mainAnimator1.SetBool("LtR", false);
        mainAnimator1.SetBool("In", false);
        mainAnimator1.SetInteger("SD", 1);
        shadowAnimator1.SetBool("LtR", false);
        shadowAnimator1.SetBool("In", false);
        shadowAnimator1.SetInteger("SD", 1);
        mainAnimator2.SetBool("LtR", false);
        mainAnimator2.SetBool("In", true);
        mainAnimator2.SetInteger("SD", 1);
        shadowAnimator2.SetBool("LtR", false);
        shadowAnimator2.SetBool("In", true);
        shadowAnimator2.SetInteger("SD", 1);

    }
    public void Switch2to3()
    {
        mainAnimator2.SetBool("LtR", false);
        mainAnimator2.SetBool("In", false);
        mainAnimator2.SetInteger("SD", 1);
        shadowAnimator2.SetBool("LtR", false);
        shadowAnimator2.SetBool("In", false);
        shadowAnimator2.SetInteger("SD", 1);
        mainAnimator3.SetBool("LtR", false);
        mainAnimator3.SetBool("In", true);
        mainAnimator3.SetInteger("SD", 1);
        shadowAnimator3.SetBool("LtR", false);
        shadowAnimator3.SetBool("In", true);
        shadowAnimator3.SetInteger("SD", 1);
    }
    public void Switch3to1()
    {
        mainAnimator3.SetBool("LtR", false);
        mainAnimator3.SetBool("In", false);
        mainAnimator3.SetInteger("SD", 1);
        shadowAnimator3.SetBool("LtR", false);
        shadowAnimator3.SetBool("In", false);
        shadowAnimator3.SetInteger("SD", 1);
        mainAnimator1.SetBool("LtR", false);
        mainAnimator1.SetBool("In", true);
        mainAnimator1.SetInteger("SD", 1);
        shadowAnimator1.SetBool("LtR", false);
        shadowAnimator1.SetBool("In", true);
        shadowAnimator1.SetInteger("SD", 1);
    }
    public void Switch1to3()
    {
        mainAnimator1.SetBool("LtR", true);
        mainAnimator1.SetBool("In", false);
        mainAnimator1.SetInteger("SD", -1);
        shadowAnimator1.SetBool("LtR", true);
        shadowAnimator1.SetBool("In", false);
        shadowAnimator1.SetInteger("SD", -1);
        mainAnimator3.SetBool("LtR", true);
        mainAnimator3.SetBool("In", true);
        mainAnimator3.SetInteger("SD", -1);
        shadowAnimator3.SetBool("LtR", true);
        shadowAnimator3.SetBool("In", true);
        shadowAnimator3.SetInteger("SD", -1);   
    }
    public void Switch3to2()
    {
        mainAnimator3.SetBool("LtR", true);
        mainAnimator3.SetBool("In", false);
        mainAnimator3.SetInteger("SD", -1);
        shadowAnimator3.SetBool("LtR", true);
        shadowAnimator3.SetBool("In", false);
        shadowAnimator3.SetInteger("SD", -1);
        mainAnimator2.SetBool("LtR", true);
        mainAnimator2.SetBool("In", true);
        mainAnimator2.SetInteger("SD", -1);
        shadowAnimator2.SetBool("LtR", true);
        shadowAnimator2.SetBool("In", true);
        shadowAnimator2.SetInteger("SD", -1);
    }
    public void Switch2to1()
    {
        mainAnimator2.SetBool("LtR", true);
        mainAnimator2.SetBool("In", false);
        mainAnimator2.SetInteger("SD", -1);
        shadowAnimator2.SetBool("LtR", true);
        shadowAnimator2.SetBool("In", false);
        shadowAnimator2.SetInteger("SD", -1);
        mainAnimator1.SetBool("LtR", true);
        mainAnimator1.SetBool("In", true);
        mainAnimator1.SetInteger("SD", -1);
        shadowAnimator1.SetBool("LtR", true);
        shadowAnimator1.SetBool("In", true);
        shadowAnimator1.SetInteger("SD", -1);
    }
}
