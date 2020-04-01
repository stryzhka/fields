using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class descPosition : MonoBehaviour
{
 
    public bool isActive;
    public float[] numbers;
    void Start()
    {
        float[] numbers = new float[3];
    }

    // Update is called once per frame
    void Update()
    {
    	
    	
    	var pos = Input.mousePosition;
	    pos.z = 45;
	    transform.position =  Camera.main.ScreenToWorldPoint(pos) + new Vector3(numbers[0], numbers[1], numbers[2]);
    	
    	
    }
}
