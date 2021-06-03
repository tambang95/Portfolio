using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState : int
    {
        Play = 1,
        Pause = 2,
        GameOver = 3
            
    }

    Dictionary<int, List<int>> m_stageList;

    public Dictionary<int, List<int>> StageList { get { return m_stageList; } }

    GameState m_gameState;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ChangeGameState(GameState gameState)
    {
        if (m_gameState == gameState)
            return;

        m_gameState = gameState;

        switch(m_gameState)
        {
            case GameState.Play:

                break;
            case GameState.Pause:

                break;
            case GameState.GameOver:

                break;
        }
    }
}