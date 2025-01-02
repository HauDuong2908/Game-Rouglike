using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private bool isDead;
     public int deathCount;
    

    private GameManager gameManager;
    private CharacterEffect effecter;
    private Animator animator;

    private bool isLeak;

    public void LoadData(GameData data){
        this.deathCount = data.deathCount;
        FindObjectOfType<GeoCollector>().LoadGeoData(data);
    }

    public void SaveData(ref GameData data){
        data.deathCount = this.deathCount;
        FindObjectOfType<GeoCollector>().SaveGeoData(ref data);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        effecter = FindObjectOfType<CharacterEffect>();
    }

    private void Update()
    {
        CheckIsDead();
        CheckLeakHealth();
    }

    private void CheckLeakHealth()
    {
        if (health == 1 && !isLeak)
        {
            isLeak = true;
            effecter.DoEffect(CharacterEffect.EffectType.LowHealthLeak, true);
        }
        else if (health != 1 && isLeak)
        {
            isLeak = false;
            effecter.DoEffect(CharacterEffect.EffectType.LowHealthLeak, false);
        }
    }

    private void CheckIsDead()
    {
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void LoseHealth(int health)
    {
        this.health -= health;
    }

    public int GetCurrentHealth()
    {
        return health;
    }

    public bool GetDeadStatement()
    {
        CheckIsDead();
        return isDead;
    }

    public void Die()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hero Detector"), LayerMask.NameToLayer("Enemy Detector"), true);
        isDead = true;
        animator.SetTrigger("Dead");

        if (CompareTag("Player"))
        {
            GameEventsManager.instance.PlayerDeath();
            // Reset Geo sau khi player chết
            GeoCollector geoCollector = FindObjectOfType<GeoCollector>();
            if (geoCollector != null)
            {
                geoCollector.ResetGeo(); // Gọi phương thức reset Geo
            }
        }
    }

    public void Respawn()
    {
        FindObjectOfType<HazardRespawn>().Respawn();
    }

    public void SetRespawnData(int health)
    {
        if (health > 0)
        {
            this.health = health;
            animator.ResetTrigger("Dead");
            isDead = false;
        }
    }   
}
