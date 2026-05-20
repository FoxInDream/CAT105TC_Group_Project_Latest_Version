using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Canvas setting;
    public Canvas selectRole;
    public GameObject selectRoles;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameObject.SetActive(true);
        setting.gameObject.SetActive(false);
        selectRole.gameObject.SetActive(false);
        selectRoles.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickStartGame()
    {
        gameObject.SetActive(false);
        selectRole.gameObject.SetActive(true);
        selectRoles.gameObject.SetActive(true);
    }
    public void OnClickOpenSetting()
    {
        setting.gameObject.SetActive(true);
    }
}
