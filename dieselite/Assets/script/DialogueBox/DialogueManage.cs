using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManage : MonoBehaviour
{
    public GameObject PNJEnDanger;
    public GameObject player;
    public Animator animator;
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    public static DialogueManage instance;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de DialogManager dans la scène");
            return;
        }

        instance = this;

        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue){

        Cursor.visible = true;
        player.GetComponent<playerMovement>().enabled = false;
        player.GetComponent<PlayerAttack>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    void EndDialogue(){
        Cursor.visible = false;
        animator.SetBool("IsOpen", false);
        player.GetComponent<playerMovement>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
    }
}
