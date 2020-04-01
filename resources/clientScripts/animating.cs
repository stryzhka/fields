using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animating : MonoBehaviour
{
    public List<Sprite> states;
    int iter;
    void Start()
    {
    	iter = 0;
        StartCoroutine(move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator move(){
    	while (true){
    		yield return new WaitForSeconds(0.5f);
    		
	    	gameObject.GetComponent<SpriteRenderer>().sprite = states[iter];
	    	iter++;
	    	if (iter >= states.Count) iter = 0;
	    	print ("state");
	    	
    	}
    	
    }
}
