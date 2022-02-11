using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    public static int countCoin;
    [SerializeField] private Text coinText;

    [SerializeField] private AudioSource audio_main;
    [SerializeField] private AudioSource audio_title;
    [SerializeField] private AudioClip main_bgm;
    [SerializeField] private AudioClip title_bgm;


    void Start()
    {
        countCoin = 0;
        MainBGM();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Å~"+countCoin.ToString();
    }

    public void MainBGM()
    {
        audio_main.PlayOneShot(main_bgm);
    }
    public void TitleBGM()
    {
        audio_title.PlayOneShot(title_bgm);
    }
}
