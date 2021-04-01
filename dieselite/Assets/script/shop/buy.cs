using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy : MonoBehaviour
{
    public int price;
    public Item item;

    void Start()
    {

    }

    void Update()
    {

    }

    public void checkCoins()
    {
        int playerCoins = GameObject.Find("player").GetComponent<playerCoins>().Coins;

        if (playerCoins >= price)
        {
            playerCoins = -price;
            GameObject.Find("player").GetComponent<playerCoins>().Coins -= price;

            Inventory.instance.content.Add(item);
            Inventory.instance.UpdateInventoryUI();
        }
        else
        {
            Debug.Log("vous n'avez pas asser d'argent");
        }
    }
}