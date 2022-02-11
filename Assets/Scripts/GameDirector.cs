using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{

    public static int countCoin;
    [SerializeField] private Text coinText;

    [SerializeField] private AudioSource audio_main;
    [SerializeField] private AudioSource audio_title;
    [SerializeField] private AudioClip main_bgm;
    [SerializeField] private AudioClip title_bgm;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject soundObject;
    private Audio audioClass;
    private AudioSource audioInfo;

    private bool SEcontrol = false;


    void Start()
    {
        countCoin = 0;
        MainBGM();
        audioClass = soundObject.GetComponent<Audio>();
        audioInfo = soundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Å~"+countCoin.ToString();
        if (PlayerController.dieFlag)
        {
            if (!SEcontrol)
            {
                audioClass.DeathSE();
                SEcontrol = true;
                Player.SetActive(false);
            }

            if (!audioInfo.isPlaying)
            {
                SceneManager.LoadScene("main");
            }

            return;
        }
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
