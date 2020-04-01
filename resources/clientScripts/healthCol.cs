using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCol : MonoBehaviour
{
    public float hp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D (Collision2D col){
    	print ("collision");
    	if (col.gameObject.tag == "Player"){
    		if (playerStats.hp + hp > playerStats.maxHp){
                    playerStats.hp += playerStats.maxHp - playerStats.hp;
                    Destroy(gameObject);
                }
				else{
					playerStats.hp += hp;
					Destroy(gameObject);
				}

    	}
    }
}
