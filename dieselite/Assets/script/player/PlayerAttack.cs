using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackSounds;
    public GameObject Bullet;
    public Transform ShootPoint;
    public float BulletSpeed;
    public float FireRate;

    private AudioSource Audio_attack;

    private Animator animator;
    private bool isAttacking;
    public float timeBeforeDestroy;

    float ReadyForNextShot;

    private void Awake()
    {
        Audio_attack = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        //Get the Animator, which you attach to the GameObject you intend to animate.
        animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        animator.SetBool("isAttacking", isAttacking);

        //Press the left click to tell the Animator to trigger the Jump Animation
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(ExampleCoroutine());
        }

    }

    IEnumerator ExampleCoroutine()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.3F);

        if (Time.time > ReadyForNextShot)
        {

            ReadyForNextShot = Time.time + 1 / FireRate;

            //GameObject FlashShoot2 = Instantiate(Flash2,ShootPoint.position, ShootPoint.rotation);
            //Destroy(FlashShoot2, 0.5f);

            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.up * BulletSpeed);
            Destroy(BulletIns, timeBeforeDestroy);
        }

        isAttacking = false;
    }


}