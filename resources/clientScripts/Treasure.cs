using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : Item
{
	public string prefix;
    public Treasure(string n, string p, string ip, int pr, string pref, string dP) :base(n, p, pr, ip, dP){
    	this.prefix = pref;
    }
}
