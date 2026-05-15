using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject setting;
    // Start is called before the first frame update
    void Start()
    {
        setting.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OpenPausePanel()
    {
        gameObject.SetActive(true);
        GameManager.instance.Stop();
    } 
    public void OnResumeGame()
    {
        gameObject.SetActive(false);
        GameManager.instance.Resume();
    }

    public void OnClickClosePause()
    {
        gameObject.SetActive(false);
    }
    public void OnClickOpenSetting()
    {
        gameObject.SetActive(false);
        setting.gameObject.SetActive(true);
    }
    public void OnClickQuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
