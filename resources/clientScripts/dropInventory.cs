using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropInventory : MonoBehaviour
{
    
    void Start()
    {
    		gameObject.GetComponent<Button>().onClick.AddListener(clean);
    	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void clean(){
    	for (int i = 0; i < playerStats.inventoryLimit; ++i){
    			PlayerPrefs.DeleteKey("inventory" + i);
    		}
    }
}
