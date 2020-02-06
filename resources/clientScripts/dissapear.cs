using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissapear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destr());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destr(){
    	yield return new WaitForSeconds(1f);
    	Destroy(transform.parent.gameObject);
    }
}
