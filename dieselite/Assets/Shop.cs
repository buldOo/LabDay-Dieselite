using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shop;
    public GameObject player;

    public void Quit()
    {
        player.GetComponent<playerMovement>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        shop.SetActive(false);
    }

    public void buy()
    {
            
    }
}
