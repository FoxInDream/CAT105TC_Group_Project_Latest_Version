using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Welcome to the Game Management System, which streamlines cross-object script referencing and enables various global control functionalities.
    [Header("Components")]
    public Player player;
    public PoolManager poolManager;
    public Rifle rifle;
    public LevelUpSystem levelUpSystem;
    public Spawner spawner;
    public static GameManager instance; //Static members can be accessed from other scripts without creating an instance.
    [Header("Variables")]
    public int kill;
    public float timer;
    private void Awake()
    {
        kill = 0;
        timer = 300;
        instance = this; 
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 0;
        }
    }
    public void Stop()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }


}
