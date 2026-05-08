using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRePosition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("FlyEnemy"))
        {
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.transform.Translate(GameManager.instance.player.moveDirection * 28 + new Vector2(Random.Range(1f, -1f), Random.Range(1f, -1f)));
        }
    }
}
