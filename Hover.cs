using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    const string DOWNKEY = "Down";
    const string UPKEY = "Up";
  

    [SerializeField] private float lowHover;
    [SerializeField] private float highHover;
    [SerializeField] private float speedTopRange;
    [SerializeField] private float speedLowRange;
    [SerializeField] private float speed;
    private string direction = DOWNKEY;

    [SerializeField] private Vector3 posDif;

    private float currentYPos;
    // Start is called before the first frame update
    void Start()
    {
        currentYPos = transform.position.y;
        lowHover = currentYPos - lowHover;
        highHover = currentYPos + highHover;

        speed = Random.Range(speedLowRange, speedTopRange);
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == DOWNKEY) 
        {
            if(transform.position.y < lowHover) 
            {
                direction = UPKEY;
                return; 
            }

            //   transform.position =  new Vector3(transform.parent.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z); 
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y - (speed * Time.deltaTime), transform.parent.position.z);
        }
        else 
        {

            if (transform.position.y > highHover)
            {
                direction = DOWNKEY;
                return;
            }

            //  transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
              transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + (speed * Time.deltaTime), transform.parent.position.z);
        }
    }
}
