using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject setting;
    // Start is called before the first frame update



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

    public void OnClickOpenSetting()
    {
        setting.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OnClickQuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
