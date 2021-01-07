using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackSounds;
    public Animator animator;
    private AudioSource Audio_attack;

    // Awake is used to set variable before the game start
    private void Awake()
    {
        Audio_attack = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Attack();
            Audio_attack.PlayOneShot(attackSounds);
        }
    }

    void Attack() 
    {
        // play attack animation
        animator.SetTrigger("Attack");
    }

}
