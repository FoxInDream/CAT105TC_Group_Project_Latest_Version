using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectRoleButton : MonoBehaviour
{
    public Button startButton;
    public Image hint;
    public Canvas MainMenu;
    public SelectRoleFinal selectRoleFinal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlay();
    }

    public void CheckToPlay()
    {
        switch (SelectRoleFinal.currentRoleIndex) 
        {
            case 0:
                startButton.gameObject.SetActive(true);
                hint.gameObject.SetActive(false);
                break;
            case 1:
                startButton.gameObject.SetActive(false);
                hint.gameObject.SetActive(true);
                break;
            case 2:
                startButton.gameObject.SetActive(false);
                hint.gameObject.SetActive(true);
                break;
        }
    } 
    public void StartGame()
    {        
        SceneManager.LoadScene("PlayScene");
    }
}
