﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ambitionManager : MonoBehaviour
{
    public bool isActive;
    public GameObject ui;
    public Transform Content;
    public loader loader;
    public Button _button;
    public GameObject ambBox;
    void Start()
    {
        loader = new loader();
        loadAmbitions();
        playerStats.ambDamage = 0;
        //calculateAmbitions();
    }

    // Update is called once per frame
    void Update()
    {
    	activeCheck();
        if (isActive) ui.SetActive(true);
        else ui.SetActive(false);
        if (Input.GetKeyDown("u")) cleanAmbitionEntries();
        /*if (playerStats.isDropping){
            GameObject player = GameObject.Find("player");
            GameObject _ambBox = Instantiate(ambBox, player.transform);
            Ambition Ambit = new Ambition("damage", Random.Range(playerStats.level - 1, playerStats.level), loader.loadList("dataFiles/ambitionNames"), "");
            _ambBox.GetComponent<clickable>().amb = Ambit;
            playerStats.isDropping = false;
        }*/
    }
    void activeCheck(){
    	if (Input.GetKeyDown("i")){
        	if (isActive){
        		isActive = false;
        		saveAmbitions();
        	}else{
        		isActive = true;
                saveAmbitions();
        	}
        }
    }
    public void saveAmbitions(){
    	int i = 0;
    	foreach (Transform child in Content){
    		PlayerPrefs.SetString("ambition" + i.ToString(), child.gameObject.GetComponent<ambCell>()._amb.path);
    		print ("ambition" + i.ToString());
    		i++;
    	}
    }
    void loadAmbitions(){
    	string path = "";
    	for(int i = 0; i < 10; ++i){
    		path = PlayerPrefs.GetString("ambition" + i);
    		if (PlayerPrefs.HasKey("ambition" + i)){
    			print("PATH: " + path);
    			Ambition amb = loader.loadAmbition(path);
	    		Button ambButton = Instantiate(_button, Content);
	    		ambButton.GetComponent<ambCell>()._amb = amb;
				ambButton.GetComponent<ambCell>().path = path;

				//Sprite image = Resources.Load<Sprite>(weapon.imagePath);
        		//weaponButton.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = image;
				}else print ("no key " + "ambition" + i);
    		
    	}
    }
    void calculateAmbitions(){
    	foreach (Transform tr in Content){
    		playerStats.ambDamage += tr.gameObject.GetComponent<ambCell>()._amb.buff;
    	}
    }
    void cleanAmbitionEntries(){
    	for (int i = 0; i < playerStats.inventoryLimit; ++i){
    			PlayerPrefs.DeleteKey("ambition" + i);
    			print ("deleted");
    		}
    }

}
