using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDataInit : MonoBehaviour
{
   
    void Start()
    {
      //playerStats.setDummyData();
      playerStats.loadAllData();
      print ("DATA LOADED");
    }
    void Update(){
    	if (Input.GetKeyDown("o")){
    		playerStats.setDummyData();
    		print ("DUMMY DATA SETTED");
    		} 
    	if (Input.GetKeyDown("p")){
    		playerStats.setAllData();
    		print ("DATA SAVED");
    		} 
    	//print (playerStats.curPath);
    }

}
