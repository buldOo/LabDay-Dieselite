using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackSounds;
    private AudioSource Audio_attack;
    Animator m_Animator;

    private void Awake()
    {
        Audio_attack = GetComponent<AudioSource>();
    }

    void Start()
    {
        //Get the Animator, which you attach to the GameObject you intend to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        //Press the space bar to tell the Animator to trigger the Jump Animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Animator.SetTrigger("Attack");
            Audio_attack.PlayOneShot(attackSounds);
        }
    }
}