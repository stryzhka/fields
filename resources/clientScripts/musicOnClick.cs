using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class musicOnClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public bool play;
    public AudioSource sound;
    public Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
    	if (play){
    		sound.Stop();
    		play = false;
    	}
    	else{
            if (playerStats.currentWeap.name == "Guitar"){
                sound.Play();
                play = true;
            }
    		
    	}
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        text.gameObject.SetActive(true);
   }
   public void OnPointerExit(PointerEventData eventData)
    {
        text.gameObject.SetActive(false);
    }
}
