using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJEnDanger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool isInRange;
    
    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E)){
            TriggerDialogue();
            StartCoroutine(wait()); 
            this.GetComponent<PNJEnDanger>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
         if(collision.CompareTag("Player")){
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isInRange = false;
        }
    }

    void TriggerDialogue(){
        DialogueManage.instance.startDialogue(dialogue);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(7);

        this.GetComponent<MovementPNJ>().enabled = true;         
 
    }
}
