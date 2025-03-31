
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class HealthPickups : MonoBehaviour

{

    [SerializeField] int healthValue = 20; 
    [SerializeField] float speedRotate = 180f; // Tốc độ xoay của vật phẩm
    [SerializeField] AudioClip pickupSFX; // Âm thanh khi nhặt
    [SerializeField] float volume = 0.7f;
    [SerializeField] float lifeTime = 5f; //thời gian tồn tại


    void Start()
    {
        Destroy(gameObject, lifeTime); // Tự hủy sau 5 giây
    }
    
    void Update()

    {
        transform.Rotate(0, 0, speedRotate * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                if (playerHealth.GetHealth() < 100)
                {                 
                    if (pickupSFX != null)
                    {
                        AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position, volume);
                    }
                    playerHealth.RestoreHealth(healthValue);

                    Destroy(gameObject);
                }
            }
        }
    }
}

