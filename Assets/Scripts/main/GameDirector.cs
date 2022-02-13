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
    private bool firstSE = false;


    void Start()
    {
        MainBGM();
        countCoin = 0;
        audioClass = soundObject.GetComponent<Audio>();
        audioInfo = soundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "ÉRÉCÉìÅ@Å~"+countCoin.ToString();


        if (isPlayerDie())
        {
            DeathProcess();
        }
    }

    void MainBGM()
    {
        audio_main.PlayOneShot(main_bgm);
    }
    void TitleBGM()
    {
        audio_title.PlayOneShot(title_bgm);
    }

    void DeathProcess()
    {
        if (!firstSE)
        {
            audioClass.DeathSE();
            firstSE = true;
            Player.SetActive(false);
        }

        if (!audioInfo.isPlaying)
        {
            SceneManager.LoadScene("main");
        }
    }

    bool isPlayerDie()
    {
        if (Player.transform.position.y < -6)
        {
            return true;
        }
        if (PlayerController.dieFlag)
        {
            return true;
        }
        return false;
    }
}
