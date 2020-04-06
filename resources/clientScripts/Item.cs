using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string name;
    public string nameRus;
    public string path;
    public int price;
    public string imagePath;
    public string descPath;
    public string rareID;
    public float rareBuff;
    public Item(string n, string p, int pr, string iP, string dP, string nR, string eID, int eB){
    	this.name = n;
    	this.path = p;
    	this.imagePath = iP;
    	this.price = pr;
        this.descPath = dP;
        this.nameRus = nR;
        this.rareID = eID;
        this.rareBuff = eB;
    }
}
