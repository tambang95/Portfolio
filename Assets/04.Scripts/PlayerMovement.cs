using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool m_isMove;
    bool m_isAtk;

    private PlayerState m_playerState;
    private Rigidbody m_playerRigidbody;
    private Animator m_playerAnimator;
    private Player m_player;

    private void Start()
    {
        m_playerState = GetComponent<PlayerState>();
        m_player = GetComponent<Player>();  
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                m_isAtk = true;
                m_isMove = false;
                m_playerState.ChangeState(PlayerState.State.Atk);
            }
            else
            {
                m_isMove = true;
                m_playerState.ChangeState(PlayerState.State.Move);
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            m_isMove = false;
            m_playerState.ChangeState(PlayerState.State.Idle);
        }
        Move();
        Rotate();
    }

    private void Move()
    {
        if (m_isMove && !m_isAtk)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            Physics.Raycast(cameraRay, out hit, Mathf.Infinity, 1 << 8);

            if(Vector3.Distance(hit.point, transform.position) <= 0.1f)
            {
                m_isMove = false;
                return;
            }

            Vector3 direction = hit.point - transform.position;
            transform.position += direction.normalized * Time.deltaTime * m_player.m_speed;
        }
    }

    private void Rotate()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (plane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, pointTolook.y, pointTolook.z));
        }
    }

    private void AtkAnimEnd()
    {
        m_isAtk = false;
        m_playerState.ChangeState(PlayerState.State.Idle);
    }
}
