using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class ambCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Ambition _amb;
    public string path;
    public GameObject descPanel;
    bool isRus;
    void Start()
    {
    	descPanel = GameObject.Find("descPanel");
    	//gameObject.GetComponent<Button>().onClick.AddListener(amount);
    	loader loader = new loader();
    	//loader.saveAmbition(_amb);
    	//_amb = loader.loadAmbition(path);
    	path = _amb.path;
    	//playerStats.ambDamage += _amb.buff;
        print (_amb.param);
        if (_amb.param == "damage") playerStats.ambDamage += _amb.buff;
        if (_amb.param == "chance"){
            playerStats.chance += _amb.buff;
            var sprite = Resources.Load<Sprite>("sprites/dataSprites/fireAmb");
            gameObject.GetComponent<Button>().image.sprite = sprite;
        } 
        if (_amb.param == "resist"){
            playerStats.resist += _amb.buff;
            var sprite = Resources.Load<Sprite>("sprites/dataSprites/resistAmb");
            gameObject.GetComponent<Button>().image.sprite = sprite;
            print ("now resist is: " + playerStats.resist);
        }
        if (_amb.param == "regen"){
                
                playerStats.regen += playerStats.maxHp / 100 * _amb.buff;
                var sprite = Resources.Load<Sprite>("sprites/dataSprites/regenAmb");
                gameObject.GetComponent<Button>().image.sprite = sprite;
                print ("regen add " + playerStats.maxHp / 100 * _amb.buff);
                print ("now regen is: " + playerStats.regen);
        }
        if (_amb.param == "critical"){
            playerStats.critical += _amb.buff;
            var sprite = Resources.Load<Sprite>("sprites/dataSprites/critical");
            gameObject.GetComponent<Button>().image.sprite = sprite;
        }
        if (_amb.param == "eDmg"){
            playerStats.bonusEffectDamage += _amb.buff;
            var sprite = Resources.Load<Sprite>("sprites/dataSprites/eDmgAmb");
            gameObject.GetComponent<Button>().image.sprite = sprite;
        }
        if (_amb.param == "accuracy"){
            playerStats.bonusAccuracy += _amb.buff;
            var sprite = Resources.Load<Sprite>("sprites/dataSprites/accuracy");
            gameObject.GetComponent<Button>().image.sprite = sprite;
        }
        if (_amb.param == "wSpeed"){
            playerStats.bonusSpeed += _amb.buff;
            var sprite = Resources.Load<Sprite>("sprites/dataSprites/wSpeed");
            gameObject.GetComponent<Button>().image.sprite = sprite;
        }
        if (PlayerPrefs.GetString("language") == "rus") isRus = true;
        else isRus = false;

    }

    // Update is called once per frame
    void Update()
    {
        //calculateBuff();
    }
    void calculateBuff(){
    	if (_amb.param == "damage"){
    		//playerStats.currentWeap.baseDamage += _amb.buff;
    	}
    }
    
     public void OnPointerEnter(PointerEventData eventData)
    {
        print ("here");
        Color tempText = descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color;
        Color temp = descPanel.GetComponent<Image>().color;
        temp.a = 1.0f;
        tempText.a = 1.0f;
        descPanel.GetComponent<Image>().color = temp;
        descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color = tempText;
            string ambName = "";
            string ambNameRus = "";
            switch (_amb.param){
                case "damage":
                    ambName = "to damage";
                    ambNameRus = "к урону";
                    print ("NAME: " + ambName);
                    break;
                case "chance":
                    ambName = "to effect chance";
                    ambNameRus = "к шансу нанести стихийный урон";
                    break;    
                case "resist":
                    ambName = "to resist";
                    ambNameRus = "к сопротивлению";
                    break;
                case "regen":
                    ambName = "to health regeneration";
                    ambNameRus = "к восстановлению здоровья";
                    break;
                case "critical":
                    ambName = "to critical hit chance";
                    ambNameRus = "к шансу нанести критический урон";
                    break;
                case "eDmg":
                    ambName = "to effect damage";
                    ambNameRus = "к стихийному урону";
                    break;
                case "accuracy":
                    ambName = "to ranged weapon accuracy";
                    ambNameRus = "к точности оружия";
                    break;
                case "wSpeed":
                    ambName = "to ranged weapon speed";
                    ambNameRus = "к скорострельности оружия";
                    break;
                }

                if (isRus) descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = _amb.buff + "% " + ambNameRus;
                else descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = _amb.buff + "% " + ambName;
        
   }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        print ("not here");
        Color tempText = descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color;
        Color temp = descPanel.GetComponent<Image>().color;
        temp.a=0.0f;
        tempText.a = 0.0f;
        descPanel.transform.GetChild(0).gameObject.GetComponent<Text>().color = tempText;
        descPanel.GetComponent<Image>().color = temp;
    }
}
