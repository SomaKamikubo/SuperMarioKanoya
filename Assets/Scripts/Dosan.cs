using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dosan : Enemy
{
    [SerializeField] private GameObject player;
    Vector3 myPos;
    [SerializeField] private float notice = 3f;
    [SerializeField] private float downSpeed = 0.003f;
    [SerializeField] private float upSpeed = 0.003f;
    bool canDown;
    bool downFlag;
    // Start is called before the first frame update
    void Start()
    {
        myPos = transform.position;
        canDown = true;
        downFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        float dist = Mathf.Abs(myPos.x - playerPos.x);
        if(dist < notice)
        {
            downFlag = true;
        }
        Move()
;    }

    void Move()
    {
        
        if (canDown)
        {
            if(downFlag)
            {
                transform.Translate(0, -1 * downSpeed, 0);
            }  
        }

        else
        {
            transform.Translate(0, upSpeed, 0);
            if (transform.position.y >= myPos.y)
            {
                canDown = true;
                downFlag = false;
            }
        }
        

    }



    new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Stage")
        {
            canDown = false;
        }
    }
}
