using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMan;


    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
       if (other.gameObject.name == "player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                dMan.ShowBox(dialogue);
            }
        } 
    }
}
