using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsNumber : MonoBehaviour
{
    public Text coinsText;
    private int coins;

    void Start()
    {
    }

    void Update()
    {
        coins = GameObject.Find("player").GetComponent<playerCoins>().Coins;
        coinsText.text = coins + "";
    }
}
