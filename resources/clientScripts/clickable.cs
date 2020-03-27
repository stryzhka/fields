using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class clickable : MonoBehaviour
{
    public GameObject player;
    public int gMoney;
    public int gHp;
    public string weaponPath;
    public string hatPath;
    public string trPath;
    public string ambPath;
    public Text weaponText;
    public RectTransform weapons;
    public Transform content;
    public Button _button;
    public Button ambButton;
    public string effect;
    public Weapon weapon;
    public Treasure treas;
    public Ambition amb;
    public Sprite image;
    void Start()
    {

        player = GameObject.Find("player");
    	loader loader = new loader();

    	//Sprite image = Resources.Load<Sprite>("sprites/hats/empty");
    	
    	switch(gameObject.name){
        	case "money":
        	
        		//image = Resources.Load<Sprite>("sprites/money1");
        		player = GameObject.Find("player");
        		break;
        	case "hp":
        		//image = Resources.Load<Sprite>("sprites/box1");
        		player = GameObject.Find("player");
        		break;
        	case "weapon":
        		player = GameObject.Find("player");
        		//weapons = GameObject.FindWithTag("content").GetComponent<RectTransform>();
        		if (gameObject.tag != "custom")
        		weapon = loader.loadWeapon(weaponPath);
				image = Resources.Load<Sprite>(weapon.imagePath);
				
				
				break;
			case "treasure":
				treas = loader.loadTr(trPath);
				image = Resources.Load<Sprite>(treas.imagePath);
				
        		player = GameObject.Find("player");
				break;
            case "ambition":
                player = GameObject.Find("player");
                break;
            case "hat":
                Sprite img = Resources.Load<Sprite>(hatPath);
                
                print("hatPath: " + hatPath);
                image = img;
                break;
        }
        //image.size = 1;
    	
    	
        
        
        gameObject.GetComponent<SpriteRenderer>().sprite = image;
    }

    // Update is called once per frame
    void modifiers(){
        List<string> names = new List<string>();
        names.Add("Необычный ");
        names.Add("Странный ");
        names.Add("Переделанный ");
        names.Add("Улучшенный ");
        float r = Random.Range(0f, 1f);
        if (r <= 0.08f){
            gameObject.tag = "custom";
            weapon.name = names[Random.Range(0, names.Count)] + weapon.name;
            weapon.baseDamage += Random.Range(1, playerStats.level - 1);
        }   
    }
    void OnMouseDown(){
    if (Vector2.Distance(player.transform.position, transform.position) <= 3){
    	Sprite image = Resources.Load<Sprite>("");
    	switch(gameObject.name){
    		case "money":
    			playerStats.money += gMoney;
    			Destroy (this.gameObject);
    			break;
    		case "hp":
				Destroy (this.gameObject);
                if (playerStats.hp + gHp > playerStats.maxHp){
                    playerStats.hp += playerStats.maxHp - playerStats.hp;
                }
				else playerStats.hp += gHp;
				
    			break;
    		case "weapon":
                modifiers();
    			loader loader = new loader();
    			if (weapons.childCount < playerStats.inventoryLimit){
				    Button weaponButton = Instantiate(_button, weapons);
                    switch (effect){
                        case "fire":
                            weapon.effect = effect;
                            weapon.effectDamage = playerStats.generateDamage();
                            weapon.effectChance = Random.Range(1, 40);
                            weapon.name += " Fire";
                            loader.saveWeapon(weapon, weapon.effect);
                            break;
                        case "slag":
                            weapon.effect = effect;
                            weapon.effectDamage = playerStats.generateDamage();
                            weapon.effectChance = Random.Range(1, 40);
                            weapon.name += " Slag";
                            loader.saveWeapon(weapon, weapon.effect);
                            break;
                        case "zap":
                            weapon.effect = effect;
                            weapon.effectDamage = playerStats.generateDamage();
                            weapon.effectChance = Random.Range(1, 40);
                            weapon.name += " Zapping";
                            loader.saveWeapon(weapon, weapon.effect);
                            break;
                        
                    }
                    if (gameObject.tag == "custom"){
                        loader.saveCraft(weapon);
                        print("wPath: " + weapon.path);

                    } 
                    
				    weaponButton.GetComponent<inventoryCell>()._weapon = weapon;
				    weaponButton.GetComponent<inventoryCell>().path = weapon.path;
				    image = Resources.Load<Sprite>(weapon.imagePath);
				    print (weapon.name);
				    weaponButton.image.sprite = image;
                    
                    player.GetComponent<inventoryManager>().saveWeapons();
				    Destroy(gameObject);
    			}else print ("Too many items in inventory.");
    			break;
    		case "treasure":
    			print ("This is a treasure. So?");
    			/*Button treasButton = Instantiate(_button, weapons);
    			image = Resources.Load<Sprite>(treas.imagePath);
    			treasButton.GetComponent<inventoryCell>()._treas = treas;
    			treasButton.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = image;
    			treasButton.GetComponentInChildren<Text>().text = treas.prefix + " " + treas.name;
    			Destroy (this.gameObject);*/
    			break;
            case "ambition":
                Button b = Instantiate(ambButton, content);
                loader.saveAmbition(amb);
                ambButton.GetComponent<ambCell>()._amb = amb; 
                Destroy(gameObject);
                break;

            case "hat":
                print(player.transform.GetChild(1).GetChild(0));
                playerStats.hatPath = hatPath;
                Sprite img = Resources.Load<Sprite>(hatPath);
                player.transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite = img;
                Destroy(gameObject);
                
                break;
    	}

    
    }
    
  }   
}
