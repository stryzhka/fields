using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public int movingSpeed;
    public int fastSpeed;
    void Start()
    {
        #if UNITY_ANDROID
        gameObject.GetComponent<playerControl>().enabled = false;
        #else
        gameObject.GetComponent<playerControl>().enabled = true;
        #endif
    }

    
    void Update()
    {	
    	if (Input.GetMouseButton(0)){
            var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetKey("2")){
                transform.position = Vector2.MoveTowards(transform.position, target, fastSpeed*Time.deltaTime); 
            }else {
                
                transform.position = Vector2.MoveTowards(transform.position, target, movingSpeed*Time.deltaTime);   
            }
    		
    	}
        transform.rotation = Quaternion.Euler(0, 0, 0);
    	 //
    }
    
}
