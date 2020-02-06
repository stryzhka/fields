using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogNpc : MonoBehaviour
{
    public string path;
    public Text text;
    public Dialog __dialog;
    public bool isTrader;
    public int over;
    public GameObject player;
    void Start()
    {
        loader loader = new loader();
        __dialog = loader.loadDialog(path);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = __dialog.text;
        if (isTrader){
            if (playerStats.currentWeap.name != "No weapon"){
                text.text += "Price of your current weapon: " + playerStats.currentWeap.price + "\n" + "To sell press S.";
                if (Input.GetKeyDown("s")){
                loader loader = new loader();
                playerStats.money += playerStats.currentWeap.price -= over;
                playerStats.find(playerStats.currentWeap.path);
                player.GetComponent<inventoryManager>().saveWeapons();
                playerStats.currentWeap = loader.loadWeapon("dataFiles/weapons/noweap");
                playerStats.curPath = "dataFiles/weapons/noweap";
                }   
            } 
            
        } 
    }

}
