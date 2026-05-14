using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //Welcome to the Object Pool system. It optimizes stuttering caused by spawning or destroying a large number of objects in an instant.

    //Note
    // 0: Bullet
    // 1: Shell Casing
    // 2: Bullet Explosion Effect
    // 3: Goblin
    // 4: Experience Orb
    // 5: Bat
    // 6: Tree Monster
    // 7: Flying Jellyfish
    // 8: Jellyfish Bullet
    // 9: Damage Display UI
    // 10: Damaging Explosion
    // 11: Explosion Monster

    public GameObject[] prefabs;
    private List<GameObject>[] pools;
    public static PoolManager instance;   

    
    private void Awake()
    {

        instance = this;



        pools = new List<GameObject>[prefabs.Length]; //Initialize Object Pool

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index]) //Get object from pool, activate if exists, avoid new instantiation
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        
        if (!select)
        { 
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}
