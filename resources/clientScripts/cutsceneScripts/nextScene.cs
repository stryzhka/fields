using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextScene : MonoBehaviour
{
    public GameObject face;
    public GameObject text;
    public List<GameObject> graphics;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(next);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void next(){
    	foreach (GameObject g in graphics) Destroy(g);
    	face.SetActive(true);
    	text.SetActive(true);
    	Destroy(gameObject);
    }
}
