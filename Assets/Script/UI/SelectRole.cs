using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SelectRole : MonoBehaviour
{
    public GameObject[] backgrounds;

    private int currentIndex = 0;

    void Start()
    {
        ShowBackground(0);
    }

    public void NextPage()
    {
        if (currentIndex >= backgrounds.Length - 1)
            return;

        PlayAnim(backgrounds[currentIndex], "PlayOut");

        currentIndex++;

        ShowBackground(currentIndex);
        PlayAnim(backgrounds[currentIndex], "PlayIn");
    }

    public void PreviousPage()
    {
        if (currentIndex <= 0)
            return;

        PlayAnim(backgrounds[currentIndex], "PlayOut");

        currentIndex--;

        ShowBackground(currentIndex);
        PlayAnim(backgrounds[currentIndex], "PlayIn");
    }

    void ShowBackground(int index)
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == index);
        }
    }

    void PlayAnim(GameObject obj, string trigger)
    {
        Animator anim = obj.GetComponent<Animator>();
        if (anim != null)
            anim.SetTrigger(trigger);
    }
}
