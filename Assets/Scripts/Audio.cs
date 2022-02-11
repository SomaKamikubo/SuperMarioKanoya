using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip coin;
    [SerializeField] private AudioClip death;

    public static bool finishSE;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        finishSE = false;
    }


    public void JumpSE()
    {
        audioSource.PlayOneShot(jump);
    }
    public void CoinSE()
    {
        audioSource.PlayOneShot(coin);
    }
    public void DeathSE()
    {
        audioSource.PlayOneShot(death);
        if (!audioSource.isPlaying)
        {
            finishSE = true;
        }
    }

}
