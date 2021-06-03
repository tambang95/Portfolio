using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HPBarUI : MonoBehaviour
{
    public Slider m_healthSlider;
    public Text m_healthText;
    public Animator m_animator;

    public Transform m_target;

    public LivingEntity m_livingEntity;

    private void Start()
    {
        m_healthSlider = GetComponent<Slider>();
        m_healthText = GetComponentInChildren<Text>();
        m_animator = GetComponent<Animator>();

        m_livingEntity = gameObject.transform.parent.parent.GetComponent<LivingEntity>();

        m_healthSlider.maxValue = m_livingEntity.m_maxHp;

        m_target = gameObject.transform.parent;
    }

    private void Update()
    {
        UpdateHpBar();
        MoveHpBar();
    }

    private void UpdateHpBar()
    {
        m_healthSlider.value = m_livingEntity.m_currentHp;

        string currentHp = m_livingEntity.m_currentHp.ToString("N0");

        m_healthText.text = currentHp;

        if (m_healthSlider.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
    }

    private void MoveHpBar()
    {
        transform.position = new Vector3(m_target.position.x, m_target.position.y + 1.5f, m_target.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));
    }
}
