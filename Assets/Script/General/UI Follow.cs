using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    //Solves the issue where the Reload Bar cannot stay fixed above the player, caused by the Virtual Camera moving with the player instead of being stationary.
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        rectTransform.position=Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position+new Vector3(0,0.8f,0));
    }
}
