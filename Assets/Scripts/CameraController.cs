using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(GameObject))]


public class CameraController : MonoBehaviour
{
    private Camera _mainCamera;

    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject background;
    float limLeft;
    float midlePoint;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 backPos = background.transform.position;
        float width = background.GetComponent<SpriteRenderer>().bounds.size.x;
        limLeft = backPos.x - width / 2;

        Vector3 cameraPos = transform.position;
        Vector3 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
        float halfWidth = Mathf.Abs(cameraPos.x - screen_LeftBottom.x);
        midlePoint = limLeft + halfWidth;

        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(midlePoint, transform.position.y, transform.position.z);

       



    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = player.transform.position;
        Vector3 cameraPos = transform.position;
        Vector3 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);

        if(screen_LeftBottom.x >= limLeft && playerPos.x >= midlePoint)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
        }
       
    }
}
