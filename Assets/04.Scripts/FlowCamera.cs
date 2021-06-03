using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowCamera : MonoBehaviour
{
    public Vector3 CamPosition = new Vector3(4, 6, -4);

    [SerializeReference] float m_smooth;

    public Transform m_target;

    Vector3 m_offset;

    private void Start()
    {
        m_offset = transform.position - m_target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetCamPos = m_target.position + m_offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, m_smooth * Time.deltaTime);
    }
}
