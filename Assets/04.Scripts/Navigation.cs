using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Navigation : MonoBehaviour
{

    public Transform m_target;
    NavMeshAgent m_navMeshAgent;

    Enemy m_monsterData;

    private void Start()
    {
        m_target = FindObjectOfType<PlayerMovement>().transform;
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        m_monsterData = GetComponent<Enemy>();

        m_navMeshAgent.speed = m_monsterData.m_speed;
        m_navMeshAgent.stoppingDistance = m_monsterData.m_atkRange;
    }

    private void Update()
    {
        m_navMeshAgent.SetDestination(m_target.position);
    }
}
