using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public Setting setting;
    public static GameManager instance;
    //Static members can be accessed from other scripts without creating an instance.
    [Header("Variables")]
    public int kill;
    public float timer;
    public bool isPauseOpen;
    private void Awake()
    {
        kill = 0;
        timer = 300;
        instance = this;
        Time.timeScale = 1;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
            KillAllEnemies();
            StartCoroutine(Victory());
    
        }

        if (Input.GetKeyDown(KeyCode.Escape)&&player.isLive!=false)
        {
            if (!isPauseOpen)
            {
                pause.OpenPausePanel();
            }
            else
            {
                pause.OnResumeGame();
                setting.gameObject.SetActive(false);
            }
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
        GameObject[] allEnemyBullet = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject enemy in allEnemies)
        {
            enemy.GetComponent<Animator>().SetTrigger("Dead");
            enemy.layer = LayerMask.NameToLayer("DeadEnemy");
        }

        foreach(GameObject exploder in allExploder)
        {
            exploder.GetComponent<Exploder>().Dead();
            exploder.layer = LayerMask.NameToLayer("DeadEnemy");
        }

        foreach (GameObject staticEnemy in allStaticEnemy)
        {
            staticEnemy.GetComponent<Animator>().SetTrigger("Dead");
            staticEnemy.layer = LayerMask.NameToLayer("DeadEnemy");

        }
        foreach(GameObject enemyBullet in allEnemyBullet)
        {
            enemyBullet.gameObject.SetActive(false);
        }
    }

    IEnumerator Victory() //Make shell casings disappear automatically after being ejected for a period of time
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.settlement.GetComponent<Settlement>().WinTheGame();
        Stop();

    }

}
