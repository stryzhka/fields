using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pandora;
    public GameObject otello;
    public GameObject richlands;
    public GameObject bandits;
    public GameObject backgr;
    public GameObject text1;
    public GameObject text2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void toNext(){
    	pandora.SetActive(false);
    	otello.SetActive(false);
    	richlands.SetActive(false);
    	bandits.SetActive(false);
    	backgr.SetActive(false);
    	text1.SetActive(false);
    	text2.SetActive(true);
    }
}
