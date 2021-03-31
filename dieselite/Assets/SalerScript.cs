using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalerScript : MonoBehaviour
{
    public bool isInRange;
    public GameObject shop;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if (isInRange && Input.GetKey(KeyCode.E))
        {
            Cursor.visible = true;
            player.GetComponent<playerMovement>().enabled = false;
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            shop.SetActive(true);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("isInRange true");
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("is in range false");
            isInRange = false;
        }
    }
}
