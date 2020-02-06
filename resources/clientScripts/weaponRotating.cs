using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponRotating : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(-0.1f * Time.deltaTime, -0.1f * Time.deltaTime, 0.0f);
        transform.Rotate(0.0f, 0.0f, 1000.0f * Time.deltaTime, Space.World);
    }
}
