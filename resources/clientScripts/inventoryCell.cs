using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Weapon _weapon;
    public Treasure _treas;
    public Weapon _put;
    public string path;
    public GameObject descPanel;
    public loader loader;
    void Start()
    {
        //_weapon = new Weapon(10, 0.01f, "normal", "Dick");
        descPanel = GameObject.Find("descPanel");
        gameObject.GetComponent<Button>().onClick.AddListener(takeItem);
        //gameObject.GetComponentInChildren<Text>().text = "Press to equip " + _weapon.name + "\n" + "Damage: " + _weapon.baseDamage + "\n" + "Effect: " + _weapon.effect + "\n" + "Delay: " + _weapon.delay;
        path = _weapon.path;
        
        loader = new loader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        descPanel.transform.GetChild(0).GetComponent<Text>().text = _weapon.descInfo() + "\n" + loader.loadDesc(_weapon.descPath) ;
        print ("descript:" + loader.loadDesc(_weapon.descPath));
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
            descPanel.transform.GetChild(0).GetComponent<Text>().text = _put.descInfo() + "\n" + loader.loadDesc(_put.descPath) ;
            Color tempText = Color.white;

            playerStats.currentWeap = _weapon;
            playerStats.curPath = _weapon.path;
            print ("Curpath: " + playerStats.curPath);
            _weapon = _put;
            path = _weapon.path;
            print("Now item " + _weapon.name);
            print("at playerstats: " + playerStats.currentWeap.name);
            
            Sprite image = Resources.Load<Sprite>(_weapon.imagePath);
            gameObject.GetComponent<Button>().image.sprite = image;
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
            playerStats.currentWeap = _weapon;
            path = _weapon.path;
            playerStats.curPath = _weapon.path;
            print ("Curpath: " + playerStats.curPath);
            playerStats.find(path, "inventory");
            Destroy(gameObject);
            
            
        }
        
    	
    }
}
