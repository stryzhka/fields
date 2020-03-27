using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame 
    public string scene;
    public bool set;
    void Start()
    {
		gameObject.GetComponent<Button>().onClick.AddListener(click);  
        if (set) PlayerPrefs.SetString("city", "city1");      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void click(){

            SceneManager.LoadScene(scene, LoadSceneMode.Single);
            playerStats.setDummyData();
    	
    	
    }
}
