using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mobileMoving : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public string direction;
    public Transform player;
    bool active;
    void Start()
    {
    	playerStats.speed = 3;
        player = GameObject.Find("player").transform;
        #if UNITY_ANDROID
		gameObject.SetActive(true);
		#else
		gameObject.SetActive(false);
		#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        move();
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void move(){
    	if (direction == "up"){
    		player.Translate(Vector2.up * playerStats.speed *  Time.deltaTime, Space.World);
    	}
    	if (direction == "down"){
    		player.Translate(Vector2.down * playerStats.speed *  Time.deltaTime, Space.World);
    	}
    	if (direction == "left"){
    		player.Translate(Vector2.left * playerStats.speed *  Time.deltaTime, Space.World);
    	}
    	if (direction == "right"){
    		player.Translate(Vector2.right * playerStats.speed *  Time.deltaTime, Space.World);
    	}
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
         move();
         active = true;
         transform.rotation = Quaternion.Euler(0, 0, 0);
        
   }
   public void OnPointerExit(PointerEventData eventData)
    {
        print ("!move");
        active = false;
    }
}
