using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerLevelBuff;

public class PlayerLevelBuff : MonoBehaviour
{
    public  enum BuffName
    {
        BulletPlus, 
        DamagePlus,
        HeartPlus,
        FireRatePlus,
        ReloadRatePlus,
        RecoverFullHP
    }


    public BuffName buffName;
    public bool isMax;
    private Text levelText;
    private int level;

    private void Awake()
    {
        level = 1;
        levelText = GetComponentInChildren<Text>();
    }

    private void LateUpdate()
    {
        levelText.text = string.Format("Lv.{0:D2}", level);
    }
    public void OnClick()
    {
        switch(buffName)
        {
            case BuffName.BulletPlus:
                GameManager.instance.rifle.maxBulletNumber += 5;
                GameManager.instance.rifle.currentbulletNumber = GameManager.instance.rifle.maxBulletNumber;
                GameManager.instance.rifle.isReload = false;
                level++;
                break;


            case BuffName.DamagePlus:
                GameManager.instance.rifle.bulletDamage += 5;
                level++;
                break;


            case BuffName.HeartPlus:
                GameManager.instance.player.maxHP += 1;
                level++;
                break;


            case BuffName.FireRatePlus:
                GameManager.instance.rifle.interval -= 0.1f;
                level++;
                break;


            case BuffName.ReloadRatePlus:
                GameManager.instance.rifle.maxReloadTime -= 0.2f;
                level++;
                break;


            case BuffName.RecoverFullHP:
                GameManager.instance.player.currentHP = GameManager.instance.player.maxHP;
                break;
        }


        switch (buffName) 
        {
            case BuffName.BulletPlus:
            case BuffName.DamagePlus:
            case BuffName.HeartPlus:
            case BuffName.FireRatePlus:
            case BuffName.ReloadRatePlus:
                if(level==6)
                {
                    GetComponent<Button>().interactable = false;
                    isMax=true;
                }

                break;

            case BuffName.RecoverFullHP: //HP restoration has no level cap. After all skills are fully upgraded, the HP recovery upgrade buff remains selectable
                break;
        }

    }
}
