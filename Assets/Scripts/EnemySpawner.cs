using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;

    void Start()
    {   
        StartCoroutine(SpawnEnemyWaves());
        
    }
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

   IEnumerator SpawnEnemyWaves()
   {    
        do 
        {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0,0,180), transform);
                //nếu ko có giá trị rotation, nhập Quaternion.identity
                //đối tượng parent là EnemySpawner nên nhập transform => các enemy được tạo sẽ nằm trong EnemySpawner
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }  
                yield return new WaitForSeconds(timeBetweenWaves);
            }       
        }
        while(isLooping);
                                                               
   }
}
