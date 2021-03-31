using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour{

    public int maxExp;
    public float updateExp;

    public Image ExpBar;

    public int playerLevel;

    public Text levelText;


    void Start(){
        playerLevel = 1;
        maxExp = 25;
        updateExp = 0;
    }

    void Update(){

        ExpBar.fillAmount = updateExp / maxExp;

        levelText.text = playerLevel + "";

        if(updateExp >= maxExp){
            playerLevel++;
            updateExp = 0;
            maxExp += maxExp/5;
        }
    }
}