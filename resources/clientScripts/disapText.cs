using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disapText : MonoBehaviour
{
    // Start is called before the first frame update
    public float disTime;
    private Color text;
    void Start()
    {
        text = gameObject.GetComponent<Text>().color; 
    }

    // Update is called once per frame
    void Update()
    {
    	 text.a = 0.0f;
    	 
         GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, text, 5f * Time.deltaTime);

    }
}
