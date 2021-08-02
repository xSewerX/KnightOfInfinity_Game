using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDamage : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Player>().TakeDamage(damage);
        }
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
