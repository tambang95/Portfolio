using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // public Enemy enemyPrefab;

    public Transform[] m_spawnerPoints;

    List<int> m_currentStageData;
    List<SpawnData> m_currentSpawnData;
    List<MonsterData> m_monsterData;

    public StageData CurrentStageData { get; set; }

    private void Start()
    {
        m_spawnerPoints = new Transform[4];
        m_spawnerPoints[0] = transform.Find("Spawner0");
        m_spawnerPoints[1] = transform.Find("Spawner1");
        m_spawnerPoints[2] = transform.Find("Spawner2");
        m_spawnerPoints[3] = transform.Find("Spawner3");
    }

    private void OnEnable()
    {
        int currentStage = GameMode.Instance.CurrentStage;
        m_currentStageData = GameMode.Instance.CurrentWaveList(currentStage);

        for(int i = 0; i < m_currentStageData.Count; i++)
        {
            SpawnData temp = null;

            temp = GameMode.Instance.FindSpawnData(m_currentStageData[i]);

            m_currentSpawnData.Add(temp);
        }
    }

    private void Update()
    {
        StartCoroutine(CreateEnemyDelay());
    }

    IEnumerator CreateEnemyDelay()
    {
        CreateEnemy();
        yield return new WaitForSeconds(1f);
    }

    private void CreateEnemy()
    {
        int randomEnemy = Random.Range(0, m_currentSpawnData.Count);
        Transform spawnPoint = m_spawnerPoints[Random.Range(0, m_spawnerPoints.Length)];

        MonsterData monster = GameMode.Instance.FindMonsterData(m_currentSpawnData[randomEnemy].MonsterID);

        GameObject enemyPrefab 

        Enemy enemy = Instantiate(monster.Name, spawnPoint.position, spawnPoint.rotation);
    }
}
