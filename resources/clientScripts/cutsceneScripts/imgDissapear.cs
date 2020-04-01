using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imgDissapear : MonoBehaviour
{

    public bool smoothing;
    void Start()
    {
        StartCoroutine(wait(1));
    }

    // Update is called once per frame
    void Update()
    {
    	if (smoothing) smooth();
    }
    void smooth(){
    	Color tmp = gameObject.GetComponent<SpriteRenderer>().color;
		tmp.a += Time.deltaTime;
		gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }
    public IEnumerator wait(float time){
    		print ("test");
    		yield return new WaitForSeconds(time);
    		gameObject.SetActive(true);
    		smoothing = true;
			
    	
    }
}
