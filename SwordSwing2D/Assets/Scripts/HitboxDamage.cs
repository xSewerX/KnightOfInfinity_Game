using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxDamage : MonoBehaviour
{

    public int damage = 1;

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
