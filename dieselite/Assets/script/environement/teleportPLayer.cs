using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportPLayer : MonoBehaviour
{
    public GameObject player;
    public GameObject teleportEnd;
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
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        player.GetComponent<playerMovement>().enabled = false;
        yield return new WaitForSeconds(0.50F);
        player.transform.position = new Vector2(teleportEnd.transform.position.x, teleportEnd.transform.position.y);
        player.GetComponent<playerMovement>().enabled = true;
    }
}
