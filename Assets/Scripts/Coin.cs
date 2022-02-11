using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]

public class Coin : MonoBehaviour
{


    [SerializeField] private GameObject soundObject;
    Audio audioClass;

    // Start is called before the first frame update
    void Start()
    {
        audioClass = soundObject.GetComponent<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameDirector.countCoin += 1;
            audioClass.CoinSE();
            Destroy(gameObject);
        }
    }
}
