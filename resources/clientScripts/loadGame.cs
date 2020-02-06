using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadGame : MonoBehaviour
{
    // Start is called before the first frame 
    void Start()
    {
		gameObject.GetComponent<Button>().onClick.AddListener(click);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void click(){
    	playerStats.loadAllData();
    	SceneManager.LoadScene("city1", LoadSceneMode.Single);
    }
}
