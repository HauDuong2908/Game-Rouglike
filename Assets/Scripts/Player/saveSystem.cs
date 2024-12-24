using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class saveSystem
{
    public static void savePlayer (CharacterData player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "character_save.vku";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player);

        formatter.Serialize(stream, data);
        stream.Close(); 
    }

    public static playerData loadPlayer (){
        string path = Application.persistentDataPath + "character_save.vku";
        if (File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerData data = formatter.Deserialize(stream) as playerData;
            stream.Close();

            return data;
        }else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
