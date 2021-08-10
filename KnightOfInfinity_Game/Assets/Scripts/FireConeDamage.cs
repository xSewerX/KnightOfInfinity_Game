using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireConeDamage : MonoBehaviour
{
    public int damage;
    private Animator anim;
    void start()
    {
        anim = GetComponent<Animator>();
        Invoke("ChangeAnimation", 2f);
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Player>().TakeDamage(damage);
        }
        
    }
    void ChangeAnimation()
    {
        anim.SetBool("Firecone", true);
    }
}
