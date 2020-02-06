using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootbox : MonoBehaviour
{
    public string listPath;
    public GameObject box;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
    	if (Vector2.Distance(transform.position, player.transform.position) <= 2){
    		loader loader = new loader();
	        string weaponPath = loader.loadList(listPath);
	        GameObject _box = Instantiate(box, player.transform.position, Quaternion.identity);
	        _box.GetComponent<clickable>().weaponPath = weaponPath;
            _box.name = "weapon";
            player.GetComponent<inventoryManager>().isActive = true;
            Destroy (gameObject);
    	}
    }
}
