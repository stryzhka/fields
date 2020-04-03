using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiUpdater : MonoBehaviour
{
    public Text moneyText;
    public Text hpText;
    public Text mPText;
    public Text levelText;
    public Text expText;
    public Text expReqText;
    public bool doRotating;
    public Text ambDamage;
    public Text fireChance;
    string lang;
 
    void Start()
    {
        doRotating = false;
        lang = PlayerPrefs.GetString("language");
    }

    // Update is called once per frame
    void Update()
    {	
       float uiHp = ((int)(playerStats.hp*10)/10);
       moneyText.text = playerStats.money.ToString(); 
       hpText.text = uiHp.ToString(); 
       mPText.text = playerStats.magicEnergy.ToString(); 
       if (lang == "rus"){
          levelText.text = "Уровень: " +  playerStats.level; 
          expText.text = "Опыт: " + playerStats.exp.ToString(); 
          expReqText.text = "Нужно опыта: " + playerStats.expReq.ToString(); 
       }
       
       else{
        levelText.text = "Level: " +  playerStats.level; 
        expText.text = "XP: " + playerStats.exp.ToString(); 
        expReqText.text = "XP need: " + playerStats.expReq.ToString(); 

        }
       
       
       if (doRotating) rotate();
       else hpText.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void rotate(){
      
      if (hpText.gameObject.transform.localScale.magnitude > 10) hpText.gameObject.transform.localScale = new Vector3(0.0f, 0f, 0.0f);
      else hpText.gameObject.transform.localScale += new Vector3(2f * Time.deltaTime, 2f * Time.deltaTime, 0.0f);
    }
}
