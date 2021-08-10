using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegen : MonoBehaviour
{
    public int heal = 1;

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Player>().Heal(heal);
            Destroy(gameObject);
        }
    }
}
