using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(GameObject))]


public class CameraController : MonoBehaviour
{
    private Camera _mainCamera;
    
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        if (playerPos.x > -10)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
        }
       
    }
}
