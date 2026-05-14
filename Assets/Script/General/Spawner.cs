using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner : MonoBehaviour
{
    public enum MonsterType

    {
        Goblin = 3,
        Bat = 5,
        TreeMonster = 6,
        FlotingJellyfish = 7,
        Exploder=11
    }


    [Header("Variable")]
    public int treeMonsterCount; //Calculates enemy count, stops spawning when reaching the limit
    public int treeSafeRadius=6;
    [Header("Spawn Point")]
    private Transform maxSpawnPoint;
    private Transform minSpawnPoint;
    [Header("Timer")]
    public float levelTimer;
    private float spawnTimer1;
    private float spawnTimer2;
    private float spawnTimer3;
    private float spawnTimer4;

    public int level;
    private void Awake()
    {
        level = 1;
        maxSpawnPoint = transform.Find("MaxPoint");
        minSpawnPoint = transform.Find("MinPoint");

    }
    private void Update()
    {
        if(GameManager.instance.timer>0)
        {
            Spawn();
        }
      
    }
    private void Spawn() //Spawn Order Logic	
    {
        spawnTimer1 += Time.deltaTime;
        spawnTimer2 += Time.deltaTime;
        spawnTimer3 += Time.deltaTime;
        spawnTimer4 += Time.deltaTime;

        if (level < 8)
        {
            levelTimer += Time.deltaTime;
            if (levelTimer > 30)
            {
                levelTimer = 0;
                spawnTimer1 = 0;
                spawnTimer2 = 0;
                spawnTimer3 = 0;
                spawnTimer4 = 0;
                level++;
            }
        }

        switch (level)
        {
            case 1:


                if (spawnTimer1 > 2)
                {
                    spawnTimer1 = 0;

                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(10, 3, 1); //Parameter:  maxHealth, Speed, Damage
                    goblin.transform.position = SpawnPonit();
                    spawnTimer4 = 0;
                }
                break;





            case 2:

                if (spawnTimer1 > 1.5)
                {

                    spawnTimer1 = 0;
                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(15, 3, 1);
                    goblin.transform.position = SpawnPonit();
                }
                break;





            case 3:
                if (spawnTimer1 > 1)
                {
                    spawnTimer1 = 0;
                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(15, 3, 1);
                    goblin.transform.position = SpawnPonit();
                }



                if (spawnTimer2 > 12)
                {
                    spawnTimer2 = 0;
                    SpawnCluster((int)MonsterType.Bat, 10, 6, 1);//Parameter: Prefab Index, maxHealth, Speed, Damage
                }

                break;






            case 4:
                if (spawnTimer1 > 1)
                {
                    spawnTimer1 = 0;
                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(20, 3, 1);
                    goblin.transform.position = SpawnPonit();
                }

                if (spawnTimer2 > 10)
                {
                    spawnTimer2 = 0;
                    SpawnCluster((int)MonsterType.Bat, 15, 6, 1);//Parameter: Prefab Index, maxHealth, Speed, Damage
                }
                break;






            case 5:
                if (spawnTimer1 > 1)
                {
                    spawnTimer1 = 0;
                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(20, 3, 1);
                    goblin.transform.position = SpawnPonit();
                }

                if (spawnTimer2 > 7)
                {
                    spawnTimer2 = 0;
                    SpawnCluster((int)MonsterType.Bat, 15, 7, 1);//Parameter: Prefab Index, maxHealth, Speed, Damage
                }


                if (spawnTimer3 > 7)
                {
                    spawnTimer3 = 0;
                    GameObject jellyfish = PoolManager.instance.Get((int)MonsterType.FlotingJellyfish);
                    jellyfish.GetComponent<Goblin>().Init(15, 3, 1); //Parameter:  maxHealth, Speed, Damage
                    jellyfish.transform.position = SpawnPonit();
                }
                break;





            case 6:
                if (spawnTimer1 > 1)
                {
                    spawnTimer1 = 0;
                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(20, 3.5f, 1);
                    goblin.transform.position = SpawnPonit();
                }

                if (spawnTimer2 > 7)
                {
                    spawnTimer2 = 0;
                    SpawnCluster((int)MonsterType.Bat, 20, 7, 1);//Parameter: Prefab Index, maxHealth, Speed, Damage
                }


                if (spawnTimer3 > 6.5)
                {
                    spawnTimer3 = 0;
                    GameObject jellyfish = PoolManager.instance.Get((int)MonsterType.FlotingJellyfish);
                    jellyfish.GetComponent<Goblin>().Init(20, 3, 1); //Parameter:  maxHealth, Speed, Damage
                    jellyfish.transform.position = SpawnPonit();
                }

                break;






            case 7:

                if (spawnTimer1 > 1)
                {
                    spawnTimer1 = 0;
                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(25, 3.5f, 1);
                    goblin.transform.position = SpawnPonit();
                }

                if (spawnTimer2 > 6)
                {
                    spawnTimer2 = 0;
                    SpawnCluster((int)MonsterType.Bat, 20, 7, 1);//Parameter: Prefab Index, maxHealth, Speed, Damage

                    if (treeMonsterCount <= 5)
                    {
                        GameObject TreeMonster = PoolManager.instance.Get((int)MonsterType.TreeMonster);
                        TreeMonster.GetComponent<Goblin>().Init(30, 0, 1);
                        TreeMonster.transform.position = GetSafeSpawnPoint();
                        treeMonsterCount++;
                    }
                }

                if (spawnTimer3 > 6)
                {
                    spawnTimer3 = 0;
                    GameObject jellyfish = PoolManager.instance.Get((int)MonsterType.FlotingJellyfish);
                    jellyfish.GetComponent<Goblin>().Init(20, 3, 1); //Parameter:  maxHealth, Speed, Damage
                    jellyfish.transform.position = SpawnPonit();
                }

                break;





            case 8:

                if (spawnTimer1 > 1)
                {
                    spawnTimer1 = 0;
                    GameObject goblin = PoolManager.instance.Get((int)MonsterType.Goblin);
                    goblin.GetComponent<Goblin>().Init(25, 3.5f, 1);
                    goblin.transform.position = SpawnPonit();
                }

                if (spawnTimer2 > 5)
                {
                    spawnTimer2 = 0;
                    SpawnCluster((int)MonsterType.Bat, 20, 7, 1);//Parameter: Prefab Index, maxHealth, Speed, Damage

                    if (treeMonsterCount <= 5)
                    {
                        GameObject TreeMonster = PoolManager.instance.Get((int)MonsterType.TreeMonster);
                        TreeMonster.GetComponent<Goblin>().Init(40, 0, 1);
                        TreeMonster.transform.position = GetSafeSpawnPoint();
                        treeMonsterCount++;
                    }
                }

                if (spawnTimer3 > 5)
                {
                    spawnTimer3 = 0;
                    GameObject jellyfish = PoolManager.instance.Get((int)MonsterType.FlotingJellyfish);
                    jellyfish.GetComponent<Goblin>().Init(20, 3, 1); //Parameter:  maxHealth, Speed, Damage
                    jellyfish.transform.position = SpawnPonit();
                }

                if (spawnTimer4 > 10)
                {
                    spawnTimer4 = 0;
                    GameObject exploder = PoolManager.instance.Get((int)MonsterType.Exploder);
                    exploder.GetComponent<Goblin>().Init(15, 4, 0); //Parameter:  maxHealth, Speed, Damage
                    exploder.transform.position = SpawnPonit();
                }

                break;

        }
    }

    private Vector3 SpawnPonit()
    {
        Vector3 spawnPoint = Vector3.zero;
        if (Random.Range(0f, 1f) > 0.5f)
        {
            spawnPoint.x = Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x);
            if (Random.Range(0f, 1f) > 0.5f)
                spawnPoint.y = minSpawnPoint.position.y;
            else
                spawnPoint.y = maxSpawnPoint.position.y;
        }
        else
        {
            spawnPoint.y = Random.Range(minSpawnPoint.position.y, maxSpawnPoint.position.y);
            if (Random.Range(0f, 1f) > 0.5f)
                spawnPoint.x = minSpawnPoint.position.x;
            else
                spawnPoint.x = maxSpawnPoint.position.x;

        }
        return spawnPoint;
    }










    private void SpawnCluster(int mosterPrefab, float maxHealth, float speed, int damage) //Batch spawn clustered Monster
    {
        int waveCount = 25;
        Vector3 spawnPosition = SpawnPonit();
        for (int i = 0; i < waveCount; i++)
        {
            GameObject moster = PoolManager.instance.Get(mosterPrefab);

            moster.GetComponent<Goblin>().Init(maxHealth, speed, damage);


            spawnPosition.x += Random.Range(-0.3f, 0.3f);
            spawnPosition.y += Random.Range(-0.3f, 0.3f);

            moster.transform.position = spawnPosition;
            moster.GetComponent<Goblin>().moveDirection = (GameManager.instance.player.transform.position - moster.transform.position).normalized;
        }

    }



    private Vector3 GetSafeSpawnPoint()
    {
        while (true) 
        {
            Vector3 randomPos = SpawnPonit();


            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(randomPos, treeSafeRadius);
            bool hasTreeMonster = false;

            foreach (Collider2D col in hitColliders)
            {
                if (col.CompareTag("Static Enemy"))
                {
                    hasTreeMonster = true;
                    break;
                }
            }

            if (!hasTreeMonster)
            {
                return randomPos;
            }
        }
    }
}


