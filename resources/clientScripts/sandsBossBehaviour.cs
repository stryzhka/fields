using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sandsBossBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject waypoint;
    public GameObject player;
    public float speed;
    public int exp;
    public float damage;
    public string listPath;
    public GameObject box;
   	public string dir;
   	public bool goPlayer;
   	public int eChance;
   	public RectTransform weapons;
   	public float time;
   	public minionSpawner mS1;
   	public minionSpawner mS2;
   	public float min;
   	public bool canHitBoss;
   	public float waitTime;
   	public float hp;
   	public bool canHit;
   	public bool active;
    public Slider hpSlid;
    public GameObject hpUi;

    void Start()
    {
        
        canHit = true;
        canHitBoss = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) moving();
        hpSlid.value = hp;
    }
    public IEnumerator waitPlay(float time){

        
        yield return new WaitForSeconds(time);
    }
    public IEnumerator wait(){
    	
	    	canHit = false;
	    	if (playerStats.currentWeap.type != "ranged")
	    	player.GetComponent<soundController>().hit.Play();
	    	yield return new WaitForSeconds(playerStats.currentWeap.delay);

	    	canHit = true;
    	
    	
    }
    public IEnumerator waitEnemy(){
    	
	    	canHitBoss = false;
	    	yield return new WaitForSeconds(waitTime);
	    	canHitBoss = true;
    	
    	
    }
    public IEnumerator direction(){
    	while(true){
    		yield return new WaitForSeconds(time);
    		dir = "l";
    		yield return new WaitForSeconds(time);
    		dir = "r";
    		yield return new WaitForSeconds(time);
    		dir = "p";
    		mS1.spawn();
    		mS2.spawn();
    	}
    }
    void moving(){
    	switch(dir){
    		case "l":
    			transform.position += Vector3.left * Time.deltaTime * speed;
    			break;
    		case "r":
    			transform.position += Vector3.right * Time.deltaTime * speed;
    			break;	
    		case "p":
    			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    			if (Vector2.Distance(player.transform.position, transform.position) <= min){
    				attack();
    			}
    			break;
    	}
    	
    }

    void calculateDrop(){
        loader loader = new loader();
        string drop = loader.loadList(listPath);
        print ("DROP: " + drop);
        GameObject _box = Instantiate(box, player.transform.position, Quaternion.identity);
        switch(drop){
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
    void attack(){
    	int r = Random.Range(0, 100);
        float temp = damage / 100 * playerStats.resist;
        float _damage = damage - temp;
        print("tempBoss: " + temp);
        print("_damageBoss: " + _damage);
            print(canHitBoss);
			if (canHitBoss){
                
                if (r <= 55){
                    print ("attacking!");  
                        playerStats.hp -= _damage;
                        //StartCoroutine(rotate());
                
                }else print ("not attacking(");
				
				StartCoroutine(waitEnemy());
			}//else print ("waiting");
			
		}
	void OnMouseDown(){
    	//print (canHit);
        
    	getDamage("ranged");
        
	}
    public void getDamage(string type){
        if (playerStats.currentWeap.type != type){
            if (type == "ranged" && Vector2.Distance(transform.position, player.transform.position) <= min){
            calcDamage("ranged");
            StartCoroutine(waitPlay(playerStats.currentWeap.delay));
            
            }else if (type == ""){
                calcDamage("");
                
               
                
                
            }
        deathCheck();
        }
    }
    void calcDamage(string t){
        int crit = Random.Range(0, 100);
        if (canHit){
                player.GetComponent<soundController>().zapSound.Stop();
                float damage = playerStats.calculateDamage();
                    print ("critical: " + playerStats.critical);
                    if (crit <= playerStats.critical){
                    print ("CRITICAL HIT!");
                    hp -= damage * 2.5f;
                    }else
                    hp -= damage;    
                if (t == "ranged")
                StartCoroutine(wait());

                if (playerStats.currentWeap.type != "ranged") canHitBoss = false;
            }
            
    }
    void deathCheck(){
    	if (hp <= 0){
    		playerStats.exp += exp;
    		print ("SANDS BOSS KILLED");
            hpUi.SetActive(false);
    		Destroy(gameObject);
            waypoint.SetActive(true);
            PlayerPrefs.SetInt("toGigapolis", 1);
    	}
    }
}
