using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootbox : MonoBehaviour
{
    public string listPath;
    public GameObject box;
    public GameObject player;
    public RectTransform weapons;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")){
            loader loader = new loader();
            string weaponPath = loader.loadList(listPath);
            GameObject _box = Instantiate(box, transform.position, Quaternion.identity);
            _box.GetComponent<clickable>().weaponPath = weaponPath;
            _box.name = "weapon";
            _box.GetComponent<clickable>().weapons = weapons;
            player.GetComponent<inventoryManager>().isActive = true;
        }
    }
    void OnMouseDown(){
    		
            //Destroy (gameObject);
    }
}
