using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class enemyFollow : MonoBehaviour
{
    public GameObject player;
    public string type;
    public int level;
    public int minDist;
    public int maxDist;
    public int movingSpeed;
    public float hp;
    public float damage;
    public Text hpText;
    public Canvas canvas;
    public GameObject dmgText;
    private bool canHit;
    private bool canHitEnemy;
    public bool burning;
    public bool slagged;
    private int timer;
    public string drop;
    public int uChance;
    public Button _button;
    public string weaponPath;
    public RectTransform weapons;
    public GameObject box;
    public string listPath;
    public int eChance;
    public int gM;
    public bool zapped;
    public int zapSpeed;
    public GameObject money;
    public float waitTime;
    public GameObject zapEffect;
    public GameObject fireEffect;
    public GameObject uiControl;
    public bool running;
    public int runTime;
    public bool spotted;
    void Start()
    {
        canHit = true;
        canHitEnemy = true;
        burning = false;
        zapped = false;
        zapSpeed = movingSpeed / 2;
        timer = 5;
        running = true;
        StartCoroutine(effectsCheck());
    }

    public IEnumerator wait(){
    	
	    	canHit = false;
	    	
	    	
	    	yield return new WaitForSeconds(playerStats.currentWeap.delay);
	    	canHit = true;
    	
    	
    }
    public IEnumerator waitEnemy(){
    	
	    	canHitEnemy = false;
	    	yield return new WaitForSeconds(waitTime);
	    	canHitEnemy = true;
    	
    	
    }
    public IEnumerator waitRun(){
        
            running = false;
            yield return new WaitForSeconds(waitTime);
            running = true;
        
        
    }
    public IEnumerator rotate(){
        
            uiControl.GetComponent<uiUpdater>().doRotating = true;
            yield return new WaitForSeconds(1f);
            uiControl.GetComponent<uiUpdater>().doRotating = false;
        
        
    }
    public IEnumerator effectsCheck(){
    	while (timer > 0){
				if (burning){
					print ("ouch! burned");
		    		hp -= playerStats.currentWeap.effectDamage;
		    		timer--;
                    deathCheck();

		    		
		    	}
                if (zapped){
                    print ("ouch! zapped");
                    //hp -= playerStats.currentWeap.effectDamage;
                    timer--;
                    deathCheck();

                    
                }
                if (slagged){
                    print ("not ouch! slagged but living!");
                    //hp -= playerStats.currentWeap.effectDamage;
                    timer--;
                    deathCheck();
                    
                }
		    	if (timer <= 0 ){
                    burning = false;
                    zapped = false;
                    slagged = false;
                    print ("timer: " + timer);
                } //else print ("phew");
		    	yield return new WaitForSeconds(1f);
	    	}
    }
    
    void giveExp(){
        if (playerStats.level < 31){
           if (level > playerStats.level){
                print ("monster > you");
                int r = level - playerStats.level;
                
                playerStats.exp += r * 2;

            }
            if (level < playerStats.level){
                print ("monster < you");
                int r = playerStats.level - level;
                if (r > 10)
                playerStats.exp += 1;
                else playerStats.exp += r / level + 2;
                

            }
            if (level == playerStats.level){
                print ("=");
                playerStats.exp += level;
                

            } 
        }
        	
        	
    }
    void calculateDrop(){
        loader loader = new loader();

        string drop = loader.loadList(listPath);
        print ("DROP: " + drop);
        switch(drop){
            case "hp":
                GameObject _box = Instantiate(box, player.transform.position, Quaternion.identity);
                _box.name = "hp";
                break;
            default:
                _box = Instantiate(box, player.transform.position, Quaternion.identity);
                _box.name = "weapon";
                int random = Random.Range(0, 100);

                _box.GetComponent<clickable>().weaponPath = drop;
                string[] effects = new string[3];
                effects[0] = "fire"; 
                effects[1] = "zap";
                effects[2] = "slag";
                if (random <= eChance){
                    if (_box.GetComponent<clickable>().effect == "fire" || _box.GetComponent<clickable>().effect == "zap" || _box.GetComponent<clickable>().effect == "slag")
                    print ("sorry");
                    else _box.GetComponent<clickable>().effect = effects[Random.Range(0, 3)];
                    } 
                print("PATH: " + _box.GetComponent<clickable>().weaponPath);
                _box.GetComponent<clickable>().weapons = weapons;
                player.GetComponent<inventoryManager>().isActive = true;
                player.GetComponent<inventoryManager>().ambManager.GetComponent<ambitionManager>().isActive = true;
                break;

        }
        
        
    }
    void dropItem(){
    	int random = Random.Range(0, 100);
        print ("RANDOM: " + random);
    	if (random <= uChance){
                calculateDrop();
    		}else print("nothing");
    }
    void deathCheck(){
    	if (hp <= 0){
            dropItem();
            giveExp();
            playerStats.money += level * 10;
            playerStats.manageExp();
        	Destroy(gameObject);
        	
        }
    }
    void Update()
    {
        follow();
        
    	
        if (burning)
        hpText.text = hp + " BRN!";
        else if (zapped)
        hpText.text = hp + " ZAP!";
        else if (slagged)
        hpText.text = hp + " SLG!";

        else hpText.text = hp.ToString();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void follow(){
       
    	if (Vector2.Distance(player.transform.position, transform.position) <= maxDist){
            //spotted = false;
            attack();
            if (!zapped)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movingSpeed*Time.deltaTime);
            else transform.position = Vector2.MoveTowards(transform.position, player.transform.position, zapSpeed*Time.deltaTime);
        }
    	   
    	//transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void OnMouseDown(){
    	//print (canHit);
        
    	getDamage("ranged");
	}
    public void getDamage(string type){
        if (playerStats.currentWeap.type != type){
            if (type == "ranged" && Vector2.Distance(transform.position, player.transform.position) <= minDist){
            calcDamage();
            
            }else if (type == ""){
                calcDamage();
                maxDist = 10;
                //canHitEnemy = true;
                
                
            }
        deathCheck();
        }
    }
    void calcDamage(){
        if (canHit){
                player.GetComponent<soundController>().zapSound.Stop();
                
                if (slagged){
                    if (playerStats.currentWeap.effect == "slag") hp -= playerStats.calculateDamage();
                    else hp -= playerStats.calculateDamage() * 2;
                }
                else{
                    float damage = playerStats.calculateDamage();
                    hp -= damage;    

                } 
                switch(playerStats.currentWeap.effect){
                    case "fire": 
                        float random = Random.Range(0, 100);
                        random -= playerStats.chance;
                        if (random <= playerStats.currentWeap.effectChance){
                            effectDamage("fire");
                            
                        }else print ("Random: " + random);
                        break;
                    case "zap":
                        random = Random.Range(0, 100);
                        random -= playerStats.chance;
                        if (random <= playerStats.currentWeap.effectChance){
                            effectDamage("zap");
                            
                        }else print ("Random: " + random);
                        break;
                    case "slag":
                        random = Random.Range(0, 100);
                        random -= playerStats.chance;
                        if (random <= playerStats.currentWeap.effectChance){
                            effectDamage("slag");
                            
                        }else print ("Random: " + random);
                        break;
                }
                if (playerStats.currentWeap.effect == "normal"){
                    float r = Random.Range(0, 100);
                    print ("Chance: " + playerStats.chance);
                    print ("random: " + r);
                    if (r <= playerStats.chance){
                        effectDamage("fire");
                    }
                }
                //print (hp);
                player.GetComponent<soundController>().hit.Play();
                StartCoroutine(wait());
                if (playerStats.currentWeap.type != "ranged") canHitEnemy = false;
            }
            
    }
	void attack(){

        float temp = damage / 100 * playerStats.resist;
        float _damage = damage - temp;
        print("temp: " + temp);
        print("_damage: " + _damage);
		if (Vector2.Distance(player.transform.position, transform.position) <= minDist){
            print(canHitEnemy);
			if (canHitEnemy){
				print ("attacking!");
                if (!burning){
                    //StartCoroutine(waitEnemy());
                    
                    playerStats.hp -= _damage;
                    StartCoroutine(rotate());
                }
				
				else playerStats.hp -= _damage / 2;
				StartCoroutine(waitEnemy());
			}//else print ("waiting");
			
		}
	}
    void effectDamage(string type){
        if (type == "fire"){
             print ("BURNING!");
             burning = true;
             GameObject _fireEffect = Instantiate(fireEffect, transform.position, Quaternion.identity);
        }
        if (type == "zap"){
            print ("ZAPPED!");
            zapped = true;
            player.GetComponent<soundController>().zapSound.Play();
            GameObject _zapEffect = Instantiate(zapEffect, transform.position, Quaternion.identity);
        }
        if (type == "slag"){
            print ("SLAGGED!");
            slagged = true;
        }
    }
}
