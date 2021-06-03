using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager m_instance;

    public static UIManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    Stack<GameObject> m_interface;

    GameObject m_escUI;

    Text m_stageText;
    Text m_enemyCountText;

    bool m_isOpenInterface = false;

    public bool IsOpenInterface { get { return m_isOpenInterface; } set { m_isOpenInterface = value; } }
        
    private void Start()
    {
        GameObject stageText = GameObject.Find("StageText") as GameObject;
        GameObject enemyCountText = GameObject.Find("EnemyCountText") as GameObject;

        m_interface = new Stack<GameObject>();
        m_escUI = GameObject.Find("ESCInterface") as GameObject;
        m_escUI.SetActive(false);
        m_stageText = stageText.GetComponent<Text>();
        m_enemyCountText = enemyCountText.GetComponent<Text>();
    }

    private void Update()
    {
        UIUpdate();
        UpdateStageText();
        UpdateEnemyCountText();
    }

    private void UIUpdate()
    {
        InputESC();
    }

    private void InputESC()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_interface.Count == 0)
            {
                m_escUI.SetActive(true);
                m_interface.Push(m_escUI);
                m_isOpenInterface = true;
                Time.timeScale = 0;
            }
            else
            {
                CloseUI();
            }
        }
    }

    private void UpdateStageText()
    {
        m_stageText.text = "Stage : " + GameMode.Instance.CurrentSpawnData;
    }

    private void UpdateEnemyCountText()
    {
        m_enemyCountText.text = "EnemyCount : " ;
    }

    public void CloseUI()
    {
        m_interface.Peek().SetActive(false);
        m_interface.Pop();

        if (m_interface.Count == 0)
        {
            m_isOpenInterface = false;
            Time.timeScale = 1;
        }
    }
}