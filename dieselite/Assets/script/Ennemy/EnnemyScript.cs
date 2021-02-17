using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour
{
    public float lineOfSite;
    public GameObject Bullet;
    private Transform player;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float FireRate;
    public GameObject Flash2;
    float ReadyForNextShot;
    Vector2 dir;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            if (Time.time > ReadyForNextShot){
                
            ReadyForNextShot = Time.time + 1 / FireRate;

            GameObject FlashShoot2 = Instantiate(Flash2,ShootPoint.position, ShootPoint.rotation);
                Destroy(FlashShoot2, 0.07f);
                
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.up * BulletSpeed);
            Destroy(BulletIns, 0.2f);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
