using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settlement : MonoBehaviour
{
    public Text loseText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        if (loseText != null)
        {

        }
    }
    public void OnClickBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoseTheGame()
    {
        gameObject.SetActive(true);
        winText.gameObject.SetActive(false);
    }
    public void WinTheGame()
    {
        gameObject.SetActive(true);
        loseText.gameObject.SetActive(false);
    }
}
