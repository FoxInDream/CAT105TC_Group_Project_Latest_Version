using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectRoleFinal : MonoBehaviour
{
    public Transform roleSpawnPointRight;
    public Transform roleSpawnPointLeft;
    public Transform shadowSpawnPointRight;
    public Transform shadowSpawnPointLeft;
    public Vector3 zero = Vector3.zero;

    public GameObject[] roleDraw;
    public GameObject[] roleShadow;

    public float moveSpeed;

    public static int currentRoleIndex;
    public bool isPlayingAnim = false;
    public bool originRightToLeft = false;
    public bool originLeftToRight = false;
    public bool nextLeftToRight = false;
    public bool nextRightToLeft = false;

    private void Start()
    {
        
        currentRoleIndex = 0;
        moveSpeed = 20f;
        HideAll();
        Show();
        isPlayingAnim = false;
        originRightToLeft = false;
        originLeftToRight = false;
        nextLeftToRight = false;
        nextRightToLeft = false;
}

    private void Update()
    {
        EveryMovementLogic();
    }
    public void EveryMovementLogic()
    {
        if (originRightToLeft == true)
        {
            isPlayingAnim = true;
            OriginRightToLeft();
            if (roleDraw[currentRoleIndex].transform.localPosition == roleSpawnPointLeft.localPosition)
            {
                Hide();
                originRightToLeft = false;
                RightClickCount();
                Show();
                roleDraw[currentRoleIndex].transform.localPosition = roleSpawnPointRight.position;
                roleShadow[currentRoleIndex].transform.localPosition = shadowSpawnPointRight.position;
                nextRightToLeft = true;
            }
        }
        if (nextRightToLeft == true)
        {
            NextRightToLeft();
            if (roleDraw[currentRoleIndex].transform.localPosition == zero)
            {
                nextRightToLeft = false;
                isPlayingAnim = false;
            }
        }
        if (originLeftToRight == true)
        {
            isPlayingAnim = true;
            OriginLeftToRight();
            if (roleDraw[currentRoleIndex].transform.localPosition == roleSpawnPointRight.localPosition)
            {
                Hide();
                originLeftToRight = false;
                LeftClickCount();
                Show();
                roleDraw[currentRoleIndex].transform.localPosition = roleSpawnPointLeft.position;
                roleShadow[currentRoleIndex].transform.localPosition = shadowSpawnPointLeft.position;
                nextLeftToRight = true;
            }
        }
        if (nextLeftToRight == true)
        {
            NextLeftToRight();
            if (roleDraw[currentRoleIndex].transform.localPosition == zero)
            {
                nextLeftToRight = false;
                isPlayingAnim = false;
            }
        }
    }
    public void OnClickRightButton()
    {
        if (isPlayingAnim == false)
        {
            originRightToLeft = true;
        }
        else 
        { 
            return;
        }
}
    public void OnClickLeftButton()
    {
        if (isPlayingAnim == false)
        {
            originLeftToRight = true;
        }
        else
        {
            return;
        }
    }

    public void HideAll()
    {
        for (int i = 0; i < 3; i++)
        {
            roleDraw[i].gameObject.SetActive(false);
            roleShadow[i].gameObject.SetActive(false);
        }
    }
    public void Hide()
    {
        roleDraw[currentRoleIndex].gameObject.SetActive(false);
        roleShadow[currentRoleIndex].gameObject.SetActive(false);
    }
    public void Show()
    {
        roleDraw[currentRoleIndex].gameObject.SetActive(true);
        roleShadow[currentRoleIndex].gameObject.SetActive(true);
    }
    public void OriginRightToLeft()
    {
        roleDraw[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleDraw[currentRoleIndex].transform.localPosition, roleSpawnPointLeft.localPosition, moveSpeed * Time.deltaTime);
        roleShadow[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleShadow[currentRoleIndex].transform.localPosition, shadowSpawnPointLeft.localPosition, moveSpeed * 1.25f * Time.deltaTime);
    }

    public void NextRightToLeft()
    {
        roleDraw[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleDraw[currentRoleIndex].transform.localPosition, zero, moveSpeed * Time.deltaTime);
        roleShadow[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleShadow[currentRoleIndex].transform.localPosition, zero, moveSpeed * 1.25f * Time.deltaTime);
    }

    public void OriginLeftToRight()
    {
        roleDraw[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleDraw[currentRoleIndex].transform.localPosition, roleSpawnPointRight.localPosition, moveSpeed * Time.deltaTime);
        roleShadow[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleShadow[currentRoleIndex].transform.localPosition, shadowSpawnPointRight.localPosition, moveSpeed * 1.25f * Time.deltaTime);
    }
    
    public void NextLeftToRight()
    {
        roleDraw[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleDraw[currentRoleIndex].transform.localPosition, zero, moveSpeed * Time.deltaTime);
        roleShadow[currentRoleIndex].transform.localPosition = Vector3.MoveTowards(roleShadow[currentRoleIndex].transform.localPosition, zero, moveSpeed * 1.25f * Time.deltaTime);
    }
    public void RightClickCount()
    {
        if (currentRoleIndex < roleDraw.Length - 1)
        {
            currentRoleIndex++;
        }
        else
        {
            currentRoleIndex = 0;
        }
    }
    public void LeftClickCount()
    {
        if (currentRoleIndex > 0)
        {
            currentRoleIndex--;
        }
        else
        {
            currentRoleIndex = 2;
        }
    }
}


