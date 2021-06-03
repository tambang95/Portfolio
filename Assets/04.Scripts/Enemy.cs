using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    public enum EnemyState : int
    {
        Idle = 0,
        Move = 1,
        Atk = 2
    }

    public enum EnemyList : int
    {
        Bat = 1,
        Dragon = 2,
        Golem = 3,
        MonsterPlant = 4,
        Orc = 5,
        Skeleton = 6,
        Slime = 7,
        Spider = 8,
        TurtleShell = 9
    }
    
    Animator m_animator;
    MonsterData m_monsterData;
    EnemyState m_enemyState;

    public Enemy(MonsterData monsterData)
    {
        m_monsterData = monsterData;
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_enemyState = EnemyState.Idle;
        m_name = m_monsterData.Name;
        m_maxHp = m_monsterData.Hp;
        m_currentHp = m_maxHp;
        m_atk = m_monsterData.Atk;
        m_def = m_monsterData.Def;
        m_atkSpeed = m_monsterData.AtkSpeed;
        m_atkRange = m_monsterData.AtkRange;
        m_speed = m_monsterData.Speed;
    }

    private void Update()
    {
        
    }

    public void ChangeState(EnemyState state)
    {
        if (m_enemyState == state)
            return;

        m_enemyState = state;

        m_animator.SetInteger("State", (int)m_enemyState);
    }
}