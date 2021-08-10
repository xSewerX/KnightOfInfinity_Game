using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrystalWrath : MonoBehaviour
{
    public float speed;
    //public float stopDistance;

    private Transform target;
    public GameObject targetobject;
    private float attackcooldown;
    public float StartCooldown;
    //public GameObject Hitbox;
    private Animator anim;
    //public int damage;
    public Transform PlayerObject;
    //public GameObject Firecone;
    public GameObject Fire;
    private GameObject WarningFire;
    

    void Start()
    {
        Physics2D.IgnoreCollision(PlayerObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        anim = GetComponent<Animator>();
        target = targetobject.GetComponent<Transform>();
        // attackcooldown = StartCooldown;
        //  attackcooldown = 0;
    }

    void Update()
    {
            
        
        Vector2 targetposition = new Vector2(target.position.x, transform.position.y);
       // if (Vector2.Distance(transform.position, target.position) > stopDistance)
       // {

            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
      //  }
       // else if (Vector2.Distance(transform.position, target.position) <= stopDistance)
        //{
            if (attackcooldown <= 0)
            {
                WarningFire = Instantiate(Fire, PlayerObject.position, Quaternion.identity) as GameObject;
                attackcooldown = StartCooldown;
                Destroy(WarningFire, 5f);
            // Invoke("FireconeBlow", 2f);
            // BigFire = GameObject.FindGameObjectWithTag("FireCone").GetComponent<Transform>();
        }
            else
            {
                attackcooldown -= Time.deltaTime;
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
        //public void Damage(int amount)
        // {
        //     damage += amount;
        // }
       // void FireconeBlow()
   // {
        
    //    Destroy(WarningFire, 3f);
  //  }
    
}