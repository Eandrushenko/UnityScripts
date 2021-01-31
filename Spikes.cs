using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        Player player = collision.gameObject.GetComponent<Player>();
        if (enemy != null)
        {
            enemy.TakeDamage(enemy.getMaxhealth());
        }
        else if (player != null)
        {
            player.TakeDamage(player.maxHealth);
        }
    }
}
