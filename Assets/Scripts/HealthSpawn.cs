using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class HealthPickupSpawner : MonoBehaviour

{

    [SerializeField] GameObject healthPickupPrefab;

    [SerializeField] float minSpawnTime = 10f;

    [SerializeField] float maxSpawnTime = 20f;

    

    // Padding để tránh spawn sát rìa màn hình

    [SerializeField] float paddingLeft = 1f;

    [SerializeField] float paddingRight = 1f;

    [SerializeField] float paddingTop = 1f;

    [SerializeField] float paddingBottom = 1f;



    Vector2 minBounds;

    Vector2 maxBounds;



    void Start()

    {

        InitBounds();

        StartCoroutine(SpawnHealthPickup());

    }



    void InitBounds()

    {

        Camera mainCamera = Camera.main;

        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));

        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }



    IEnumerator SpawnHealthPickup()

    {

        while(true)

        {

            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(randomTime);



            Vector2 randomPosition = new Vector2(

                Random.Range(minBounds.x + paddingLeft, maxBounds.x - paddingRight),

                Random.Range(minBounds.y + paddingBottom, maxBounds.y - paddingTop)

            );



            Instantiate(healthPickupPrefab, randomPosition, Quaternion.identity);

        }

    }

} 
