using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRePosition : MonoBehaviour
{
    // Used to reset monsters that are too far away from the player

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("FlyEnemy"))
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Enemy") || collision.CompareTag("Exploder") || collision.CompareTag("Static Enemy"))
        {
            Vector2 transformDirection=(GameManager.instance.player.transform.position-collision.transform.position).normalized;
            collision.transform.Translate(transformDirection * 28 + new Vector2(Random.Range(1f, -1f), Random.Range(1f, -1f))); // Move in front of the player's movement direction, just outside the camera view
        }
    }
}
