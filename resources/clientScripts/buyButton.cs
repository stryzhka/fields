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
    void Start()
    {
		loader loader = new loader();
		drop = loader.loadList(listPath);  
        weapon = loader.loadWeapon(drop);
		gameObject.GetComponent<Button>().onClick.AddListener(weapPrice);  
        ambManager = GameObject.Find("ambManager");
         
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Сегодня в продаже: " + weapon.name + "\n Стоимость: " + weapon.price + "\n Урон: " + weapon.baseDamage;   
    }
    void weapPrice(){
    	if (weapon.price > playerStats.money){
    		print ("sorry bruh");
    	}else{
            player.GetComponent<inventoryManager>().isActive = true;
            ambManager.GetComponent<ambitionManager>().isActive = true;
    		GameObject _box = Instantiate(box, player.transform.position, Quaternion.identity);
            _box.name = "weapon";
            _box.GetComponent<clickable>().weaponPath = drop;
            _box.GetComponent<clickable>().weapons = weapons;
                print("PATH: " + _box.GetComponent<clickable>().weaponPath);
                //_box.GetComponent<clickable>().weapons = weapons;
            playerStats.money -= weapon.price;    
            
    	}
    }
}
