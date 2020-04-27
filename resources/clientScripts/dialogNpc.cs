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
    public Button sellAllB;
    public Transform Content;
    bool isRus;
    public bool cantBuyOne;
    public Image img;
    public Image effect;
    void Start()
    {
        loader loader = new loader();
        __dialog = loader.loadDialog(path);
        if (isTrader){
            if (!cantBuyOne) sellB.onClick.AddListener(sell);
            sellAllB.onClick.AddListener(sellAll);
        }
        if (PlayerPrefs.GetString("language") == "rus") isRus = true;
        else isRus = false;
        img = GameObject.Find("currentWeapImg").GetComponent<Image>();
        effect = GameObject.Find("effect").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRus) text.text = __dialog.text;
        else text.text = __dialog.textRus;
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
                img.sprite = Resources.Load<Sprite>(playerStats.currentWeap.imagePath);
                effect.sprite = Resources.Load<Sprite>("sprites/hats/empty");
                
            } 
    }
    void sellAll(){
        int i = 0;
        foreach (Transform child in Content){
            if (i <= playerStats.inventoryLimit){
                playerStats.money += child.gameObject.GetComponent<inventoryCell>()._weapon.price;
                playerStats.find(child.gameObject.GetComponent<inventoryCell>()._weapon.path, "inventory");
                print ("sell" + i.ToString());
                Destroy(child.gameObject);
            }
            i++;
        }
    }

}
