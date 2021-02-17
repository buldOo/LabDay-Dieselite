using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour
{
    public float lineOfSite;
    private Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            if (timeBtwShots <= 0){
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else {
                timeBtwShots -= Time.deltaTime;
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}


// j'aime beaucoup les mrs