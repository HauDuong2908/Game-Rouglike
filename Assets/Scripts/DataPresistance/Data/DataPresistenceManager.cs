using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class DataPresistenceManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;
    [Header("File Storage Config")]
    [SerializeField] private String fileName;
    [SerializeField] private bool useEncryption; // Sử dụng mã hóa hay không
private GameData gameData; // Dữ liệu trò chơi
private List<IDataPresistence> dataPresistenceObject; // Danh sách các đối tượng lưu trữ dữ liệu
private FileDataHandler dataHandler; // Bộ xử lý dữ liệu tệp
public static DataPresistenceManager instance { get; private set; } // Thể hiện duy nhất của DataPresistenceManager

    private void Awake() {
    // if (instance != null) {
    //     Debug.LogError("Tìm thấy nhiều hơn một Data Presistence Manager trong cảnh.");
    //     Destroy(this.gameObject); 
    //     return;
    // }
    instance = this; 
    DontDestroyOnLoad(this.gameObject); 
    this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption); 
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded; 
        SceneManager.sceneUnloaded += OnSceneUnLoaded; 
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
        SceneManager.sceneUnloaded -= OnSceneUnLoaded; 
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        this.dataPresistenceObject = FindAllDataPresistenceObject();
        LoadGame();
    }

    public void OnSceneUnLoaded(Scene scene){
        SaveGame();
    }

    public void NewGame() {
        this.gameData = new GameData();
    }

    public void LoadGame() {
        this.gameData = dataHandler.load();
        if (this.gameData == null && initializeDataIfNull){
            NewGame();
        }
        if(this.gameData == null){
            Debug.Log("No data was found. Initializing data to defaut.");
            return;
        }
        foreach (IDataPresistence dataPresistenceObj in dataPresistenceObject)
        {
            dataPresistenceObj.LoadData(gameData);
        }
    }
    public void SaveGame() {
        if(this.gameData == null) 
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        foreach(IDataPresistence dataPresistenceObj in dataPresistenceObject)
        {
            dataPresistenceObj.SaveData(gameData);
        }
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    private List<IDataPresistence> FindAllDataPresistenceObject()
    {
        IEnumerable<IDataPresistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPresistence>();
        return new List<IDataPresistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }

}
