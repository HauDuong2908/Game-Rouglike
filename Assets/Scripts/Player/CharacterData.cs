using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] private bool isDead;
    

    private GameManager gameManager;
    private CharacterEffect effecter;
    private Animator animator;

    private bool isLeak;

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

    public void SavePlayer () {
        saveSystem.savePlayer(this);
    }

    public void loadPlayer (){
        playerData data = saveSystem.loadPlayer();

        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
