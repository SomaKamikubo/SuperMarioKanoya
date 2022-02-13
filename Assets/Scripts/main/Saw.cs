using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Enemy
{
    Vector3 position;
    [SerializeField] float speed;
    int direction;

    
    void Start()
    {
        position = transform.position;
        direction = 1;
        speed = 0.003f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        
        transform.Translate(direction * speed, 0, 0);
        float distance = transform.position.x - position.x;
        if(distance > 5f || distance < 0) {
            direction *= -1;
        }
    } 
}
