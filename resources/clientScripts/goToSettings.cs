using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject setsUI;
    public GameObject startUI;
    public List<Button> goreButtons;
    bool isStart;
    void Start()
    {
        isStart = true;
        gameObject.GetComponent<Button>().onClick.AddListener(set);
        goreButtons[0].onClick.AddListener(delegate{gore(0);});
        goreButtons[1].onClick.AddListener(delegate{gore(1);});
        goreButtons[2].onClick.AddListener(delegate{gore(2);});
        goreButtons[3].onClick.AddListener(delegate{gore(3);});

    }

    // Update is called once per frame
    void Update()
    {
        if (isStart){
        	startUI.SetActive(true);
        	setsUI.SetActive(false);
        }else{
        	setsUI.SetActive(true);
        	startUI.SetActive(false);
        }
    }
    void set(){
    	if (isStart) isStart = false;
    	else isStart = true;
    }
    void gore(int num){
    	switch (num){
    		case 0:
    			PlayerPrefs.SetInt("gore", 0);
    			print ("numba " + num);
    			break;
    		case 1:
    			PlayerPrefs.SetInt("gore", 1);
    			print ("numba " + num);
    			break;
    		case 2:
    			PlayerPrefs.SetInt("gore", 2);
    			print ("numba " + num);
    			break;
    		case 3:
    			PlayerPrefs.SetInt("gore", 3);
    			print ("numba " + num);
    			break;
    	}
    }
}
