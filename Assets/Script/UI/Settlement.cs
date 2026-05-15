using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settlement : MonoBehaviour
{
    public static Settlement instance;
    public Text loseText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoseTheGame()
    {
        loseText.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
    public void WinTheGame()
    {
        winText.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}
