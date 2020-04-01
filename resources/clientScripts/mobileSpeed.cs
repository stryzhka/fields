using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mobileSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    bool running;
    void Start()
    {
        #if UNITY_ANDROID
		gameObject.SetActive(true);
		#else
		gameObject.SetActive(false);
		#endif

        gameObject.GetComponent<Button>().onClick.AddListener(run);
        print ("ладно.");
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void run(){
        if (running){
            running = false;
            playerStats.speed = 3;
            print ("squa");
        }else{
            running = true;
            playerStats.speed = 6;
        }
    }
}
