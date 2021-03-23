using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnnemy : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float lineOfSite;
    public float  shootingRange;
    public float speed;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float FireRate;
    float ReadyForNextShot;
    public int maxHealth = 100;
    public int currentHealth;

    private Animator animator;
    private bool isDead;




    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update(){

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();

        animator.SetBool("isDead", isDead);

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange){
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }

        else if (distanceFromPlayer <= shootingRange){
            if (Time.time > ReadyForNextShot){
                
            ReadyForNextShot = Time.time + 1 / FireRate;

            //GameObject FlashShoot2 = Instantiate(Flash2,ShootPoint.position, ShootPoint.rotation);
                //Destroy(FlashShoot2, 0.5f);
                
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.up * BulletSpeed);
            Destroy(BulletIns, 0.3f);
            }
        }

        if (currentHealth <= 0)
        {
            Debug.Log("je suis mort");
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }

    void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        Debug.Log(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("playerBullet"))
        {
            Debug.Log("je suis touché");
            Destroy(collision.gameObject);
            TakeDamage(34);
        }
    }
}
