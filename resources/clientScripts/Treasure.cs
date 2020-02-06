using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Item
{
	public string prefix;
    public Treasure(string n, string p, string ip, int pr, string pref) :base(n, p, pr, ip){
    	this.prefix = pref;
    }
}
