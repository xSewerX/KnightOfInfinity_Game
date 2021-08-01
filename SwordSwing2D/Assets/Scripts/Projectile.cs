using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    public GameObject Explosion;
    public GameObject Ball;
    public float time = 0.5f;

    public GameObject wizardobject;
    private EnemyWizard enemywizard;
    private Player playerscript;
    //public int damage = 10;

    void Start()
    {
        enemywizard = wizardobject.GetComponent<EnemyWizard>();

        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }


    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
       
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Explosion.SetActive(true);
            Ball.SetActive(false);
            StartCoroutine(Destroy(time));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("Ground"))
        {
            Explosion.SetActive(true);
            Ball.SetActive(false);
            StartCoroutine(Destroy(time));
            speed = 0;
        }
        if (other.CompareTag("Player"))
        {
            Explosion.SetActive(true);
            Ball.SetActive(false);
            StartCoroutine(Destroy(time));
            speed = 0;

            playerscript.TakeDamage(enemywizard.damage);
        }

    }
   // public void AddDamage(int amount)
   // {
     //   damage += amount;
     //   Debug.Log("Dodano dmg");
   // }
    IEnumerator Destroy(float time)
    {
       yield return new WaitForSeconds(time);
       Destroy(gameObject);
    }
}
