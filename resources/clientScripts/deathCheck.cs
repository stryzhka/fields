using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerStats.checkForDeath();
        if (playerStats.dead){
    		SceneManager.LoadScene("city1", LoadSceneMode.Single);
    		playerStats.dead = false;
        }
    }
}
