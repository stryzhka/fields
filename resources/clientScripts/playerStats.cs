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
   public static int hp;
   public static int maxHp;
   public static int magicEnergy;
   public static int damage;
   public static int inventoryLimit;
   public static Weapon currentWeap;
   public static string curPath;
   public static List<Weapon> weapons;
   public static bool dead;
   public static void setDummyData(){
   	loader loader = new loader();
    cleanInventoryEntries();
   	level = 1;
   	expReq = 20;
   	exp = 1;
   	money = 100;
   	hp = 30;
   	magicEnergy = 30;
   	maxHp = 30;
   	damage = 3;
   	inventoryLimit = 5;
    curPath = "dataFiles/weapons/knife";
   	weapons = new List<Weapon>();
   	weapons.Add(loader.loadWeapon("dataFiles/weapons/knife"));
   	Debug.Log(weapons[0].name);
   	currentWeap = weapons[0];
    setAllData();
   }
   public static void setAllData(){
   		Debug.Log("Money: " + money);
      Debug.Log("level:" + level);
      Debug.Log("exp: " + exp);
      Debug.Log("exp req: " + expReq);
      Debug.Log("hp: " + hp);
      Debug.Log("maxhp: " + maxHp);
      Debug.Log("damage: " + damage);
      Debug.Log("inventoryLimit: " + inventoryLimit);
   		PlayerPrefs.SetInt("playerLevel", level);
   		PlayerPrefs.SetInt("playerExp", exp);
   		PlayerPrefs.SetInt("playerExpReq", expReq);
    	PlayerPrefs.SetInt("playerMoney", money);
    	PlayerPrefs.SetInt("playerHp", hp);
    	PlayerPrefs.SetInt("maxPlayerHp", maxHp);
    	PlayerPrefs.SetInt("curDamage", damage);
      PlayerPrefs.SetInt("inventoryLimit", inventoryLimit);
      PlayerPrefs.SetString("curPath", curPath);


    	//currentWeap = loadWeapons(PlayerPrefs.GetString("inventory1"));
    }
    public static void loadAllData(){
   		
   		level = PlayerPrefs.GetInt("playerLevel");
   		exp = PlayerPrefs.GetInt("playerExp");
   		expReq = PlayerPrefs.GetInt("playerExpReq");
    	money = PlayerPrefs.GetInt("playerMoney");
    	hp = PlayerPrefs.GetInt("playerHp");
    	maxHp = PlayerPrefs.GetInt("maxPlayerHp");
    	money = PlayerPrefs.GetInt("playerMoney");
    	damage = PlayerPrefs.GetInt("curDamage");
      inventoryLimit = PlayerPrefs.GetInt("inventoryLimit");
      curPath = PlayerPrefs.GetString("curPath");
      Debug.Log("info loaded");
      Debug.Log("Money: " + money);
      Debug.Log("level:" + level);
      Debug.Log("exp: " + exp);
      Debug.Log("exp req: " + expReq);
      Debug.Log("hp: " + hp);
      Debug.Log("maxhp: " + maxHp);
      Debug.Log("damage: " + damage);
      Debug.Log("inventoryLimit: " + inventoryLimit);
    	loader loader = new loader();
    	currentWeap = loader.loadWeapon(curPath);
    }
    public static int calculateDamage(){
    	int damage = 0;
    	damage += currentWeap.baseDamage;
    	return damage += Random.Range(0, 3);
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
    		expReq += 1;
        maxHp++;
    	}
    }
    public static int generateDamage(){
    	int effectDamage = currentWeap.effectDamage;
    	return effectDamage;
    }
    public static void find(string path){
        string[] paths = new string[5];
        for (int i = 0; i < inventoryLimit; ++i){
                paths[i] = PlayerPrefs.GetString("inventory" + i);
                Debug.Log ("path is " + paths[i]);
                if (paths[i] == path){
                    Debug.Log("gotcha!");
                    PlayerPrefs.DeleteKey("inventory" + i);
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
