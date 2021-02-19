using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackSounds;
    private AudioSource Audio_attack;
    Animator m_Animator;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float FireRate;
    float ReadyForNextShot;

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
            if (Time.time > ReadyForNextShot)
            {

                ReadyForNextShot = Time.time + 1 / FireRate;

                //GameObject FlashShoot2 = Instantiate(Flash2,ShootPoint.position, ShootPoint.rotation);
                //Destroy(FlashShoot2, 0.5f);

                GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
                BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.up * BulletSpeed);
                Destroy(BulletIns, 0.3f);
            }
        }
    }
}