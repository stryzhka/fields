using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorating : MonoBehaviour
{
    public string type;
    void Start()
    {
        print("ps hat: " + playerStats.hatPath);
        
           Sprite img = Resources.Load<Sprite>(playerStats.hatPath); 
           gameObject.GetComponent<SpriteRenderer>().sprite = img;

        

        
    	
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
