using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerDataInit : MonoBehaviour
{
   public bool training;
   private bool dev;
   GameObject player;
   Dropdown skillsDropdown;
    void Start()
    {
        
        dev = false;
      //playerStats.setDummyData();
      if (training){
        loader loader = new loader();
        playerStats.setTutorialData();
        playerStats.currentWeap = loader.loadWeapon("dataFiles/weapons/noweap");
        } 
      else{
        playerStats.loadAllData();
        resStats.loadResourcesData();
        } 
      print ("DATA LOADED");
      print ("resist is: " + playerStats.resist);
      print ("now regen is: " + playerStats.regen);
      StartCoroutine(regenerate());
      skillsDropdown = GameObject.Find("skillsDropdown").GetComponent<Dropdown>();
      skillsDropdown.value = PlayerPrefs.GetInt("dropdown");
      if (playerStats.currentWeap.rareID == "regen"){
            print ("get to regen: " + playerStats.currentWeap.rareBuff);
            playerStats.regen += playerStats.currentWeap.rareBuff;
            print ("now regen is: " + playerStats.regen);
      }
      if (playerStats.currentWeap.rareID == "resist"){
            print ("get to resist: " + playerStats.currentWeap.rareBuff);
            playerStats.resist += playerStats.currentWeap.rareBuff;
            print ("now resist is: " + playerStats.resist);
      }
      if (playerStats.currentWeap.rareID == "speed"){
            print ("wow i am speedy");
            playerStats.speed = 6;
           
      }
    }
    void Awake(){

    }
    public IEnumerator regenerate(){
        while (true){
            yield return new WaitForSeconds(11f);
            if (playerStats.hp + playerStats.regen < playerStats.maxHp)
            playerStats.hp += playerStats.regen;
            else{
                float temp = playerStats.maxHp - playerStats.hp;
                playerStats.hp += temp;
            }

        }
        
    }

    void Update(){
        if (dev){
          if (Input.GetKeyDown("o")){
            playerStats.setDummyData();
            print ("DUMMY DATA SETTED");
            } 
        if (Input.GetKeyDown("p")){
            playerStats.setAllData();
            print ("DATA SAVED");
            }   
        }

    	
    	//print (playerStats.curPath);
    }
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        playerStats.setAllData();
        resStats.saveResourcesData();
    }

}
