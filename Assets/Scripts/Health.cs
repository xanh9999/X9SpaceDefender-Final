using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioManager audioManager;
    Score scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindObjectOfType<AudioManager>();
        scoreKeeper = FindObjectOfType<Score>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private int currentHealth;
    

    void OnTriggerEnter2D(Collider2D other) /////////////
    {
        DamageDealing damageDealing = other.GetComponent<DamageDealing>();

        if(damageDealing != null)
        {   
            TakeDamage(damageDealing.GetDamage());
            PlayHitEffect();
            audioManager.PlayGotHitSFX();
            ShakeCamera();
            damageDealing.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {   
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }else{
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    public void RestoreHealth(int healAmount)

    {

        health = Mathf.Min(health + healAmount, 100); // Giới hạn máu tối đa là 100

    }
}
