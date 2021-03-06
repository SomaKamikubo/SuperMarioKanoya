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
    float limRight;
    float midlePoint;
    float midlePoint2;
    float playerYDist;
    float pastYDist;
    Vector3 playerPos;
    Vector3 cameraPos;


    bool moveFlag;
    float distance, startTime;
    Vector3 startPos, targetPos;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 backPos = background.transform.position;
        float width = background.GetComponent<SpriteRenderer>().bounds.size.x;
        limLeft = backPos.x - width / 2;
        limRight = limLeft + width * 4;
        

        cameraPos = transform.position;
        Vector3 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
        float halfWidth = Mathf.Abs(cameraPos.x - screen_LeftBottom.x);
        midlePoint = limLeft + halfWidth;
        midlePoint2 = limRight - halfWidth;

        playerPos = player.transform.position;
        transform.position = new Vector3(midlePoint, transform.position.y, transform.position.z);

        playerYDist = transform.position.y - playerPos.y;
        pastYDist = playerYDist;


        //InvokeRepeating(nameof(sameY), 1.0f, 1.0f);

        startTime = Time.time;
        moveFlag = false;
        distance = Mathf.Abs(transform.position.y - (playerPos.y + 3.2f));
        startPos = transform.position;
        targetPos = new Vector3(startPos.x, playerPos.y + 3.2f, startPos.z);


    }

    // Update is called once per frame
    void Update()
    {

        playerPos = player.transform.position;
        cameraPos = transform.position;
        Vector3 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 screen_RightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        playerYDist = transform.position.y - playerPos.y;


        
        if ((screen_LeftBottom.x >= limLeft && playerPos.x >= midlePoint) && (screen_RightTop.x <= limRight && playerPos.x <= midlePoint2))
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);

        }

        


        Ymove();

    }

    void Ymove()
    {


        if (playerPos.y < -3)
            return;

        if (playerYDist < 0)
        {
            transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
        }

        if(playerYDist > 3.2)
        {
            transform.position = new Vector3(transform.position.x, playerPos.y + 3.2f, transform.position.z);
        }


    }

    void sameY()
    {
        distance = Mathf.Abs(transform.position.y - (playerPos.y + 3.2f));

        if (Mathf.Abs(pastYDist - playerYDist) < 0.001 && distance > 0.1)
        {
            transform.position = new Vector3(transform.position.x, playerPos.y + 3.2f, transform.position.z);
        }

        pastYDist = playerYDist;
    }
}
