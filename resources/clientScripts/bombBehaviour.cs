using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBehaviour : MonoBehaviour
{
    public GameObject player;
    public float radius;
    public int damage;
    public GameObject fire;
    public int hp;
    void Start()
    {
        StartCoroutine(explode(2));
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
         //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1*Time.deltaTime);
    }
    public IEnumerator explode(float time){
    	yield return new WaitForSeconds(time);
    	Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
        	print (hitColliders[i]);
        	if (hitColliders[i].gameObject.tag == "Player")
            playerStats.hp -= damage;
            i++;
        }
       	Instantiate(fire, transform.position, Quaternion.identity);
    	Destroy(gameObject);
    }

    
}
