using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]

public class Coin : MonoBehaviour
{

    [SerializeField] private GameObject soundObject;
    Audio audioClass;

    void Start()
    {
        audioClass = soundObject.GetComponent<Audio>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioClass.CoinSE();
            GameDirector.countCoin += 1;
            Destroy(gameObject);
        }
    }
}
