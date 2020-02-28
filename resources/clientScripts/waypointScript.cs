using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waypointScript : MonoBehaviour
{
    public string scene;
    public float x, y, z;
    public bool loadPos;
    public bool set;
    void Start()
    {
        if (PlayerPrefs.GetInt("load") == 1 && set)
        GameObject.Find("player").transform.position = new Vector3(x, y, z);
        else print ("аутизм");
        print(PlayerPrefs.GetString("currentWay"));
        print(loadPos);
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Player"){
        	playerStats.setAllData();
            PlayerPrefs.SetString("currentWay", gameObject.name);
            PlayerPrefs.SetFloat("x", x);
            PlayerPrefs.SetFloat("y", x);
            PlayerPrefs.SetFloat("z", x);
            if (loadPos)
            PlayerPrefs.SetInt("load", 1);
            else
            PlayerPrefs.SetInt("load", 0);

            if (scene == "city2"){
                PlayerPrefs.SetString("city", "city2");
                print ("ok");
                print (PlayerPrefs.GetString("city"));
            }
            
        	SceneManager.LoadScene(scene, LoadSceneMode.Single);
            
            
        }
            
    }
    void Update()
    {
        
    }
        
}
