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
    public GameObject ambManager;
    public GameObject skillsDropdown, skillLabel;
    
    bool isRus;
    bool dev;
    void Start()
    {
        isActive = false;
        loadWeapons();
        playerStats.inventoryLimit = 14;
        descPanel = GameObject.Find("descPanel");
        ambManager = GameObject.Find("ambManager");
        skillsDropdown = GameObject.Find("skillsDropdown");
        skillLabel = GameObject.Find("skillLabel");
        if (PlayerPrefs.GetString("language") == "rus") isRus = true;
        else isRus = false;
        dev = false;
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive){
        	space.gameObject.SetActive(true);
            Color tempTextLabel = skillLabel.GetComponent<Text>().color;
            tempTextLabel.a = 1.0f;
            skillLabel.GetComponent<Text>().color = tempTextLabel;
            Color dropdownC = skillsDropdown.GetComponent<Image>().color;
            dropdownC.a = 1f;
            skillsDropdown.GetComponent<Image>().color = dropdownC;
        }else{
        	space.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown("i")){
        		openInventory();

        	} 
        if (dev){
            if (Input.GetKeyDown("u")){
                isCleaning = true;
                cleanInventoryEntries();
                //cleaning all inventory
            }
        }
         
        if (!isRus) currentWeapText.text = playerStats.currentWeap.name;
        else currentWeapText.text = playerStats.currentWeap.nameRus;
        
        
    }
    void Awake(){
        //
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
            Color tempTextLabel = skillLabel.GetComponent<Text>().color;
            tempTextLabel.a = 0.0f;
            skillLabel.GetComponent<Text>().color = tempTextLabel;
            Color dropdownC = skillsDropdown.GetComponent<Image>().color;
            dropdownC.a = 0f;
            skillsDropdown.GetComponent<Image>().color = dropdownC;
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
        print ("now loading");
    	/*string path = "";
    	int amount = 0;
    	foreach (Transform child in Content){
    		amount++;
    	}
    	*/
    	string path = "";
        print ("inventoryLimit: " + playerStats.inventoryLimit);
        playerStats.inventoryLimit = 14;
        print ("inventoryLimit: " + playerStats.inventoryLimit);
    	for(int i = 0; i < playerStats.inventoryLimit; ++i){
    		path = PlayerPrefs.GetString("inventory" + i);
            print("Cycle" + i);
    		print ("PP PATH: " + path);
    		if (PlayerPrefs.HasKey("inventory" + i)){
    			//print (path);
    			loader loader = new loader();
    			Weapon weapon = loader.loadWeapon(path);
    			//weapon.info();
	    		Button weaponButton = Instantiate(_button, Content);
	    		weaponButton.GetComponent<inventoryCell>()._weapon = weapon;
				weaponButton.GetComponent<inventoryCell>().path = path;
				Sprite image = Resources.Load<Sprite>(weapon.imagePath);
        		//weaponButton.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = image;
                weaponButton.image.sprite = image;
                
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
    void OnApplicationQuit()
    {
        saveWeapons();
    }
}
