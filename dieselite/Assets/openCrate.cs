using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCrate : MonoBehaviour
{
    private Animator animator;
    private bool openingCrate;

    public bool isInRange;
    public GameObject crate;

    private void Start()
    {
        animator = crate.GetComponent<Animator>();
    }
    void Update()
    {
        if (isInRange && Input.GetKey(KeyCode.E)) {
            animator.SetBool("openingCrate", openingCrate);
            GameObject.Find("player").GetComponent<switchWeapon>().maxWeapon =+ 1;
            openingCrate = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

}

