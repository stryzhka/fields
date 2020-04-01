using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decorating : MonoBehaviour
{
    
    void Start()
    {
    	Sprite img = Resources.Load<Sprite>(playerStats.hatPath);
        gameObject.GetComponent<SpriteRenderer>().sprite = img;
        print("ps hat: " + playerStats.hatPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
