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

 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {	
       moneyText.text = playerStats.money.ToString(); 
       hpText.text = playerStats.hp.ToString(); 
       mPText.text = playerStats.magicEnergy.ToString(); 
       levelText.text = "Level: " +  playerStats.level; 
       expText.text = "XP: " + playerStats.exp.ToString(); 
       expReqText.text = "XP need: " + playerStats.expReq.ToString(); 
    }
}
