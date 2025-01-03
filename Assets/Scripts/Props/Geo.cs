using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geo : MonoBehaviour, IDataPresistence
{
    [SerializeField] AudioClip[] geoHitGrounds;
    AudioSource audioSource;
    private SpriteRenderer visual;
    public bool isGrounded;
    private bool collected = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        visual = GetComponent<SpriteRenderer>();
    }

    public void LoadData(GameData data)
    {
        // Lấy danh sách Geo từ GameData
        if (data.geoCollectedList.Contains(gameObject.name))
        {
            collected = true;
            visual.enabled = false; // Ẩn Geo nếu đã thu thập
        }
    }

    public void SaveData(GameData gameData)
    {
        // Nếu Geo đã được thu thập, thêm vào danh sách
        if (collected && !gameData.geoCollectedList.Contains(gameObject.name))
        {
            gameData.geoCollectedList.Add(gameObject.name);
        }
    }

    public void SetCollected(bool status)
    {
        collected = status;
    }

    public bool IsCollected()
    {
        return collected;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded && (collision.gameObject.layer == LayerMask.NameToLayer("Soft Terrain") || collision.gameObject.layer == LayerMask.NameToLayer("Terrain")))
        {
            isGrounded = true;
            int index = Random.Range(0, geoHitGrounds.Length);
            audioSource.PlayOneShot(geoHitGrounds[index]);
        }
    }
}