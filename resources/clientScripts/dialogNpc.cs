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
    public Button sellB;
    void Start()
    {
        loader loader = new loader();
        __dialog = loader.loadDialog(path);
        if (isTrader) sellB.onClick.AddListener(sell);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = __dialog.text;
        if (isTrader){
            
            
        } 
    }
    void sell(){
        if (playerStats.currentWeap.name != "No weapon"){
                //text.text += "Price of your current weapon: " + playerStats.currentWeap.price + "\n" + "To sell press S.";
                
                loader loader = new loader();
                playerStats.money += playerStats.currentWeap.price;
                playerStats.find(playerStats.currentWeap.path, "inventory");
                player.GetComponent<inventoryManager>().saveWeapons();
                playerStats.currentWeap = loader.loadWeapon("dataFiles/weapons/noweap");
                playerStats.curPath = "dataFiles/weapons/noweap";
                
            } 
    }

}
