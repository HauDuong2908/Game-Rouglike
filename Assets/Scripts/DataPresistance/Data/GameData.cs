using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int deathCount;
    public Vector3 playerPosition;
    public int geoCount; 

    public List<string> geoCollectedList;
    

    public GameData() {
        this.deathCount = 0;
        this.geoCount = 0;
        //this.playerPosition = new Vector3(-6.2f, 26.2f, 0);
        playerPosition = Vector3.zero;
        geoCollectedList = new List<string>();
    }

    public int GetPercentageComplete(){
        int totalColleted = 0;
        foreach (string collected in geoCollectedList){
            if (!string.IsNullOrEmpty(collected)){
                totalColleted++;
            }
        }

        int percentageCompleted = -1;
        if(geoCollectedList.Count != 0){
            percentageCompleted = (totalColleted * 100 / geoCollectedList.Count);
        }
        return percentageCompleted;
    }
}
