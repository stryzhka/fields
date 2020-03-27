using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootbox : MonoBehaviour
{
    public string listPath;
    public GameObject box;
    public GameObject player;
    public RectTransform weapons;
    public bool debug;
    public Sprite opened;
    public bool isOpened;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
        if (Input.GetKey("s")){
            drop();
        }
    }

    void drop(){
        loader loader = new loader();
            string weaponPath = loader.loadList(listPath);
            GameObject _box = Instantiate(box, transform.position, Quaternion.identity);
            _box.GetComponent<clickable>().weaponPath = weaponPath;
            _box.name = "weapon";
            _box.GetComponent<clickable>().weapons = weapons;
            GetComponent<SpriteRenderer>().sprite = opened;
            isOpened = true;
            //player.GetComponent<inventoryManager>().isActive = true;
    }
    void OnMouseDown(){
    		
            if (Vector2.Distance(player.transform.position, transform.position) <= 3){
                if (!isOpened)
                drop();
                //Destroy(gameObject);
            }
    }
}
