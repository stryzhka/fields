using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 
public class Weapon : Item
{

    public int baseDamage;
    public float delay;
    public string effect;
    public int effectChance;
    public int effectDamage;
    public string type;
    public int accuracy;
    public Weapon(string t, int ac, string n, string p, string ip, int pr, int bD, float d, string s, int ec, int ed, string dP) :base(n, p, pr, ip, dP){

    	this.baseDamage = bD;
    	this.effect = s;
    	this.delay = d;
    	this.effectChance = ec;
    	this.effectDamage = ed;
        this.type = t;
        this.accuracy = ac;
    }
    public string info(){
    	return "Type: " + type + "Accuracy: " + accuracy +"Name: " + name + " Damage: " + baseDamage + " Effect: " + effect + " EffectDamage: " + effectDamage + " EffectChance: " + effectChance + " Delay: " + delay;
    }
    public string descInfo(){
        return "\nDamage: " + baseDamage + " Effect: " + effect + " EffectDamage: " + effectDamage + " EffectChance: " + effectChance + " Delay: " + delay;
    }
}
