using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 0.01f;
    float loop_number = 38.38f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed, 0, 0);

        if(transform.position.x <= -19.19)
        {
            transform.position = new Vector3(loop_number, 0, 0);
        }
    }
}
