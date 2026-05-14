using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaReposition : MonoBehaviour
{
    private float totalWidth;
    // Map Reset System: Move map chunks by detecting player position
    private void Awake()
    {
        totalWidth = 3 *40;
    }

    public void Update()
    {
        Vector3 playerPosition = GameManager.instance.player.transform.position;
        Vector3 tempPosition=transform.position;
        if(playerPosition.x>transform.position.x+totalWidth*0.5)
        {

            tempPosition.x += totalWidth;
            transform.position = tempPosition;
        }
        else if (playerPosition.x < transform.position.x - totalWidth * 0.5)
        {
            tempPosition.x -= totalWidth;
            transform.position = tempPosition;
        }

        if(playerPosition.y>transform.position.y+totalWidth*0.5)
        {
            tempPosition.y += totalWidth;
            transform.position = tempPosition;
        }
        else if (playerPosition.y < transform.position.y - totalWidth * 0.5)
        {
            tempPosition.y -= totalWidth;
            transform.position = tempPosition;
        }

    }
}
