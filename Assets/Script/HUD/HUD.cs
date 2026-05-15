using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // Used to manage the display of various in-game values, including player HP, level and kill count
    public enum InfomationType
    {
        Reload,
        Exp,
        Level,
        Kill,
        TotalTimer,
        Heart,
        DamageNumber,
        Score
    }
    public InfomationType type;
    public float damageNumber;
    private Text uiText;
    private Slider uiSlider;
    private float lifeTimer;
    private GameObject poolManager;
  
    
    private void Awake()
    {
       uiText = GetComponentInChildren<Text>();
       uiSlider = GetComponentInChildren<Slider>(true);
       poolManager= GameObject.Find("PoolManager");
    }
    private void OnEnable()
    {
        lifeTimer = 0.9f;
    }
    private void LateUpdate()
    {
        switch (type)
        {
            case InfomationType.Reload:
                int currentBullet = GameManager.instance.rifle.currentbulletNumber;
                int maxBullet = GameManager.instance.rifle.maxBulletNumber;
                uiText.text = string.Format("{0}/{1}", currentBullet, maxBullet);
                if (GameManager.instance.rifle.isReload)
                {
                    uiSlider.gameObject.SetActive(true);
                    float progress = (GameManager.instance.rifle.maxReloadTime - GameManager.instance.rifle.reloadTimer) / GameManager.instance.rifle.maxReloadTime;
                    uiSlider.value = progress;
                }
                else
                {
                    uiSlider.gameObject.SetActive(false);
                }
                break;


            case InfomationType.Exp:
                float currentExp= GameManager.instance.player.currentExp;
                float maxExp= GameManager.instance.player.maxExp;
                uiSlider.value = currentExp / maxExp;
                break;

            case InfomationType.Level:
                uiText.text = string.Format("Lv. {0:F0}", GameManager.instance.player.level);
                break;


            case InfomationType.TotalTimer:
                if (GameManager.instance.timer<= 30)
                {
                    uiText.color = Color.red; 
                }
                else
                {
                    uiText.color = Color.white; 
                }


                int minutes = Mathf.FloorToInt(GameManager.instance.timer / 60);
                int seconds = Mathf.FloorToInt(GameManager.instance.timer % 60);
                uiText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
                break;

            case InfomationType.Kill:
                uiText.text = string.Format("{0}", GameManager.instance.kill);
                break;



            case InfomationType.Heart:
                uiText.text = string.Format("{0}/{1}", GameManager.instance.player.currentHP, GameManager.instance.player.maxHP);
                break;


            case InfomationType.DamageNumber:
                if(lifeTimer>0)
                {
                    lifeTimer-=Time.deltaTime;
                    transform.position += new Vector3(0, 2 * Time.deltaTime, 0);
                    uiText.text = string.Format("{0}", damageNumber);
                }
                else
                {
                    gameObject.SetActive(false);
                    transform.SetParent(poolManager.transform);
                }
                break;
            case InfomationType.Score:
                if (GameManager.instance != null && GameManager.instance.player != null)
                {
                    int score = GameManager.instance.kill + GameManager.instance.player.level*1000;
                    uiText.text = string.Format("{0}", score);
                }
                else
                {
                    uiText.text = "0"; 
                }
                break;

        }

    }
}
