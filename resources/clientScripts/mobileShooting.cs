using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mobileShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Camera camera;
    public LineRenderer lineRenderer;
    public float delay;
    float nextFire;
    public AudioSource shot;
    public AudioClip shotSound;
    RaycastHit2D hit;
    void Start()
    {
    	player = GameObject.Find("player");
    	camera = GameObject.Find("playerCamera").GetComponent<Camera>();
    	lineRenderer = player.GetComponent<LineRenderer>();
    	gameObject.GetComponent<Button>().onClick.AddListener(checkShooting);
    	nextFire = 0;
        /*#if UNITY_ANDROID
		gameObject.SetActive(true);
		#else
		gameObject.SetActive(false);
		#endif*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void shoot(){
    	shot.PlayOneShot(shotSound, 0.7F);
    	Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.transform.position, 100);
    	int i = 0;
    	while (i < hitColliders.Length)
        {
        	if (hitColliders[i].gameObject.tag == "enemy"){
        		RaycastHit2D hit = Physics2D.Raycast(hitColliders[i].gameObject.transform.position + new Vector3(Random.Range(0, playerStats.currentWeap.accuracy), Random.Range(0, playerStats.currentWeap.accuracy), 0), Vector2.zero);
        	}
            i++;
        }
        	lineRenderer.SetPosition(1, hit.point);
            if (hit.collider != null){
        		print ("hit something");
        		
        		if (hit.collider.tag == "enemy"){
                    lineRenderer.SetPosition(0, transform.position);
        			print ("touched enemy");
        			hit.collider.gameObject.GetComponent<enemyFollow>().getDamage("");
                    
        		} 
        	}
    }
    void checkShooting(){
    	if (playerStats.currentWeap.type == "ranged"){
        		if (Time.time >= nextFire){
	        		shoot();
	        		print ("ok");
	        		nextFire = Time.time + playerStats.currentWeap.delay;
        		}
        	}
    }
}
