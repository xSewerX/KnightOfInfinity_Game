using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxDamage : MonoBehaviour
{
    public GameObject trollobject;
    private EnemyTroll enemytroll;
   

    void Start()
    {
        enemytroll = trollobject.GetComponent<EnemyTroll>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Player>().TakeDamage(enemytroll.damage);
        }
    }
}
