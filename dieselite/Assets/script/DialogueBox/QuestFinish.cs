using UnityEngine;

public class QuestFinish : MonoBehaviour
{
    public GameObject dialogueTrigger;
    public Dialogue dialogue;
    public bool isInRange;

    void Update()
    {
        if (GameObject.Find("EnemyDetector").GetComponent<EnemyDetector>().isEnemyHere == false)
        {
            dialogueTrigger.GetComponent<DialogueTrigger>().enabled = false;
            if (isInRange && Input.GetKeyDown(KeyCode.E)){
                TriggerDialogue();
            }
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
}
