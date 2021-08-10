using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Teleport : MonoBehaviour
{
    public Animator fadeout;
    public GameObject Camera1;
    public GameObject Camera2;
    public Transform Player;
    public Transform Spawn;
    private bool canTeleport;
    public GameObject Information;

    void Update()
    {
        if (canTeleport)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canTeleport = false;
                fadeout.SetTrigger("Start");
                StartCoroutine(Transition(1));
                Camera1.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Information.SetActive(true);
             canTeleport = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Information.SetActive(false);
            canTeleport = false;
        }
    }
    IEnumerator Transition(float time)
    {
        yield return new WaitForSeconds(time);

        
        Camera2.SetActive(true);
        Player.position = Spawn.position;

        fadeout.SetTrigger("End");
    }

}