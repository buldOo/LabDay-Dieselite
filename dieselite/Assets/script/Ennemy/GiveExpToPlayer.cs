using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveExpToPlayer : MonoBehaviour
{

    public Transform ExpBar;
    public Transform ExpBar2;
    public float speed;
    bool ExpGiven;

    // Start is called before the first frame update
    void Start()
    {
        ExpGiven = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ExpGiven == true){
            transform.position = Vector2.MoveTowards(this.transform.position, ExpBar2.position, speed * Time.deltaTime);
            Destroy(gameObject, 20);
        }
        else {
            transform.position = Vector2.MoveTowards(this.transform.position, ExpBar.position, speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("ExpBar")){
            StartCoroutine(wait());                 
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.15f);

        ExpGiven = true;         
 
    }
}
