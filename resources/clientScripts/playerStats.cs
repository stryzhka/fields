using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class playerStats
{
   public static int level;
   public static int exp;
   public static int expReq;
   public static int money;
   public static float hp;
   public static float maxHp;
   public static int magicEnergy;
   public static float damage;
   public static float ambDamage;
   public static int inventoryLimit;
   public static Weapon currentWeap;
   public static string curPath;
   public static List<Weapon> weapons;
   public static bool dead;
   public static bool isDropping;
   public static int speed;
   public static float chance;
   public static float resist;
   public static void setDummyData(){
    Directory.CreateDirectory(Application.persistentDataPath + "/dataFiles/customWeapons/");
    Directory.CreateDirectory(Application.persistentDataPath + "/dataFiles/ambitions/");
   	loader loader = new loader();
    cleanInventoryEntries();
    isDropping = false;
    ambDamage = 0;
    chance = 0;
   	level = 1;
   	expReq = 100;
   	exp = 1;
   	money = 100;
   	hp = 30;
   	magicEnergy = 30;
   	maxHp = 50;
   	inventoryLimit = 14;
    resist = 0;
    curPath = "dataFiles/weapons/knife";
   	weapons = new List<Weapon>();
   	weapons.Add(loader.loadWeapon("dataFiles/weapons/knife"));
   	Debug.Log(weapons[0].name);
   	currentWeap = weapons[0];
    for (int i = 0; i < 30; ++i){
          PlayerPrefs.DeleteKey("ambition" + i);
        }
    setAllData();
   }
   public static void setTutorialData(){
    Directory.CreateDirectory(Application.persistentDataPath + "/dataFiles/customWeapons/");
    Directory.CreateDirectory(Application.persistentDataPath + "/dataFiles/ambitions/");
    loader loader = new loader();
    ambDamage = 0;
    chance = 0;
    level = 1;
    expReq = 100;
    exp = 1;
    money = 100;
    hp = 30;
    magicEnergy = 30;
    maxHp = 50;
    inventoryLimit = 14;
    resist = 0;
    curPath = "dataFiles/weapons/knife";
    weapons = new List<Weapon>();
    weapons.Add(loader.loadWeapon("dataFiles/weapons/knife"));
    Debug.Log(weapons[0].name);
    currentWeap = weapons[0];
    for (int i = 0; i < 30; ++i){
          PlayerPrefs.DeleteKey("ambition" + i);
        }
    
   }
   public static void setAllData(){
   		Debug.Log("Money: " + money);
      Debug.Log("level:" + level);
      Debug.Log("exp: " + exp);
      Debug.Log("exp req: " + expReq);
      Debug.Log("hp: " + hp);
      Debug.Log("maxhp: " + maxHp);
      Debug.Log("inventoryLimit: " + inventoryLimit);
   		PlayerPrefs.SetInt("playerLevel", level);
   		PlayerPrefs.SetInt("playerExp", exp);
   		PlayerPrefs.SetInt("playerExpReq", expReq);
    	PlayerPrefs.SetInt("playerMoney", money);
    	PlayerPrefs.SetFloat("playerHp", hp);
    	PlayerPrefs.SetFloat("maxPlayerHp", maxHp);
    	PlayerPrefs.SetFloat("curDamage", damage);
      PlayerPrefs.SetInt("inventoryLimit", inventoryLimit);
      PlayerPrefs.SetString("curPath", curPath);
      chance = 0;
      resist = 0;

    	//currentWeap = loadWeapons(PlayerPrefs.GetString("inventory1"));
    }
    public static void setDataHp(){
      Debug.Log("Money: " + money);
      Debug.Log("level:" + level);
      Debug.Log("exp: " + exp);
      Debug.Log("exp req: " + expReq);
      Debug.Log("maxhp: " + maxHp);
      Debug.Log("inventoryLimit: " + inventoryLimit);
      PlayerPrefs.SetInt("playerLevel", level);
      PlayerPrefs.SetInt("playerExp", exp);
      PlayerPrefs.SetInt("playerExpReq", expReq);
      PlayerPrefs.SetInt("playerMoney", money);
      PlayerPrefs.SetFloat("playerHp", maxHp);
      PlayerPrefs.SetFloat("maxPlayerHp", maxHp);
      PlayerPrefs.SetFloat("curDamage", damage);
      PlayerPrefs.SetInt("inventoryLimit", inventoryLimit);
      PlayerPrefs.SetString("curPath", curPath);
      chance = 0;
      resist = 0;
    }
    public static void loadAllData(){
   		
   		level = PlayerPrefs.GetInt("playerLevel");
   		exp = PlayerPrefs.GetInt("playerExp");
   		expReq = PlayerPrefs.GetInt("playerExpReq");
    	money = PlayerPrefs.GetInt("playerMoney");
    	hp = PlayerPrefs.GetFloat("playerHp");
    	maxHp = PlayerPrefs.GetFloat("maxPlayerHp");
    	money = PlayerPrefs.GetInt("playerMoney");
    	damage = PlayerPrefs.GetFloat("curDamage");
      inventoryLimit = PlayerPrefs.GetInt("inventoryLimit");
      curPath = PlayerPrefs.GetString("curPath");
      Debug.Log("info loaded");
      Debug.Log("Money: " + money);
      Debug.Log("level:" + level);
      Debug.Log("exp: " + exp);
      Debug.Log("exp req: " + expReq);
      Debug.Log("hp: " + hp);
      Debug.Log("maxhp: " + maxHp);
      Debug.Log("inventoryLimit: " + inventoryLimit);
      Debug.Log("curPath: " + curPath);
    	loader loader = new loader();
    	currentWeap = loader.loadWeapon(curPath);
      chance = 0;
      resist = 0;
    }
    public static float calculateDamage(){
    	float damage = 0;
      int r = Random.Range(0, 100);
      if (r <= 100){
        damage = currentWeap.baseDamage + ambDamage + Random.Range(0, 1);
        }else damage = currentWeap.baseDamage + Random.Range(0, 1);
    	
    	return damage;
    }
    
    public static void checkForDeath(){
    	if (hp <= 0){
    		Debug.Log("dead");
        dead = true;
    	}
    }
    public static void updateInventory(){
    	
    }
    public static void manageExp(){

    	while (exp >= expReq){

    		exp -= expReq;
    		level++;
        maxHp += maxHp / 5;
    		expReq *= 2;
        isDropping = true;
    	}
    }
    public static float generateDamage(){
    	float effectDamage = currentWeap.effectDamage;
    	return effectDamage;
    }
    public static void find(string path, string pP){
        string[] paths = new string[inventoryLimit];
        for (int i = 0; i < inventoryLimit; ++i){
                paths[i] = PlayerPrefs.GetString(pP + i);
                Debug.Log ("path is " + paths[i]);
                if (paths[i] == path){
                    Debug.Log("gotcha!");
                    PlayerPrefs.DeleteKey(pP + i);
                } 
                
            }
    }
    public static void cleanInventoryEntries(){
        for (int i = 0; i < 100; ++i){
          PlayerPrefs.DeleteKey("inventory" + i);
        }
    }
    public static void cheats(){
      money = 100000;
    }
}
