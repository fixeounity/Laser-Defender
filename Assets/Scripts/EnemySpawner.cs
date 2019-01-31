using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;

    int startingWave = 0;

	// Use this for initialization
	void Start () {
        var currentWave = waveConfigs[startingWave];
        Debug.Log(currentWave.GetPathPrefab().name);
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
	}

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++) 
        {
            GameObject enemy = Instantiate(
                        waveConfig.GetEnemyPrefab(),
                        waveConfig.GetWaypoints()[0].position,
                        Quaternion.identity
                        );
            enemy.GetComponent<EnemyPathing>().SetWaypoints(waveConfig.GetWaypoints());
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }


}
