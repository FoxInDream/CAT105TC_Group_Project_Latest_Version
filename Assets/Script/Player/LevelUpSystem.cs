using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class LevelUpSystem : MonoBehaviour
{
    private RectTransform rect;
    private PlayerLevelBuff[] levelBuffs;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        levelBuffs = GetComponentsInChildren<PlayerLevelBuff>(true);

    }

    public void Show()
    {
        RandomBuff();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    private void RandomBuff()
    //Disable all buff at the start
    {
        foreach (PlayerLevelBuff buff in levelBuffs)
        {
            buff.gameObject.SetActive(false);
        }

        List<PlayerLevelBuff> availableLevelBuffs = new List<PlayerLevelBuff>();
        foreach(PlayerLevelBuff buff in levelBuffs)
        {
            if(!buff.isMax)
            {
                availableLevelBuffs.Add(buff);
            }
        }

        if(availableLevelBuffs.Count < 3)
        {
            foreach(PlayerLevelBuff buff in availableLevelBuffs)
            {
                buff.gameObject.SetActive(true);
            }
            return;
        }

        for(int i=0; i < availableLevelBuffs.Count; i++) //Shuffle the Buffs
        {
            int random=Random.Range(i, availableLevelBuffs.Count);
            PlayerLevelBuff buff = availableLevelBuffs[i];
            availableLevelBuffs[i] = availableLevelBuffs[random];
            availableLevelBuffs[random] = buff;
        }

        for(int i=0;i<3;i++) //Take the first three and display them
        {
            availableLevelBuffs[i].gameObject.SetActive(true);
        }
    }
}