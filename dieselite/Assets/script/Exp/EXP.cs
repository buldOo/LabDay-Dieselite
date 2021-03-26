using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour{

    public int maxExp;
    public float updateExp;

    public Image ExpBar;

    public float expIncrement;

    public int playerLevel;

    public Text levelText;

    bool ExpInRange ;

    void Start(){
        playerLevel = 1;
        maxExp = 25;
        updateExp = 0;
        ExpInRange = false;
    }

    void Update(){

        if(ExpInRange == true){
            updateExp += expIncrement * Time.deltaTime;
            ExpBar.fillAmount = updateExp / maxExp;
        }

        levelText.text = playerLevel + "";

        if(updateExp >= maxExp){
            playerLevel++;
            updateExp = 0;
            maxExp += maxExp/5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("EXP")){
            ExpInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("EXP")){
            ExpInRange = false;
        }
    }
}