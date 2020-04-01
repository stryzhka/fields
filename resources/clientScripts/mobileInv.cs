using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mobileInv : MonoBehaviour
{
	GameObject player;
	GameObject ambManager;
    // Start is called before the first frame update
    void Start()
    {
    	#if UNITY_ANDROID
		gameObject.SetActive(true);
		#else
		gameObject.SetActive(false);
		#endif
        player = GameObject.Find("player");
        ambManager = GameObject.Find("ambManager");
        gameObject.GetComponent<Button>().onClick.AddListener(open);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void open(){
    	if (player.GetComponent<inventoryManager>().isActive){
				player.GetComponent<inventoryManager>().isActive = false;
				ambManager.GetComponent<ambitionManager>().isActive = false;
    		}else{
    			player.GetComponent<inventoryManager>().isActive = true;
    			ambManager.GetComponent<ambitionManager>().isActive = true;
    		}
    	
    }
}
