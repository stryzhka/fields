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
    void Start()
    {
        //_weapon = new Weapon(10, 0.01f, "normal", "Dick");
        gameObject.GetComponent<Button>().onClick.AddListener(takeItem);
        gameObject.GetComponentInChildren<Text>().text = "Press to equip " + _weapon.name + "\n" + "Damage: " + _weapon.baseDamage + "\n" + "Effect: " + _weapon.effect + "\n" + "Delay: " + _weapon.delay;
        path = _weapon.path;
        descPanel = GameObject.Find("descPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        print ("here");
        descPanel.SetActive(true);
        descPanel.transform.GetChild(0).GetComponent<Text>().text = loader.loadDesc(_weapon.descPath);
        
   }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        print ("not here");
        descPanel.SetActive(false);
    }
    void takeItem(){
    	print("Now item " + _weapon.name);
        if (playerStats.currentWeap.name != "No weapon"){
            _put = playerStats.currentWeap;
            playerStats.currentWeap = _weapon;
            playerStats.curPath = _weapon.path;
            print ("Curpath: " + playerStats.curPath);
            _weapon = _put;
            path = _weapon.path;
            print("Now item " + _weapon.name);
            print("at playerstats: " + playerStats.currentWeap.name);
            gameObject.GetComponentInChildren<Text>().text = "Press to equip " + _weapon.name + "\n" + "Damage: " + _weapon.baseDamage + "\n" + "Effect: " + _weapon.effect + "\n" + "Delay: " + _weapon.delay;
            Sprite image = Resources.Load<Sprite>(_weapon.imagePath);
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = image;
        }else {
            playerStats.find(path);
            playerStats.currentWeap = _weapon;
            path = _weapon.path;
            playerStats.curPath = _weapon.path;
            print ("Curpath: " + playerStats.curPath);
            Destroy(gameObject);
        }
    	
    }
}
