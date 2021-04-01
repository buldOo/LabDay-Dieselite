using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsDestruct : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("player").GetComponent<playerCoins>().Coins += Random.Range(5, 5); ;
            Destroy(gameObject);
        }
    }
}
