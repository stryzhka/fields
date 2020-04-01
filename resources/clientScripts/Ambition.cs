using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 
public class Ambition
{
    public string param;
    public int buff;
    public string name;
    public string path;
    public Ambition (string p, int b, string n, string pt, bool a){
    	this.param = p;
    	this.buff = b;
    	this.name = n;
    	this.path = pt;
    }
}
