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
        this.playerPosition = new Vector3(-6.2f, 26.2f, 0);
        geoCollectedList = new List<string>();
    }
}
