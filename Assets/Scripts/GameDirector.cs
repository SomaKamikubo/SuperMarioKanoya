using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public static int countCoin;
    [SerializeField] private Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        countCoin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Å~"+countCoin.ToString();
    }
}
