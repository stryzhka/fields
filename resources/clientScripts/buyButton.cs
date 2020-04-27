using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyButton : MonoBehaviour
{
    public GameObject player;
    public string listPath;
    public string drop;
    public Weapon weapon;
    public GameObject box;
    public RectTransform weapons;
    public Text text;
    private int random;
    private int eChance;
    GameObject ambManager;
    bool isRus;
    public bool isCustom;
    void Start()
    {
		loader loader = new loader();
		drop = loader.loadList(listPath);  
        weapon = loader.loadWeapon(drop);
		gameObject.GetComponent<Button>().onClick.AddListener(weapPrice);  
        ambManager = GameObject.Find("ambManager");
        if (PlayerPrefs.GetString("language") == "rus") isRus = true;
        else isRus = false;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (isRus) text.text = "Сегодня в продаже: " + weapon.nameRus + "\n Стоимость: " + weapon.price + "\n Урон: " + weapon.baseDamage;  
        else text.text = "Look at: " + weapon.name + "\n Cost: " + weapon.price + "\n Damage: " + weapon.baseDamage;  
    }
    void weapPrice(){
    	if (weapon.price > playerStats.money){
    		print ("sorry bruh");
    	}else{
            //player.GetComponent<inventoryManager>().isActive = true;
            //ambManager.GetComponent<ambitionManager>().isActive = true;
    		GameObject _box = Instantiate(box, player.transform.position, Quaternion.identity);
            if (isCustom) _box.GetComponent<clickable>().custom = true;
            _box.name = "weapon";
            _box.GetComponent<clickable>().weaponPath = drop;
            _box.GetComponent<clickable>().weapons = weapons;
                print("PATH: " + _box.GetComponent<clickable>().weaponPath);
                //_box.GetComponent<clickable>().weapons = weapons;
            playerStats.money -= weapon.price;    
            
    	}
    }
}
