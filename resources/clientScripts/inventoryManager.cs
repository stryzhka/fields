using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class inventoryManager : MonoBehaviour
{
    public bool isActive;
    public ScrollRect space;
    public Transform Content;
    public Button _button;
    public bool isCleaning;
    public Text currentWeapText;
    public Button open;
    public GameObject descPanel;
    void Start()
    {
        isActive = false;
        loadWeapons();
        open.onClick.AddListener(openInventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive){
        	space.gameObject.SetActive(true);
        }else{
        	space.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown("i")){
        		openInventory();

        	} 
        if (Input.GetKeyDown("u")){
        		isCleaning = true;
        		cleanInventoryEntries();
        } 
        currentWeapText.text = "Current Weapon: " + playerStats.currentWeap.name + "\n" + "Damage: " + playerStats.currentWeap.baseDamage + "\n" + "Effect: " + playerStats.currentWeap.effect + "\n" + "Delay: " + playerStats.currentWeap.delay;
        
        
    }
    void openInventory(){
    	if (isActive){
            Color tempText = descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color;
            Color temp = descPanel.GetComponent<Image>().color;
            temp.a=0.0f;
            tempText.a = 0.0f;
            descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color = tempText;
            descPanel.GetComponent<Image>().color = temp;
            isActive = false;
            } 
        else isActive = true;
        //print ("eheg");
        saveWeapons();

    }
    public void saveWeapons(){
    	int i = 0;
    	foreach (Transform child in Content){
    		
    		if (i <= playerStats.inventoryLimit){
    			PlayerPrefs.SetString("inventory" + i.ToString(), child.gameObject.GetComponent<inventoryCell>().path);
    			print ("inventory" + i.ToString());
    		}

    		
    		else print ("Can't create entry! :(");
    		i++;
    		print (i);
    	}
    }
    void loadWeapons(){
    	/*string path = "";
    	int amount = 0;
    	foreach (Transform child in Content){
    		amount++;
    	}
    	*/
    	string path = "";
    	for(int i = 0; i < playerStats.inventoryLimit; ++i){
    		path = PlayerPrefs.GetString("inventory" + i);
    		//print (path);
    		if (PlayerPrefs.HasKey("inventory" + i)){
    			//print (path);
    			loader loader = new loader();
    			Weapon weapon = loader.loadWeapon(path);
    			weapon.info();
	    		Button weaponButton = Instantiate(_button, Content);
	    		weaponButton.GetComponent<inventoryCell>()._weapon = weapon;
				weaponButton.GetComponent<inventoryCell>().path = path;
				Sprite image = Resources.Load<Sprite>(weapon.imagePath);
        		weaponButton.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = image;
				}else print ("no key " + "inventory" + i);
    		
    	}
    }
    void cleanInventoryEntries(){
    	if (isCleaning){
    		for (int i = 0; i < playerStats.inventoryLimit; ++i){
    			PlayerPrefs.DeleteKey("inventory" + i);
    		}
    	}
    }
    
}
