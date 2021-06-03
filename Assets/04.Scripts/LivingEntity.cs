using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public string m_name { get; protected set; }
    public int m_maxHp { get; protected set; }
    public int m_currentHp { get; protected set; }
    public int m_atk { get; protected set; }
    public int m_def { get; protected set; }
    public float m_atkSpeed { get; protected set; }
    public float m_atkRange { get; protected set; }
    public float m_speed { get; protected set; }
    public bool m_isDead { get; protected set; }    

    protected virtual void OnEnable()
    {
        m_isDead = false;
    }
}