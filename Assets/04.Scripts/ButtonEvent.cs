using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour
{
    Button m_button;
    Image m_buttonImage;
    Text m_buttonText;

    private void Start()
    {
        m_button = GetComponent<Button>();
        m_buttonImage = GetComponent<Image>();
        m_buttonText = GetComponentInChildren<Text>();
    }

    public void MouseOver()
    {
        m_buttonImage.color = Color.gray;
        m_buttonText.color = Color.white;
    }

    public void MouseOut()
    {
        m_buttonImage.color = Color.white;
        m_buttonText.color = Color.black;
    }

    public void CloseUI()
    {
        m_buttonImage.color = Color.white;
        m_buttonText.color = Color.black;
        UIManager.Instance.CloseUI();
    }
}