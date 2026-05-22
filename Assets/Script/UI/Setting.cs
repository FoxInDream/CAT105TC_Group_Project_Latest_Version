using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject pause;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickCloseSetting()
    {
        gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }

    public void OnClickOpenSettingInMainMenu() {
        gameObject.SetActive(false);
    }
}
