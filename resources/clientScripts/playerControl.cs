using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public int movingSpeed;
    public int fastSpeed;
    bool isAndr;
    void Start()
    {
        #if UNITY_ANDROID
        isAndr = true;
        #else
        isAndr = false;
        #endif
    }

    
    void Update()
    {	
    	if (Input.GetMouseButton(0)){
            var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetKey("2")){
                if (isAndr)
                transform.position = Vector2.MoveTowards(transform.position, target, playerStats.speed*Time.deltaTime); 
                else{
                    transform.position = Vector2.MoveTowards(transform.position, target, fastSpeed*Time.deltaTime); 
                } 
                
            }else {
                if (isAndr)
                transform.position = Vector2.MoveTowards(transform.position, target, playerStats.speed*Time.deltaTime);   
                else{
                    if (playerStats.currentWeap.rareID == "speed"){
                        transform.position = Vector2.MoveTowards(transform.position, target, fastSpeed*Time.deltaTime); 
                    }else
                    transform.position = Vector2.MoveTowards(transform.position, target, movingSpeed*Time.deltaTime); 
                }
                
            }
    		
    	}
        transform.rotation = Quaternion.Euler(0, 0, 0);
    	 //
    }
    
}
