using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waypointScript : MonoBehaviour
{
    public string scene;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Player"){
        	playerStats.setAllData();
        	SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
            
    }
    void Update()
    {
        
    }
        
}
