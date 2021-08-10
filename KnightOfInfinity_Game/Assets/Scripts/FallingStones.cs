using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStones : MonoBehaviour
{
    float StartTime;
    public float RepeatTimePerSecond;
    public float delay;
    public GameObject Stone;
    float repeatNumber = 0;
    //public int stonesnumber;
    int number;
   
    void Start()
    {
         number = Random.Range(0, 11);
        //repeatNumber = stonesnumber;
    }
    void Update()
    {
        if(Time.time >= StartTime)
        {
            
            if (repeatNumber < number)
            {
                Falling();
                repeatNumber++;
            }
            else
            {

                int number1 = Random.Range(0, 11);
                //Debug.Log(number);
                if (number1 == 8)
                {
                    repeatNumber = 0;
                }
            }
            StartTime = Time.time + 1f / RepeatTimePerSecond;

            
        }
    }

    void Falling()
    {
        
            GameObject fallingstone = Instantiate(Stone, transform.position, transform.rotation) as GameObject;
            Destroy(fallingstone, delay);
           
        
    }
}

