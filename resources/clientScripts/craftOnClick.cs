using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class craftOnClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public GameObject text;
    public GameObject canvas;
    bool isTrue;
    void Start()
    {
        isTrue = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        text.SetActive(true);
   }
   public void OnPointerExit(PointerEventData eventData)
    {
        text.SetActive(false);
    }

    void OnMouseDown(){
    		canvas.SetActive(true);
    	
    }
}
