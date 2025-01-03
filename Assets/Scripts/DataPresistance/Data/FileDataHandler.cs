using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    private bool useEncryption = false;
    private readonly string encrytionCodeWord = "word";

    public FileDataHandler(String dataDirPath, String dataFileName, bool useEncryption){
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData load(string profileId) 
    {
        string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream)){
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                Debug.Log("Data to load: " + dataToLoad); // Log the JSON data before parsing
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }catch(Exception e){
                Debug.LogError("Error occurred when trying to load data from file: "+ fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data, string profileId)
    {
        string fullPath = Path.Combine(dataDirPath, profileId   , dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            Debug.Log("Before Save: " + JsonUtility.ToJson(data)); // Log trạng thái trước khi lưu
            string dataToStore = JsonUtility.ToJson(data, true);
            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occurred when trying to save file at path: " 
                        + fullPath  + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles(){
        Dictionary<string, GameData> profilesDictionary = new Dictionary<string, GameData>();
        // lặp qua tất cả các thư mục con trong thư mục dữ liệu
        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();
        foreach (DirectoryInfo dirInfo in dirInfos){
            string profileId = dirInfo.Name;
            string fullPath = Path.Combine(dataDirPath, profileId, dataFileName);
            if(!File.Exists(fullPath)){
                Debug.LogWarning("Skipping directory when loading all profiles because it does not contain data: " 
                + profileId);
                continue;
            }

            GameData profileData = load(profileId);

            if (profileData != null){
                profilesDictionary.Add(profileId, profileData);
            }else{
                Debug.LogError("Tried to load profile data but something went wrong. ProfileId " + profileId);
            }
        }
        return profilesDictionary;
    }

    //mã hóa file save
    private string EncryptDecrypt(string data){
        string modifiedData = "";
        for(int i = 0; i < data.Length; i++){
            modifiedData += (char) (data[i] ^ encrytionCodeWord[i % encrytionCodeWord.Length]);
        }
        return modifiedData;
    }
}