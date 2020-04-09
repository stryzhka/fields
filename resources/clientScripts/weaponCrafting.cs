using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class weaponCrafting : MonoBehaviour
{
    public string type;
    public Weapon weapon;
    public GameObject box;
    public Transform player;
    public RectTransform weapons;
    public Text text;
    public Slider attack, speed, accuracy;
    public Text money, woodt, iront;
    float dmgMoney;
    float accMoney;
    float spMoney;
    int sum;
    int wood, iron;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate{craft(type);});
    }

    // Update is called once per frame
    void Update()
    {
        dmgMoney = attack.value * 3500;
	    accMoney = 4000 / accuracy.value;
	    spMoney = 5550 / speed.value;

	    sum = (int)Mathf.Round(dmgMoney + accMoney + spMoney);
	    //sumM = sum - (int)accMoney;
	    wood = sum / 5000;
	    iron = sum / 4400;
	    money.text = "Денег нужно: " + sum.ToString();
	    woodt.text = "Дерева нужно: " + wood.ToString();
	    iront.text = "Железа нужно: " + iron.ToString();
    }
    void craft(string t){
    	print ("iron: " + resStats.ironCount);
    	print ("wood: " + resStats.woodCount);
    	if (playerStats.money >= sum && resStats.ironCount >= iron && resStats.woodCount >= wood){
    		
    		string[] names = new string[4];
	    	names[0] = "sword";
	    	names[1] = "dagger";
	    	string[] pistol = new string[3];
	    	pistol[0] = "sprites/dataSprites/rusty1";
	    	pistol[1] = "sprites/dataSprites/rusty2";
	    	pistol[2] = "sprites/dataSprites/rusty3";
	    	loader loader = new loader();
	    	float damage = playerStats.money * 0.001f * playerStats.level / 20 * 0.1f;
	    	damage = Mathf.Ceil(damage);
	    	weapon = loader.loadWeapon("dataFiles/weapons/craftedWeap");
	    	weapon.baseDamage = damage;
	    	weapon.baseDamage = attack.value;
	    	weapon.accuracy = accuracy.value;
	    	weapon.delay = speed.value;

	    	//weapon.delay = Random.Range(0.1f, 1f);
	    	weapon.effectDamage = playerStats.generateDamage();
	        weapon.effectChance = Random.Range(1, 40);
	        //weapon.name = "Crafted";
	    	if (t == "ranged"){
	    		weapon.name += "Pistol";
	    		weapon.type = t;
	    		//weapon.accuracy = Random.Range(1.3f, 2f);
	    		weapon.imagePath = pistol[Random.Range(0,3)];
	    		print (weapon.info());
	    		playerStats.money -= sum;
	    	}
	    	if (t == "f"){
	    		name = names[Random.Range(0, names.Length)];
	    		weapon.name += name;
	    		weapon.type = "";
		    	if (name == "dagger")
	    		weapon.imagePath = "sprites/dataSprites/customDag";
	    		else
	    		weapon.imagePath = "sprites/dataSprites/customSword";
	    		print (weapon.info());
	    		int sumM = sum - (int)accMoney;
	    		print ("sumM: " + sumM);
	    		playerStats.money -= sumM;
	    		resStats.ironCount -= iron;
	    		resStats.woodCount -= wood;
	    	}
	    	GameObject _box = Instantiate(box, player.position, Quaternion.identity);
	    	if (text.text != "") weapon.name = text.text;
	    	_box.name = "weapon";
	    	_box.tag = "custom";
	    	_box.GetComponent<clickable>().weapons = weapons;
	    	_box.GetComponent<clickable>().weapon = weapon;
	    	_box.GetComponent<clickable>().weaponPath = weapon.path;
	    	
	    	
    	}
    	
    }
}
