using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> wayPoints;
    int wayPointsIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {   

        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointsIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(wayPointsIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointsIndex].position; //MoveTowards cần vector điểm đến
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wayPointsIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
