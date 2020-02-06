using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string name;
    public string path;
    public int price;
    public string imagePath;
    public Item(string n, string p, int pr, string iP){
    	this.name = n;
    	this.path = p;
    	this.imagePath = iP;
    	this.price = pr;
    }
}
