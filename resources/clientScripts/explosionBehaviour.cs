using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(-0.1f * Time.deltaTime, -0.1f * Time.deltaTime, 0.0f);
        transform.Rotate(0.0f, 0.0f, 1000.0f * Time.deltaTime, Space.World);
        Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
		tmp.a -= Time.deltaTime;
		gameObject.GetComponent<SpriteRenderer>().color = tmp;
        if (tmp.a < 0.0f) Destroy (gameObject);
    }
    void OnCollisionEnter2D(Collision2D col){
    	if (col.gameObject.tag == "enemy"){
    		col.gameObject.GetComponent<enemyFollow>().hp -= damage;
    	}
    }
}
