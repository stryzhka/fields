using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponRotating : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        transform.Rotate(0.0f, 0.0f, 100.0f * Time.deltaTime, Space.World);
        if (transform.eulerAngles.z > 90.0f) transform.Rotate(0.0f, 0.0f, -100.0f * Time.deltaTime, Space.World);
        
        
    }
    void OnMouseDown(){
        
    }
}
