using UnityEngine;
using UnityEngine.Tilemaps;


public class QuestFinish : MonoBehaviour
{
    public Tilemap tilemap;
    private TilemapRenderer rooftop;

    public GameObject cameraOne;
    public GameObject cameraTwo;
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
                rooftop.enabled = true;
                cameraTwo.SetActive(true);

            }
        }
    }

    private void Start()
    {
        rooftop = tilemap.GetComponent<TilemapRenderer>();
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
