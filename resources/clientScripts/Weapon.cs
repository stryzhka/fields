using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 
public class Weapon : Item
{

    public float baseDamage;
    public float delay;
    public string effect;
    public float effectChance;
    public float effectDamage;
    public string type;
    public float accuracy;
    public int raysAmount;
    public string color;
    public string instr;
    public Weapon(string nR, string t, float ac, string n, string p, string ip, int pr, int bD, float d, string s, int ec, int ed, string dP, int rA, string co, string instr, string eID, int eB) :base(n, p, pr, ip, dP, nR, eID, eB){

    	this.baseDamage = bD;
    	this.effect = s;
    	this.delay = d;
    	this.effectChance = ec;
    	this.effectDamage = ed;
        this.type = t;
        this.accuracy = ac;
        this.raysAmount = rA;
        this.color = co;
        this.instr = instr;
    }
    public string info(){
    	return "Type: " + type + "Accuracy: " + accuracy +"Name: " + name + " Damage: " + baseDamage + " Effect: " + effect + " EffectDamage: " + effectDamage + " EffectChance: " + effectChance + " Delay: " + delay;
    }
    public string descInfo(){
        string descName = name + "\nDamage: " + baseDamage +  "\nSpeed: " + delay + "\nEffect: " + effect + " Effect damage: " + effectDamage + "Effect cnahce: " + effectChance;
        string descNameRus = nameRus + "\nУрон: " + baseDamage +  "\nСкорость: " + delay + "\nЭффект: " + effect + " Урон от эффекта: " + effectDamage + "Шанс срабатывания: " + effectChance;
        
        if (playerStats.lang == "eng"){
            if (rareID == "regen"){
                descName += "\nMEDIC!";
                
            }
            return descName;
            } 
        else{
            if (rareID == "regen"){
                descNameRus += "\nМЕДИК!";
                
            }
            return descNameRus;
            
        } 
    }
}
