using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //欢迎来到对象池，该系统可以用于优化因瞬间销毁太多物体或者生成太多物体而造成的卡顿问题

    //注 0是子弹，1是弹壳，2是爆炸效果，3是goblin，4是经验块,5是蝙蝠,6是地刺,7是飞行水母，8是水母的子弹
    public GameObject[] prefabs;
    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length]; //初始化对象池

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index]) //从对象池找相应的物体，有就直接激活，不需要在新生成了
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        {
        if (!select)
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}
