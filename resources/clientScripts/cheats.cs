using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheats : MonoBehaviour
{
    // Start is called before the first frame update
    bool dev;
    void Start()
    {
        dev = false;

    }

    // Update is called once per frame
    void Update()
    {  
        if (dev)
        if (Input.GetKeyDown("c")){
        	playerStats.cheats();
        }
    }
}
