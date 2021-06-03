using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnData
{
    public int ID;
    public int SpawnCount;       // 생성해야 되는 수
    public int MonsterID;
}

public class StageData
{
    public int ID;
    public int WaveID1;
    public int WaveID2;
    public int WaveID3;
    public int WaveID4;
    public int WaveID5;
}

public class GameMode : MonoBehaviour
{
    static GameMode m_instance;
    public static GameMode Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameMode>();
            }

            return m_instance;
        }
    }

    Dictionary<int, MonsterData> m_enemyTable;
    Dictionary<int, SpawnData> m_spawnTable;
    Dictionary<int, StageData> m_stageTable;

    int m_currentStage = 1;

    public int CurrentStage { get { return m_currentStage; } set { m_currentStage = value; } }

    private void Awake()
    {
        m_enemyTable = csvReader.LoadData<int, MonsterData>("SpawnData - MonsterTable");
        m_spawnTable = csvReader.LoadData<int, SpawnData>("SpawnData - SpawnTable");
        m_stageTable = csvReader.LoadData<int, StageData>("SpawnData - StageTable");
    }

    private void Update()
    {
        
    }

    public MonsterData FindMonsterData(int monsterID)
    {
        MonsterData result = null;

        m_enemyTable.TryGetValue(monsterID, out result);

        return result;
    }

    public SpawnData FindSpawnData(int monsterID)
    {
        SpawnData result;

        m_spawnTable.TryGetValue(monsterID, out result);

        return result;
    }

    public StageData FindStageData(int stageData)
    {
        StageData result = null;

        m_stageTable.TryGetValue(stageData, out result);

        return result;
    }

    public List<int> CurrentWaveList(int stageID)
    {
        List<int> result = new List<int>();

        StageData currentStageData = null;

        m_stageTable.TryGetValue(stageID, out currentStageData);

        if (currentStageData.WaveID1 != 0)
            result.Add(currentStageData.WaveID1);
        if (currentStageData.WaveID2 != 0)
            result.Add(currentStageData.WaveID2);
        if (currentStageData.WaveID3 != 0)
            result.Add(currentStageData.WaveID3);
        if (currentStageData.WaveID4 != 0)
            result.Add(currentStageData.WaveID4);
        if (currentStageData.WaveID5 != 0)
            result.Add(currentStageData.WaveID5);

        return result;
    }
}