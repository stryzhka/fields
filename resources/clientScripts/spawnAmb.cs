using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnAmb : MonoBehaviour
{
    public GameObject player;
    public GameObject ambButton;
    public GameObject Content;
    public GameObject skillsDropdown, arrow, skillLabel;
    bool dev;
    void Start()
    {
        skillsDropdown = GameObject.Find("skillsDropdown");
        arrow = GameObject.Find("arrow");
        skillLabel = GameObject.Find("skillLabel");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (playerStats.isDropping){
            Text caption = skillLabel.GetComponent<Text>();
        	player.GetComponent<inventoryManager>().isActive = true;
            gameObject.GetComponent<ambitionManager>().isActive = true;
        	loader loader = new loader();
        	List<string> berserk = new List<string>();
            List<string> sniper = new List<string>();
            List<string> elemental = new List<string>();
            List<string> tank = new List<string>();
            berserk.Add("damage");
            elemental.Add("chance");
            tank.Add("resist");
            tank.Add("regen");
            berserk.Add("critical");
            elemental.Add("eDmg");
            sniper.Add("wSpeed");
            sniper.Add("accuracy");
        	string name =  loader.loadList("dataFiles/weapons/ambitionNames");
            GameObject _ambButton = Instantiate(ambButton, Content.transform);
            switch (caption.text){
                case "Berserk":
                    int r = Random.Range(0,berserk.Count);
                    print ("r: " + r);
                    Ambition Ambit = new Ambition(berserk[r], Random.Range(playerStats.level, playerStats.level + 3), name, "", false);
                    if (berserk[r] == "critical"){
                        if (playerStats.critical <= 15) Ambit.buff = Random.Range(playerStats.level, playerStats.level + 1);
                        else Ambit.buff = 1;
                    } 
                    _ambButton.GetComponent<ambCell>()._amb = Ambit;
                    break;
                case "Sniper":
                    r = Random.Range(0,berserk.Count);
                    print ("r: " + r);
                    Ambit = new Ambition(sniper[r], Random.Range(playerStats.level, playerStats.level + 3), name, "", false);
                    _ambButton.GetComponent<ambCell>()._amb = Ambit;
                    break;
                case "Tank":
                    r = Random.Range(0,tank.Count);
                    print ("r: " + r);
                    Ambit = new Ambition(tank[r], Random.Range(playerStats.level, playerStats.level + 3), name, "", false);
                    if (tank[r] == "regen") Ambit.buff = Random.Range(playerStats.level, playerStats.level + 1);
                    _ambButton.GetComponent<ambCell>()._amb = Ambit;
                    break;
                case "Elementalyst":
                    r = Random.Range(0,elemental.Count);
                    print ("r: " + r);
                    Ambit = new Ambition(elemental[r], Random.Range(playerStats.level, playerStats.level + 3), name, "", false);
                    if (elemental[r] == "eDmg") Ambit.buff = Random.Range(1, 3);
                    _ambButton.GetComponent<ambCell>()._amb = Ambit;
                    break;
            }
            
            
            
            
            
            
            
            loader.saveAmbition(_ambButton.GetComponent<ambCell>()._amb);
            playerStats.isDropping = false;
            gameObject.GetComponent<ambitionManager>().saveAmbitions();
        }
        if (dev)
        if (Input.GetKey("e")){
        	playerStats.exp += 10;
        	playerStats.manageExp();
        }
    }

}
