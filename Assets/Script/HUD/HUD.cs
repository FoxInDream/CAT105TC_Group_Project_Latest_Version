using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfomationType
    {
        Reload,
        Exp,
        Level,
        Kill,
        TotalTimer,
        Heart
    }
    public InfomationType type;
    private Text uiText;
    private Slider uiSlider;

    private void Awake()
    {
       uiText = GetComponentInChildren<Text>();
       uiSlider = GetComponentInChildren<Slider>(true);
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

        }

    }
}
