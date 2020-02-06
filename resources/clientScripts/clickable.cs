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
    public string trPath;
    public Text weaponText;
    public RectTransform weapons;
    public Button _button;
    public string effect;
    public Weapon weapon;
    public Treasure treas;
    void Start()
    {

        player = GameObject.Find("player");
    	loader loader = new loader();
    	Sprite image = Resources.Load<Sprite>("sprites/money1");
    	weapons = GameObject.FindWithTag("content").GetComponent<RectTransform>();
    	switch(gameObject.name){
        	case "money":
        		image = Resources.Load<Sprite>("sprites/money1");
        		player = GameObject.Find("player");
        		break;
        	case "hp":
        		image = Resources.Load<Sprite>("sprites/box1");
        		player = GameObject.Find("player");
        		break;
        	case "weapon":
        		player = GameObject.Find("player");
        		
        		
        		weapon = loader.loadWeapon(weaponPath);
				image = Resources.Load<Sprite>(weapon.imagePath);
				
				
				break;
			case "treasure":
				treas = loader.loadTr(trPath);
				image = Resources.Load<Sprite>(treas.imagePath);
				
        		player = GameObject.Find("player");
				break;

        }
    	
    	
        
        
        gameObject.GetComponent<SpriteRenderer>().sprite = image;
    }

    // Update is called once per frame
    
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
				playerStats.hp += gHp;
				if (playerStats.hp > playerStats.maxHp){
					while (playerStats.hp != playerStats.maxHp)  playerStats.hp--;
				}
				
    			break;
    		case "weapon":
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
                    
				    weaponButton.GetComponent<inventoryCell>()._weapon = weapon;
				    weaponButton.GetComponent<inventoryCell>().path = weaponPath;
				    image = Resources.Load<Sprite>(weapon.imagePath);
				    print (weapon.name);
				    weaponButton.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = image;
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
    	}
    }
    
  }   
}
