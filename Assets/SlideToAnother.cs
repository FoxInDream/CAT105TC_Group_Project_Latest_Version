using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlideToAnother : MonoBehaviour
{
    public class RoleData
    {
        public RectTransform roleRoot;

        public RectTransform mainImage;
        public RectTransform shadowImage;

        public string roleName;
        [TextArea]
        public string description;
    }

    public RoleData[] roles;

    public TMP_Text nameText;
    public TMP_Text descText;

    public float slideTime = 0.5f;

    private int currentIndex = 0;
    private bool isSliding = false;

    Vector2 centerPos = Vector2.zero;
    Vector2 leftPos = new Vector2(-1600, 0);
    Vector2 rightPos = new Vector2(1600, 0);

    void Start()
    {
        InitRoles();
        UpdateText();
    }

    void InitRoles()
    {
        for (int i = 0; i < roles.Length; i++)
        {
            if (i == currentIndex)
            {
                roles[i].roleRoot.anchoredPosition = centerPos;
            }
            else
            {
                roles[i].roleRoot.anchoredPosition = rightPos;
            }
        }
    }

    public void RightButton()
    {
        if (!isSliding)
        {
            StartCoroutine(Slide(1));
        }
    }

    public void LeftButton()
    {
        if (!isSliding)
        {
            StartCoroutine(Slide(-1));
        }
    }

    IEnumerator Slide(int dir)
    {
        isSliding = true;

        int nextIndex = currentIndex + dir;

        if (nextIndex >= roles.Length)
            nextIndex = 0;

        if (nextIndex < 0)
            nextIndex = roles.Length - 1;

        RoleData current = roles[currentIndex];
        RoleData next = roles[nextIndex];

        // 初始化下一个角色位置
        next.roleRoot.anchoredPosition =
            dir > 0 ? rightPos : leftPos;

        float timer = 0;

        Vector2 currentTarget =
            dir > 0 ? leftPos : rightPos;

        Vector2 nextStart =
            dir > 0 ? rightPos : leftPos;

        while (timer < slideTime)
        {
            timer += Time.deltaTime;

            float t = timer / slideTime;

            // 平滑
            t = Mathf.SmoothStep(0, 1, t);

            // 当前角色离开
            current.roleRoot.anchoredPosition =
                Vector2.Lerp(centerPos, currentTarget, t);

            // 新角色进入
            next.roleRoot.anchoredPosition =
                Vector2.Lerp(nextStart, centerPos, t);

            // Shadow 延迟感
            current.shadowImage.anchoredPosition =
                Vector2.Lerp(Vector2.zero,
                    new Vector2(-150 * dir, 0),
                    t * 0.7f);

            next.shadowImage.anchoredPosition =
                Vector2.Lerp(
                    new Vector2(150 * dir, 0),
                    Vector2.zero,
                    t * 0.7f);

            yield return null;
        }

        current.roleRoot.anchoredPosition = currentTarget;
        next.roleRoot.anchoredPosition = centerPos;

        current.shadowImage.anchoredPosition = Vector2.zero;
        next.shadowImage.anchoredPosition = Vector2.zero;

        currentIndex = nextIndex;

        UpdateText();

        isSliding = false;
    }

    void UpdateText()
    {
        nameText.text = roles[currentIndex].roleName;
        descText.text = roles[currentIndex].description;
    }
}

