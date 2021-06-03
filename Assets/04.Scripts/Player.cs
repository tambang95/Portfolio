using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity
{
    private void Awake()
    {
        m_maxHp = 10000;
        m_currentHp = m_maxHp;
        m_atk = 100;
        m_def = 0;
        m_speed = 5;
        m_isDead = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            m_currentHp -= 1000;
    }
}
