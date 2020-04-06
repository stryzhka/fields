using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Weapon _weapon;
    public Weapon _put;
    public string path;
    public GameObject descPanel;
    public loader loader;
    bool lang;
    string temp;
    Image currentWeapImg;
    void Start()
    {
        //_weapon = new Weapon(10, 0.01f, "normal", "Dick");
        descPanel = GameObject.Find("descPanel");
        gameObject.GetComponent<Button>().onClick.AddListener(takeItem);
        //gameObject.GetComponentInChildren<Text>().text = "Press to equip " + _weapon.name + "\n" + "Damage: " + _weapon.baseDamage + "\n" + "Effect: " + _weapon.effect + "\n" + "Delay: " + _weapon.delay;
        path = _weapon.path;
        
        loader = new loader();
        temp = PlayerPrefs.GetString("language");
        if (temp == "rus") lang = true;
        else lang = false;
        currentWeapImg = GameObject.Find("currentWeapImg").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        descPanel.transform.GetChild(0).GetComponent<Text>().text = _weapon.descInfo() + "\n" + loader.loadDesc(_weapon.descPath, lang) ;
        print ("descript:" + loader.loadDesc(_weapon.descPath, lang));
        print ("here");
        Color tempText = descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color;
        Color temp = descPanel.GetComponent<Image>().color;
        temp.a = 1.0f;
        tempText.a = 1.0f;
        if (_weapon.color != ""){
            print (_weapon.color);
            switch (_weapon.color){
                case "green":
                    tempText = Color.green;
                    break;

                case "blue":
                    tempText = Color.blue;
                    break;

                case "orange":
                    tempText = Color.yellow;
                    break;
            }
        }else tempText = Color.white;
        descPanel.GetComponent<Image>().color = temp;
        descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color = tempText;
        
        
        
   }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        print ("not here");
        Color tempText = descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color;
        Color temp = descPanel.GetComponent<Image>().color;
        tempText = Color.white;
        temp.a=0.0f;
        tempText.a = 0.0f;

        descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color = tempText;
        descPanel.GetComponent<Image>().color = temp;
        //descPanel.SetActive(false);
    }
    void takeItem(){
    	print("Now item " + _weapon.name);
        if (playerStats.currentWeap.name != "No weapon"){
            _put = playerStats.currentWeap;
            descPanel.transform.GetChild(0).GetComponent<Text>().text = _put.descInfo() + "\n" + loader.loadDesc(_put.descPath, lang) ;
            Color tempText = Color.white;
            rareCheckStats();
            rareCheckCell();
            print("checked for rare");
            playerStats.currentWeap = _weapon;
            playerStats.curPath = _weapon.path;
            print ("Curpath: " + playerStats.curPath);
            _weapon = _put;
            path = _weapon.path;
            print("Now item " + _weapon.name);
            print("at playerstats: " + playerStats.currentWeap.name);
            
            Sprite image = Resources.Load<Sprite>(_weapon.imagePath);
            gameObject.GetComponent<Button>().image.sprite = image;
            currentWeapImg.sprite = Resources.Load<Sprite>(playerStats.currentWeap.imagePath);
            if (_weapon.color != ""){
            print (_weapon.color);
            switch (_weapon.color){
                    case "green":
                        tempText = Color.green;
                        break;

                    case "blue":
                        tempText = Color.blue;
                        break;

                    case "orange":
                        tempText = Color.yellow;
                        break;
                }
        }else tempText = Color.white;
        descPanel.transform.GetChild(0).GetComponent<Text>().color = tempText;
        }else {
            rareCheckCell();
            playerStats.currentWeap = _weapon;
            path = _weapon.path;
            playerStats.curPath = _weapon.path;
            print ("Curpath: " + playerStats.curPath);
            playerStats.find(path, "inventory");
            Destroy(gameObject);
            
            
        }
        
    	
    }
    void rareCheckStats(){
        if (playerStats.currentWeap.rareID == "regen"){
            print("you already have regen, give it");
            print ("-regen: " + playerStats.currentWeap.rareBuff);
            playerStats.regen -= playerStats.currentWeap.rareBuff;
            print ("now regen is: " + playerStats.regen);
        }
        if (playerStats.currentWeap.rareID == "resist"){
            print("you already have resist, give it");
            print ("-resist: " + playerStats.currentWeap.rareBuff);
            playerStats.resist -= playerStats.currentWeap.rareBuff;
            print ("now resist is: " + playerStats.resist);
        }
        if (playerStats.currentWeap.rareID == "speed"){
            print("you already have speed, give it");
            playerStats.speed = 3;
        }else print ("you can live spunk");
        
    }
    void rareCheckCell(){
        if (_weapon.rareID == "regen"){
                print ("get to regen: " + _weapon.rareBuff);
                playerStats.regen += _weapon.rareBuff;
                print ("now regen is: " + playerStats.regen);
        }if (_weapon.rareID == "resist"){
                print ("get to resist: " + _weapon.rareBuff);
                playerStats.resist += _weapon.rareBuff;
                print ("now resist is: " + playerStats.resist);
        }
        if (_weapon.rareID == "speed"){
                print ("wow i am speedy");
                playerStats.speed = 6;
        }
        else print ("sorry, no rare effect");
    }
}
