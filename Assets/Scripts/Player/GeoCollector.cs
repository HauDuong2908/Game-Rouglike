using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GeoCollector : MonoBehaviour, IDataPresistence
{
    [SerializeField] Animator collectEffecter;
    [SerializeField] AudioClip[] geoCollects;
    [SerializeField] int geoCount = 0;
    [SerializeField] TextMeshProUGUI geoText;
    [SerializeField] bool needToReset;

    private AudioSource audioSource;
    private int animationCollectTrigger = Animator.StringToHash("Collect");

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (needToReset)
        {
            PlayerPrefs.SetInt("Geo", 0);
            PlayerPrefs.Save();
        }
        geoCount = PlayerPrefs.GetInt("Geo");
        geoText.text = geoCount.ToString();
    }

    public void LoadData(GameData gameData)
    {
        // Cập nhật số lượng Geo đã thu thập từ danh sách
        geoCount = gameData.geoCollectedList.Count;
        geoText.SetText(geoCount.ToString());  // Cập nhật UI

        // Đồng bộ trạng thái của tất cả các Geo
        foreach (var geo in FindObjectsOfType<Geo>())
        {
            geo.LoadData(gameData);
        }
        Debug.Log($"[GeoCollector] Loaded geoCount: {geoCount}");
    }

    public void SaveData(GameData gameData)
    {
        // Lưu geoCount vào GameData
        gameData.geoCount = geoCount;

        // Lưu danh sách các Geo đã thu thập
        foreach (var geo in FindObjectsOfType<Geo>())
        {
            geo.SaveData(gameData);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Geo"))
        {
            Geo geo = collision.gameObject.GetComponent<Geo>();
            if (geo != null && !geo.IsCollected())
            {
                geo.SetCollected(true);
                Debug.Log($"Geo {collision.gameObject.name} collected.");
                geoCount++;
                geoText.SetText(geoCount.ToString());
                Destroy(collision.gameObject);

                // Gọi SaveGame để lưu dữ liệu
                FindObjectOfType<DataPresistenceManager>().SaveGame();
            }
        }
    }

    public void ResetGeo()
    {
        geoCount = 0;
        PlayerPrefs.SetInt("Geo", geoCount);
        PlayerPrefs.Save();
        geoText.SetText(geoCount.ToString());
    }
}