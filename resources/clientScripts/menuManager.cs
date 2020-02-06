using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public Button exit;
    public GameObject panel;
    private bool isActive;
    void Start()
    {
    	isActive = false;
        exit.onClick.AddListener(exitGame);
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown("escape")){
    		if (isActive){
    			isActive = false;
        	}
        	else isActive = true;
    	}
    	if (isActive){
    		panel.SetActive(true);
    	} else panel.SetActive(false);
        
    }
    void exitGame(){
    	playerStats.setAllData();
    	Application.Quit();
    }
}
