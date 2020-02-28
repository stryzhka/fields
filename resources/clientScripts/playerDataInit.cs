using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDataInit : MonoBehaviour
{
   public bool training;
   private bool dev;
    void Start()
    {
        dev = false;
      //playerStats.setDummyData();
      if (training){
        loader loader = new loader();
        playerStats.setTutorialData();
        playerStats.currentWeap = loader.loadWeapon("dataFiles/weapons/noweap");
        } 
      else playerStats.loadAllData();
      print ("DATA LOADED");
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
    }

}
