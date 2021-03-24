using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPNJ : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    public GameObject PNJNaked;

    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f){
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision2){
        if(collision2.CompareTag("PNJ Naked")){
            this.GetComponent<MovementPNJ>().enabled = false;
            PNJNaked.GetComponent<DialogueTrigger>().enabled = false;
            PNJNaked.GetComponent<QuestFinish>().enabled = true;
        }
    }
}
