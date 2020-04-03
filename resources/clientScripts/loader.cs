using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class loader
{
    
    private int randomWeapon;
    public Weapon loadWeapon(string path){
        string jsonObj = "null)";
        if (path.Contains("customWeapons")){
            StreamReader reader = new StreamReader(path); 
            jsonObj = reader.ReadToEnd();
        }else{
            TextAsset ta = Resources.Load<TextAsset>(path);
            jsonObj = ta.ToString();
        }
        
        //Debug.Log(jsonObj);
	    Weapon _weapon = JsonUtility.FromJson<Weapon>(jsonObj);
	    Debug.Log(_weapon.info());
    	return _weapon;
    }
    public string loadDesc(string path,bool isRus){
        TextAsset ta = Resources.Load<TextAsset>(path);
        string jsonObj = ta.ToString();
        Description _desc = JsonUtility.FromJson<Description>(jsonObj);
        if (isRus) return _desc.descRus;
        else return _desc.desc;
    }
    public string loadList(string path){
    	TextAsset ta = Resources.Load<TextAsset>(path);
        string jsonObj = ta.ToString();
        DropList dr = JsonUtility.FromJson<DropList>(jsonObj);
        List <string> drops = dr.drops;
        return drops[Random.Range(0, drops.Count)];
    }
    public Treasure loadTr(string path){
    	TextAsset ta = Resources.Load<TextAsset>(path);
        string jsonObj = ta.ToString();
        //Debug.Log(jsonObj);
	    Treasure _treas = JsonUtility.FromJson<Treasure>(jsonObj);
	    Debug.Log(_treas);
    	return _treas;
    }
    public Dialog loadDialog(string path){
    	TextAsset ta = Resources.Load<TextAsset>(path);
        string jsonObj = ta.ToString();
	    Dialog _dialog = JsonUtility.FromJson<Dialog>(jsonObj);
	    Debug.Log(_dialog);
    	return _dialog;
    }
    public static void saveWeapon(Weapon _weapon, string effect){
         string path = Application.persistentDataPath + "/dataFiles/customWeapons/"  + _weapon.name  + ".json";
         _weapon.path = path;
         _weapon.effect = effect;

         string save = JsonUtility.ToJson(_weapon); 
         System.IO.File.WriteAllBytes(path, Encoding.UTF8.GetBytes(save));
         

    }
    public static void saveCraft(Weapon _weapon){
        string path = Application.persistentDataPath + "/dataFiles/customWeapons/"  + _weapon.name + Time.deltaTime + Random.Range(0,10) + ".json";
         _weapon.path = path;
         Debug.Log("_weapon.path " + _weapon.path);

         string save = JsonUtility.ToJson(_weapon); 
         System.IO.File.WriteAllBytes(path, Encoding.Default.GetBytes(save));
    }
    public static void saveAmbition(Ambition _amb){
        string path = Application.persistentDataPath + "/dataFiles/ambitions/"  + _amb.name + Time.deltaTime + Random.Range(0,10) + ".json";
        _amb.path = path;
        string save = JsonUtility.ToJson(_amb); 
        System.IO.File.WriteAllBytes(path, Encoding.ASCII.GetBytes(save));
    }
    public Ambition loadAmbition(string path){
        string jsonObj = "null)";
        StreamReader reader = new StreamReader(path); 
        jsonObj = reader.ReadToEnd();
        Ambition _amb = JsonUtility.FromJson<Ambition>(jsonObj);
        return _amb;
    }
    
}
