using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroll : MonoBehaviour
{
    public float speed;
    public float stopDistance;

    private Transform target;

    private float attackcooldown;
    public float StartCooldown;
    public GameObject Hitbox;
    private Animator anim;
    public int damage;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attackcooldown = StartCooldown;
        attackcooldown = 0;
    }

    void Update()
    {
        

        Vector2 targetposition = new Vector2(target.position.x, transform.position.y);
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) <= stopDistance)
        {
            if (attackcooldown <= 0)
            {
                anim.SetTrigger("Attack");
                attackcooldown = StartCooldown;
                Debug.Log("Troll attack!");
            }
            else
            {
                attackcooldown -= Time.deltaTime;
            }

        }
        Flip();
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }
        transform.eulerAngles = rotation;
    }
    public void Damage(int amount)
    {
        damage += amount;
    }
}

