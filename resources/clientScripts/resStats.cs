using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class resStats
{
    public static int woodCount;
    public static int ironCount;
    public static void setDummyResourcesData(){
    	woodCount = 0;
        ironCount = 0;
    	PlayerPrefs.SetInt("woodCount", woodCount);
        PlayerPrefs.SetInt("ironCount", ironCount);
    }
    public static void saveResourcesData(){
    	PlayerPrefs.SetInt("woodCount", woodCount);
        PlayerPrefs.SetInt("ironCount", ironCount);
    }
    public static void loadResourcesData(){
    	woodCount = PlayerPrefs.GetInt("woodCount");
        ironCount = PlayerPrefs.GetInt("ironCount");
    }
}
