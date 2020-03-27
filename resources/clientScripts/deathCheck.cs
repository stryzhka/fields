using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private string load;
    void Start()
    {
        load = PlayerPrefs.GetString("city");       
    }

    // Update is called once per frame
    void Update()
    {
        playerStats.checkForDeath();
        if (playerStats.dead){
        	if (SceneManager.GetActiveScene().name == "training"){
        		playerStats.setTutorialData();
        		SceneManager.LoadScene("start", LoadSceneMode.Single);
        	}else{
        		playerStats.setDataHp();
    			SceneManager.LoadScene(load, LoadSceneMode.Single);
    			playerStats.dead = false;
        	}
            
        }
    }
}
