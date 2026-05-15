using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Welcome to the Game Management System, which streamlines cross-object script referencing and enables various global control functionalities.
    [Header("Components")]
    public Player player;
    public Rifle rifle;
    public LevelUpSystem levelUpSystem;
    public Spawner spawner;
    public GameObject settlement;
    public Pause pause;
    public static GameManager instance;
    //Static members can be accessed from other scripts without creating an instance.
    [Header("Variables")]
    public int kill;
    public float timer;
    public bool isPauseOpen = false;
    private void Awake()
    {
        kill = 0;
        timer = 300;
        instance = this;
        Time.timeScale = 1;
        isPauseOpen = false;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
            KillAllEnemies();
        }

        if(Input.GetKeyDown(KeyCode.Escape)&& isPauseOpen == true)
        {
            pause.OnResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.OpenPausePanel();
        }



    }
    public void Stop()
    {
        Time.timeScale = 0;
        isPauseOpen = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        isPauseOpen = false;

    }


    private void KillAllEnemies()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] allExploder = GameObject.FindGameObjectsWithTag("Exploder");
        GameObject[] allStaticEnemy = GameObject.FindGameObjectsWithTag("Static Enemy");
        foreach (GameObject enemy in allEnemies)
        {
            enemy.GetComponent<Animator>().SetTrigger("Dead");
        }

        foreach(GameObject Exploder in allExploder)
        {
            Exploder.GetComponent<Exploder>().Dead();
        }

        foreach (GameObject Exploder in allStaticEnemy)
        {
            Exploder.GetComponent<Animator>().SetTrigger("Dead");
        }
    }


}
