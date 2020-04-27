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
    public bool minion;
    public AudioSource minionS;
    public AudioClip minionSl;
    public float radius;
    public bool stop;
    public List<GameObject> guts;
    public int gore;
    void Start()
    {
        canHit = true;
        canHitEnemy = true;
        burning = false;
        zapped = false;
        zapSpeed = movingSpeed / 2;
        timer = 5;
        running = true;
            player = GameObject.Find("player");
        StartCoroutine(effectsCheck());
        gore = PlayerPrefs.GetInt("gore");
        print ("gore: " + gore);
    }

    public IEnumerator wait(){
    	
	    	canHit = false;
	    	if (playerStats.currentWeap.type != "ranged")
	    	player.GetComponent<soundController>().hit.Play();
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
        
            player.GetComponent<uiUpdater>().doRotating = true;
            yield return new WaitForSeconds(1f);
            player.GetComponent<uiUpdater>().doRotating = false;
        
        
    }
    public IEnumerator effectsCheck(){
    	while (timer > 0){
				if (burning){
					print ("ouch! burned");
		    		hp -= playerStats.currentWeap.effectDamage + playerStats.bonusEffectDamage;
		    		timer--;
                    deathCheck();

		    		
		    	}
                if (zapped){
                    print ("ouch! zapped");
                    hp -= playerStats.bonusEffectDamage;
                    //hp -= playerStats.currentWeap.effectDamage;
                    timer--;
                    deathCheck();

                    
                }
                if (slagged){
                    print ("not ouch! slagged but living!");
                    hp -= playerStats.bonusEffectDamage;;
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
    public IEnumerator waitPlay(float time){

        
        yield return new WaitForSeconds(time);
    }

    public IEnumerator waitExplode(float time){

        stop = true;
        yield return new WaitForSeconds(1f);
                GameObject _fireEffect = Instantiate(fireEffect, transform.position, Quaternion.identity);
                print ("EXPLODINGS");
                Destroy(gameObject);
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
                int i = 0;
                while (i < hitColliders.Length)
                {
                    print (hitColliders[i]);
                    if (hitColliders[i].gameObject.tag == "Player")
                    playerStats.hp -= damage;
                    if (hitColliders[i].gameObject.tag == "enemy")
                    hitColliders[i].GetComponent<enemyFollow>().hp -= damage;
                    i++;
                }
    }
    
    void giveExp(){
        if (playerStats.level < 31){
           if (level > playerStats.level){
                print ("monster > you");
                int r = level - playerStats.level;
                int r2 = r * 2;
                playerStats.exp += level - 1 + r2 * 2;

            }
            if (level < playerStats.level){
                print ("monster < you");
                float r = playerStats.level - level;
                if (r > 3f)
                playerStats.exp += 1;
                else if (r == 1){
                    playerStats.exp += level;
                }
                else{
                    if ((int) Mathf.Round(r / level) <= 0)
                    playerStats.exp += 1;
                    else playerStats.exp += (int) Mathf.Round(r / level);
                    } 
                
                

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
                //player.GetComponent<inventoryManager>().isActive = true;
                //player.GetComponent<inventoryManager>().ambManager.GetComponent<ambitionManager>().isActive = true;
                break;

        }
        
        
    }
    void dropItem(){
    	int random = Random.Range(0, 100);
        print ("RANDOM: " + random);
    	if (random <= uChance){
                if (!minion) calculateDrop();
    		}else print("nothing");
    }
    void deathCheck(){
    	if (hp <= 1){
            dropItem();
            giveExp();
            playerStats.money += level * 10;
            playerStats.manageExp();
            if (gore == 0) print("ok");
            else if (gore == 1){
                GameObject gut = Instantiate(guts[guts.Count - 1] , transform.position, Quaternion.identity);
                if (burning) Destroy(gut);
            }else if (gore == 2){
                int j = 0;
                foreach (GameObject g in guts){
                    if (j < 3){
                        GameObject gut = Instantiate(g, transform.position, Quaternion.identity);
                        gut.transform.Rotate(new Vector3(0,0,Random.Range(-360,360)));
                        print ("burning death");
                        gut.GetComponent<SpriteRenderer>().color = Color.black;
                        
                    }
                    
                    j++;
                }
            }else{
                int j = 0;
                foreach (GameObject g in guts){
                    
                    if (burning){
                        if (j < 3){
                            GameObject gut = Instantiate(g, transform.position, Quaternion.identity);
                            gut.transform.Rotate(new Vector3(0,0,Random.Range(-360,360)));
                            print ("burning death");
                            gut.GetComponent<SpriteRenderer>().color = Color.black;
                        }
                            j++;
                        }else{
                            GameObject gut = Instantiate(g, transform.position, Quaternion.identity);
                            gut.transform.Rotate(new Vector3(0,0,Random.Range(-360,360)));
                        }
                }  
            }
            
        	Destroy(gameObject);

        	
        }
    }
    void Update()
    {   if (!stop)
        follow();
        float uiHp = ((int)(hp*10)/10);
    	if (uiHp == 0) uiHp = 1;
        if (burning)
        hpText.text = uiHp + " burned!";
        else if (zapped)
        hpText.text = uiHp + " zapped!";
        else if (slagged)
        hpText.text = uiHp + " slagged!";

        else hpText.text = uiHp.ToString();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void follow(){
        if (minion){
            attack();
            if (!zapped)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movingSpeed*Time.deltaTime);
            else transform.position = Vector2.MoveTowards(transform.position, player.transform.position, zapSpeed*Time.deltaTime);
        }
        
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
            calcDamage("ranged");
            StartCoroutine(waitPlay(playerStats.currentWeap.delay));
            
            }else if (type == ""){
                calcDamage("");
                maxDist = 10;
                //canHitEnemy = true;
                
                
            }
        deathCheck();
        }
    }
    void calcDamage(string t){
        int crit = Random.Range(1, 100);
        Vector3 posR = new Vector3(Random.Range(-0.2f,1), Random.Range(-0.2f,1), 0);
        if (canHit){
                player.GetComponent<soundController>().zapSound.Stop();
                float damage = playerStats.calculateDamage();
                if (slagged){
                    if (playerStats.currentWeap.effect == "slag") hp -= damage;
                    else hp -= damage * 2;

                }
                else{
                    print ("critical: " + playerStats.critical);
                    if (crit <= playerStats.critical){
                    print ("CRITICAL HIT!");
                    hp -= damage * 2.5f;
                    
                    GameObject critText = Instantiate(player.GetComponent<initCanvas>().canvas.gameObject, transform.position + posR, Quaternion.identity);
                    critText.transform.GetChild(0).GetComponent<Text>().text = "CRITICAL!";
                    critText.transform.GetChild(0).GetComponent<Text>().color = Color.red;
                    }else
                    
                    hp -= damage;    
                    GameObject c = Instantiate(player.GetComponent<initCanvas>().canvas.gameObject, transform.position + posR, Quaternion.identity);
                    c.transform.GetChild(0).GetComponent<Text>().text = ((int)(damage*10)/10).ToString();
                    switch(playerStats.currentWeap.effect){
                        case "fire":
                            Color temp = new Color(255 / 256f, 165/256f, 0);
                            c.transform.GetChild(0).GetComponent<Text>().color = temp;
                            break;
                        case "zap":
                            c.transform.GetChild(0).GetComponent<Text>().color = Color.yellow;
                            break;

                        case "slag":
                            c.transform.GetChild(0).GetComponent<Text>().color = Color.magenta;
                            break;
                    }
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
                    float r = Random.Range(1, 100);
                    print ("Chance: " + playerStats.chance);
                    print ("random: " + r);
                    if (r <= playerStats.chance){
                        
                        effectDamage("fire");
                    }
                }
                //print (hp);
                if (t == "ranged")
                StartCoroutine(wait());

                if (playerStats.currentWeap.type != "ranged") canHitEnemy = false;
            }
            
    }
	void attack(){
        int r = Random.Range(0, 100);
        float temp = damage / 100 * playerStats.resist;
        float _damage = damage - temp;
        print("temp: " + temp);
        print("_damage: " + _damage);
		if (Vector2.Distance(player.transform.position, transform.position) <= minDist){
            print(canHitEnemy);
            if (minion){
                StartCoroutine(waitExplode(1f));
            }
			if (canHitEnemy){
                
                if (r <= 55){
                    print ("attacking!");
                    if (!burning){
                        //StartCoroutine(waitEnemy());
                        
                        playerStats.hp -= _damage;
                        StartCoroutine(rotate());
                    }
                
                else playerStats.hp -= _damage / 2;
                }else print ("not attacking(");
				
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
