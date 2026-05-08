using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapReposition : MonoBehaviour
{
    private Vector3 playerPosition;
    private float differenceX;
    private float differenceY;
    private float directionX;
    private float directionY;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            playerPosition = GameManager.instance.player.transform.position;
            differenceX = playerPosition.x - collision.transform.position.x;
            differenceY = playerPosition.y - collision.transform.position.y;

            directionX = differenceX < 0 ? -1 : 1;
            directionY = differenceY < 0 ? -1 : 1;

            differenceX = Mathf.Abs(differenceX);
            differenceY = Mathf.Abs(differenceY);
            if (differenceX > differenceY)
            {
                collision.transform.Translate(Vector3.right * directionX * 80);
            }
            else if (differenceX < differenceY)
            {
                collision.transform.Translate(Vector3.up * directionY * 80);
            }
        }
    }
}
