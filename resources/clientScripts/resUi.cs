using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resUi : MonoBehaviour
{
    // Start is called before the first frame update
    public Text woodCount;
    public string res;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (res == "wood")
        woodCount.text = resStats.woodCount.ToString();
        else if (res == "iron")
        woodCount.text = resStats.ironCount.ToString();
       
    }
}
