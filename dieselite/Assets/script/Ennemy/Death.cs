using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Animator animator;
    private bool isDead;

    public GameObject parent;
    public GameObject Exp;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isDead", isDead);

        if (currentHealth <= 0)
        {
            StartCoroutine(ExampleCoroutine());
            Exp.GetComponent<GiveExpToPlayer>().enabled = true;
            Exp.SetActive(true);
        }
    }

    void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("playerBullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(34);
            Debug.Log("toucher");
        }
    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("dead");
        parent.GetComponent<ScriptEnnemy>().enabled = false;
        isDead = true;
        yield return new WaitForSeconds(0.90F);
        Destroy(gameObject);
    }
}
