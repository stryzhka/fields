using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutsceneDialog : MonoBehaviour
{
    public bool activated;
    public List<string> loc;
    public List<enemyFollow> enemies;
    public Text loc1t;
    public GameObject dialogUI;
    public Button next;
    public Text bText;
    int iter;
    public bool is1;
    public bool canTalk;
    public GameObject ui;
    public bool boss;
    public AudioSource mus;
    public sandsBossBehaviour s1;
    public List<GameObject> colliders;
    public GameObject hpUi;
    public GameObject gr1, gr2;
    void Start()
    {
    	canTalk = true;
        iter = 0;
        is1 = false;
        boss = false;
        //activated = true;
        hpUi.SetActive(false);
        next.GetComponent<Button>().onClick.AddListener(nextState);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated){
        	dialogUI.SetActive(true);
        	ui.SetActive(false);
        	loc1t.text = loc[iter];
        	is1 = false;
        }else{
        	dialogUI.SetActive(false);
        	ui.SetActive(true);

        }
    }
    void OnCollisionEnter2D (Collision2D col){
    	if (col.gameObject.name == "player") activated = true;
    }

    void nextState(){
    	int temp = loc.Count - iter;
    	if (canTalk){
    		if (iter < loc.Count){

    			loc1t.text = loc[iter];
    			iter++;
                if (iter == 0 || iter == 2 || iter == 4 || iter == 6){
                    gr1.SetActive(true);
                    gr2.SetActive(false);
                }
                
                else{
                    gr2.SetActive(true);
                    gr1.SetActive(false);
                    } 
    			} 
    		else print ("nah");
    		

    		if (temp == 2){
    			bText.text = "Конец диалога";
    			canTalk = false;

    			} 

    	}else{
    		activated = false;
    		boss = true;
    		dialogUI.SetActive(false);
    		mus.Play();
    		s1.StartCoroutine(s1.direction());
    		s1.active = true;
    		ui.SetActive(true);
            foreach (GameObject g in colliders) Destroy(g);
            hpUi.SetActive(true);
            //foreach (enemyFollow eF in enemies) eF.enabled = true;
    		Destroy(gameObject);
    	}
    		
    		
    	
    }
}
