using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public bool isEnemyHere = true;
    public int EnemyNumber;

    public int enemyDead = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (enemyDead == EnemyNumber)
        {
            isEnemyHere = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            isEnemyHere = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Ennemy"))
        {
            enemyDead++;
        }
    }
}
