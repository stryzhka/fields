using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn(){
    	Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
    	enemy.GetComponent<enemyFollow>().minion = true;
    }
}
