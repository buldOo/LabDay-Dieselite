using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackSounds;
    public GameObject Bullet;
    public Transform ShootPoint;
    public LayerMask enemy;
    public float BulletSpeed;
    public float FireRate;
    public float timeBeforeDestroy;

    private AudioSource Audio_attack;
    private Animator animator;
    private Vector2 input;
    private bool isAttacking;
    private bool isPunching;


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
        animator.SetBool("isPunching", isPunching);


        //Press the left click to tell the Animator to trigger the Jump Animation
        if (Input.GetKey(KeyCode.Mouse0) && animator.GetInteger("WeaponEquiped") == 1)
        {
            isAttacking = true;
            StartCoroutine(ExampleCoroutine(1));

        } else if (Input.GetKeyDown(KeyCode.Mouse0) && animator.GetInteger("WeaponEquiped") == 0) {
            isPunching = true;
            StartCoroutine(ExampleCoroutine(0));

        }
        else {
            isAttacking = false;
        }

    }

    IEnumerator ExampleCoroutine( int weapon)
    {
        yield return new WaitForSeconds(0.5F);

        if (Time.time > ReadyForNextShot && weapon == 1)
        {

            ReadyForNextShot = Time.time + 1 / FireRate;

            //GameObject FlashShoot2 = Instantiate(Flash2,ShootPoint.position, ShootPoint.rotation);
            //Destroy(FlashShoot2, 0.5f);

            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.up * BulletSpeed);


            Destroy(BulletIns, timeBeforeDestroy);

        } else if (weapon == 0) {
            isPunching = false;

        }

    }

}