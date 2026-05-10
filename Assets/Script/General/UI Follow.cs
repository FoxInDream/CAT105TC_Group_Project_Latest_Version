using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
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
