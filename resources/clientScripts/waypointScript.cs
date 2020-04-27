using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class waypointScript : MonoBehaviour
{
    public string scene;
    public float x, y, z;
    public bool loadPos;
    public bool set;
    public bool secret;
    public string secretName;
    public Text tipsText;
    public GameObject tipsPanel;
    public Dropdown skillsDropdown;
    bool isRus;
    public bool toG;
    void Start()
    {
        if (PlayerPrefs.GetString("currentWay") == gameObject.name && set)
        GameObject.Find("player").transform.position = new Vector3(x, y, z);
        else print ("аутизм");
        print(PlayerPrefs.GetString("currentWay"));
        print(loadPos);
        if (secret) print ("secret: " + PlayerPrefs.GetInt(secretName));
        tipsText = GameObject.Find("tipsText").GetComponent<Text>();
        tipsPanel = GameObject.Find("tipsPanel");
        Color tmp = tipsPanel.GetComponent<Image>().color;
        tmp.a = 0;
        tipsPanel.GetComponent<Image>().color = tmp;
        skillsDropdown = GameObject.Find("skillsDropdown").GetComponent<Dropdown>();
        if (PlayerPrefs.GetString("language") == "rus") isRus = true;
        else isRus = false;
        if (toG){
            if (PlayerPrefs.GetInt("toGigapolis") == 1){
                print ("ok go");
                
            }
            else{
                print ("nah");
                gameObject.SetActive(false);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col){
        loader loader = new loader();
        resStats.saveResourcesData();
        playerStats.setAllData();
        playerStats.saveSkin();

        if (col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<inventoryManager>().saveWeapons();
            if (secret){
              if (PlayerPrefs.GetInt(secretName) == 0){
                if (secretName == "secret2"){
                    if (playerStats.hatPath == "sprites/hats/mask"){
                        PlayerPrefs.SetInt(secretName, 1);
                        print ("secret: " + PlayerPrefs.GetInt(secretName));
                        Color tmp = tipsPanel.GetComponent<Image>().color;
                        tmp.a = 1;
                        tipsPanel.GetComponent<Image>().color = tmp;
                        if (isRus) tipsText.text = loader.loadList("dataFiles/weapons/tipsRus");
                        else tipsText.text = loader.loadList("dataFiles/weapons/tips");
                        PlayerPrefs.SetInt("dropdown", skillsDropdown.value);
                        SceneManager.LoadScene(scene, LoadSceneMode.Single);
                    }
                }else{
                    PlayerPrefs.SetInt(secretName, 1);
                    print ("secret: " + PlayerPrefs.GetInt(secretName));
                    Color tmp = tipsPanel.GetComponent<Image>().color;
                        tmp.a = 1;
                        tipsPanel.GetComponent<Image>().color = tmp;
                    if (isRus) tipsText.text = loader.loadList("dataFiles/weapons/tipsRus");
                    else tipsText.text = loader.loadList("dataFiles/weapons/tips");
                    PlayerPrefs.SetInt("dropdown", skillsDropdown.value);
                    SceneManager.LoadScene(scene, LoadSceneMode.Single);
                }
                    
              }else{
                print ("NO SECRET");
              }
                
            }else{
                
            PlayerPrefs.SetString("currentWay", gameObject.name);
            PlayerPrefs.SetFloat("x", x);
            PlayerPrefs.SetFloat("y", x);
            PlayerPrefs.SetFloat("z", x);
            

            if (scene == "city2"){
                PlayerPrefs.SetString("city", "city2");
                print ("ok");
                print (PlayerPrefs.GetString("city"));
            }
            if (scene == "city3"){
                PlayerPrefs.SetString("city", "city3");
                print ("ok");
                print (PlayerPrefs.GetString("city"));
            }
            if (scene == "city4"){
                PlayerPrefs.SetString("city", "city4");
                print ("ok");
                print (PlayerPrefs.GetString("city"));
            }
                Color tmp = tipsPanel.GetComponent<Image>().color;
                        tmp.a = 1;
                        tipsPanel.GetComponent<Image>().color = tmp;
                if (isRus) tipsText.text = loader.loadList("dataFiles/weapons/tipsRus");
                else tipsText.text = loader.loadList("dataFiles/weapons/tips");
                PlayerPrefs.SetInt("dropdown", skillsDropdown.value);
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
            }
        	
            
        	
            
            
        }
            
    }
    void Update()
    {
        
    }
        
}
