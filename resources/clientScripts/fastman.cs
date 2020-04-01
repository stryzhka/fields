using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastman : MonoBehaviour
{
    public Transform player;
    public float speed;
    public RectTransform weapons;
    public GameObject box;
    public bool isFacing;
    public float delay;
    public bool isAttacking;
    public float min, max;
    public GameObject bullet;
    public float hp;
    public int level;
    public string listPath;
    void Start()
    {
    	StartCoroutine(shoot(1)); 
    	StartCoroutine(wait(0.5f)); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(player.transform.position, transform.position) <= max){
        	follow();
        }
        deathCheck();

    }
    void follow(){
    	if (isFacing){
        	transform.position = Vector2.MoveTowards(transform.position, -player.transform.position, speed * Time.deltaTime);
        	
        }else{
        	transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        float angle = 0;
        Vector3 relative = transform.InverseTransformPoint(player.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0,0, -angle);
    }
    public IEnumerator wait(float time){
    	while(true){
    		isFacing = true;
	    	yield return new WaitForSeconds(time);
	    	print (isFacing);
	    	isFacing = false;
    	}
    	
    }
    public IEnumerator shoot(float time){
    	 while (true)
        {
            yield return new WaitForSeconds(time);
            print("WaitAndPrint " + Time.time);
            GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
            _bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 2.0f);
            _bullet.transform.position = Vector2.MoveTowards(_bullet.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    	
    }
    void OnMouseDown(){
    	if(Vector2.Distance(transform.position, player.transform.position) <= min){
    		float damage = playerStats.calculateDamage();
            hp -= damage;  
    	}
    }
    void deathCheck(){
    	if (hp <= 0){
            calculateDrop();
            giveExp();
            playerStats.money += playerStats.level * 30;
            playerStats.manageExp();
        	Destroy(gameObject);
        	
        }
    }
    void calculateDrop(){
        loader loader = new loader();

        string drop = loader.loadList(listPath);

                box = Instantiate(box, player.transform.position, Quaternion.identity);
                box.name = "weapon";
                int random = Random.Range(0, 100);

                box.GetComponent<clickable>().weaponPath = drop;
                print("PATH: " + box.GetComponent<clickable>().weaponPath);
                box.GetComponent<clickable>().weapons = weapons;
                player.GetComponent<inventoryManager>().isActive = true;
                player.GetComponent<inventoryManager>().ambManager.GetComponent<ambitionManager>().isActive = true;
                


        
        
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
    
}
