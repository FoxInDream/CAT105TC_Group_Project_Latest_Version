using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementWatcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player.isLive == false)
        {
            Settlement.instance.LoseTheGame();
        }
        if (GameManager.instance.player.isLive == true && GameManager.instance.timer == 0)
        {
            Settlement.instance.WinTheGame();
        }
    }
}
