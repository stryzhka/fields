using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtainAble : MonoBehaviour
{
    public float hp;
    public int resCount;
    public string resType;
    public float minDist;
    public GameObject player;
    public AudioClip hit;
    public AudioSource hitS;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        print ("hey");
        print(playerStats.currentWeap.instr);
        if (playerStats.currentWeap.type != "ranged" && Vector2.Distance(transform.position, player.transform.position) <= minDist){
            obtain();
        }
    }

    void obtain(){
        hp -= playerStats.calculateDamage();
        hitS.PlayOneShot(hit, 1f);
        if (hp <= 0){
            switch(resType){
                case "wood":
                    resStats.woodCount += resCount;
                    break;

                case "iron":
                    if (playerStats.currentWeap.instr == "pick")
                    resStats.ironCount += resCount;
                    else print ("no no no)");
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}
