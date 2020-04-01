using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float speed;
    public Camera camera;
    public LineRenderer lineRenderer;
    public float delay;
    public AudioSource shot;
    public AudioClip shotSound;
    float nextFire;
    Color startColor;
    bool isAndroid;
    public bool isShooting;
    public GameObject crossh;
    void Start()
    {
        camera = GameObject.Find("playerCamera").GetComponent<Camera>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        nextFire = 0;
        startColor = lineRenderer.startColor;
        #if UNITY_ANDROID
        isAndroid = true;
        #else
        isAndroid = false;
        #endif
        crossh = GameObject.Find("crosshair");
        //isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isAndroid)
        if (Input.GetMouseButton(1)){
        	if (playerStats.currentWeap.type == "ranged"){
        		if (Time.time >= nextFire){
	        		shoot();
                    float b = playerStats.currentWeap.delay / 100 * playerStats.bonusSpeed; 
	        		nextFire = Time.time + playerStats.currentWeap.delay - b;
        		}
        	}
        	
        }
        //isShooting = false;
        if (isAndroid) 
        if (Input.GetMouseButton(0)){
            //isShooting = true;
            
            RaycastHit2D h = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (h.collider != null && h.collider.gameObject.tag == "enemy" || h.collider != null && h.collider.gameObject.tag == "boss")
            if (playerStats.currentWeap.type == "ranged"){
                if (Time.time >= nextFire){
                    shoot();
                    float b = playerStats.currentWeap.delay / 100 * playerStats.bonusSpeed; 
                    float temp = playerStats.currentWeap.delay - b;
                    print ("SPID:" + temp);
                    if (b < playerStats.currentWeap.delay)
                    nextFire = Time.time + playerStats.currentWeap.delay - b;
                    else nextFire = Time.time + 0.1f;
                }
            }
            
        }
        if (Input.GetMouseButtonDown(1)){
            isShooting = true;
        }
          
        else if (Input.GetMouseButtonUp(1)){
            isShooting = false;
        }
          
        Color tmp = lineRenderer.startColor;
		tmp.a -= Time.deltaTime;
		lineRenderer.startColor = tmp;
        if (isShooting){
            float b = playerStats.currentWeap.delay / 100 * playerStats.bonusSpeed; 
            float tempS = playerStats.currentWeap.delay - b;
            print ("SPID:" + tempS);
            Color temp = crossh.GetComponent<SpriteRenderer>().color;
            temp.a = 1.0f;
            crossh.GetComponent<SpriteRenderer>().color = temp;
            var pos = Input.mousePosition;
            pos.z = 45;
            crossh.transform.position =  Camera.main.ScreenToWorldPoint(pos);
            crossh.transform.localScale = new Vector3(playerStats.currentWeap.accuracy, playerStats.currentWeap.accuracy, 0);
            }else{
                Color temp = crossh.GetComponent<SpriteRenderer>().color;
                temp.a = 0.0f;
                crossh.GetComponent<SpriteRenderer>().color = temp;
            }
		//if (tmp.a == 0) 
        
    }
    void OnMouseUp()
    {
        //isShooting = false;
        Debug.Log("shooting ended!");
    }
    void shoot(){
        Vector2 pos = new Vector2();
        shot.PlayOneShot(shotSound, 0.7F);
    	float b = 0f;
        if (playerStats.currentWeap.accuracy > 0){
            b = playerStats.currentWeap.accuracy / 100 * playerStats.bonusAccuracy;
        }
        print ("bonusAccur for weapon:" + b);
    	lineRenderer.startColor = startColor;
        float temp = playerStats.currentWeap.accuracy - b;
        print ("ACCURACY: " + temp);
        	RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(Random.Range(0, playerStats.currentWeap.accuracy - b), Random.Range(0, playerStats.currentWeap.accuracy - b), 0), Vector2.zero);
        	lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            
            if (hit.collider != null){
        		print ("hit something");
        		
        		if (hit.collider.tag == "enemy"){
                    
        			print ("touched enemy");
        			hit.collider.gameObject.GetComponent<enemyFollow>().getDamage("");
                    
        		} 
                if (hit.collider.tag == "boss"){
                    print ("touched boss");
                    hit.collider.gameObject.GetComponent<sandsBossBehaviour>().getDamage("");
                }
        	}
    }
}
